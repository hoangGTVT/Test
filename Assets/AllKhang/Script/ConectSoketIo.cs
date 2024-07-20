using UnityEngine;
using SocketIOClient;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Net;
using UnityEditor.PackageManager;
using UnityEngine.TextCore.Text;
using System;
using UnityEditor.VersionControl;


public class ConectSoketIO : MonoBehaviour
{
    [SerializeField] private GameObject objectManagerMenu;
    [SerializeField] private GameObject loading;
    //menu
    private ManagerMenu _managerMenu;
    //sever
    private SocketIO client;
    //lấy id và token  
    private string _id;
    private string _tokens;
    private void Start()
    {
        // khỏi tạo 
        _managerMenu = objectManagerMenu.GetComponent<ManagerMenu>();
        // kết nỗi dữ liệu 
        client = new SocketIO("https://ec1b-42-1-77-246.ngrok-free.app/");

        client.OnConnected += (sender, e) =>
        {
            Debug.Log("Connected to server");
        };
        client.On("connectionSuccess", response =>
        {
            Debug.Log(response);
            JArray jsonArray = JArray.Parse(response.ToString());
            //ReceiveMessageConnect(response);
            foreach (JObject obj in jsonArray)
            {
                string checkMessage = (string)obj["message"];
                if (checkMessage == "Ket noi thanh cong")
                {
                    _managerMenu.checkConnect = true;
                    _managerMenu.setText = "Sever hoạt đông tốt ";
                    _managerMenu.checkSetText = true;
                }
            }
        });
        if (!client.Connected)
        {
            //_managerMenu.setText = "Kết nối đến sever đang lỗi";
            _managerMenu.checkSetText = true;
        }
        // Kết nối đến server và chờ đến khi kết nối thành công hoặc hết thời gian
        client.ConnectAsync();
        // tải dư liệu tài khoản và  hiện thông báo 
        _managerMenu.checkSave = true;
    }
    public void SendData(object data)
    {
        
        client.EmitAsync("message", data);
        Debug.Log(data);
    }
    public void ReceiveMessage()
    {
        client.On("serverMessage", response =>
        {
            Debug.Log(response);
            //ReceiveMessageSrting(response);
            JArray jsonArray = JArray.Parse(response.ToString());
            foreach (JObject obj in jsonArray)
            {
                int keyMessage = (int)obj["key"];
                switch (keyMessage)
                {
                    case 0:

                        break;

                    case 1:
                        if ((bool)obj["metadata"]["success"])
                        {
                            _managerMenu.clientId = (string)obj["metadata"]["info"]["_id"];
                            _managerMenu.authorization = (string)obj["metadata"]["tokens"]["accessToken"];
                            if ((string)obj["metadata"]["info"]["user_status"] == "active")
                            {
                                var playerActive = new
                                {
                                    key = 4,
                                    headers = new { clientId = _managerMenu.clientId, authorization = _managerMenu.authorization }
                                };
                                SendData(playerActive);
                                ReceiveMessage();
                            }
                            if ((string)obj["metadata"]["info"]["user_status"] == "pending")
                            {
                                // gửi nhận dữ liệu 
                                var data = new
                                {
                                    key = 2
                                };
                                SendData(data);// truyền vào key 2
                                ReceiveMessage();
                                // hiện lựa chọn hành tinh và set string cho textMeshPro
                            }
                            // lưu tài khoản mật khẩu 
                            _managerMenu.checkLoading = true;

                        }
                        else
                        {
                            _managerMenu.setText = (string)obj["metadata"]["message"];
                            _managerMenu.checkSetText = true;
                        }
                        break;
                    case 2:
                        // Kiểm tra dữ liệu sau khi giải mã
                        JArray metadataArray = (JArray)obj["metadata"];
                        if (metadataArray != null)
                        {
                            _managerMenu.checkStatus = true;
                            for (int i = 0; i < metadataArray.Count; i++)
                            {
                                _managerMenu.idHts[i] = (string)metadataArray[i]["_id"];
                                _managerMenu.nameHts[i] = (string)metadataArray[i]["name"];
                                JArray charactersArray = (JArray)metadataArray[i]["characters"];
                                for (int j = 0; j < charactersArray.Count; j++)
                                {
                                    int index = i * 3 + j;
                                    _managerMenu.idTypeHts[index] = (string)charactersArray[j]["_id"];
                                    _managerMenu.nameTypeHts[index] = (string)charactersArray[j]["name"];
                                }
                            }
                        }
                        else
                        {
                            Debug.LogError("Data is null or not successful.");
                        }
                        break;
                    case 3:
                        if ((bool)obj["metadata"]["success"])
                        {
                            Debug.Log("trạo nhân vật xong và nhân dữ liệu ");
                        }
                        else
                        {
                            _managerMenu.setText = (string)obj["metadata"]["message"];
                            _managerMenu.checkSetText = true;
                        }
                        break;
                    case 4:
                        JObject metada = obj["metadata"] as JObject;
                        string name = metada["name"].Value<string>();
                        InfoPlayer.Instance.SetName(name);
                        break;
                }
            }
        });
    }

    //private void CheckPlatform()
    //{
    //    DeviceInfo deviceInfo = new DeviceInfo();
    //    if (Application.platform == RuntimePlatform.WindowsEditor ||
    //        Application.platform == RuntimePlatform.WindowsPlayer)
    //    {
    //        deviceInfo.device = "Windows";
    //        SendMessage("device", deviceInfo);
    //        //ReceiveMessage("deviceReponse");
    //        Debug.Log("Running on Windows.");
    //    }
    //    else if (Application.platform == RuntimePlatform.OSXEditor ||
    //             Application.platform == RuntimePlatform.OSXPlayer)
    //    {
    //        deviceInfo.device = "macOS";
    //        SendMessage("device", deviceInfo);
    //        Debug.Log("Running on macOS.");
    //    }
    //    else if (Application.platform == RuntimePlatform.Android)
    //    {
    //        deviceInfo.device = "Android";
    //        SendMessage("device", deviceInfo);
    //        Debug.Log("Running on Android.");
    //    }
    //    else if (Application.platform == RuntimePlatform.IPhonePlayer)
    //    {
    //        deviceInfo.device = "iOS";
    //        SendMessage("device", deviceInfo);
    //        Debug.Log("Running on iOS.");
    //    }
    //    else
    //    {
    //        deviceInfo.device = "NotDevice";

    //        SendMessage("device", deviceInfo);
    //        Debug.Log("Platform not recognized.");
    //    }
    //}
    public void DisconnectServer()
    {
        // Đóng kết nối server
        client.DisconnectAsync();
    }

}

//public class DeviceInfo
//{
//    public string device;
//    public int key;
//}