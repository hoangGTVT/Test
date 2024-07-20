using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SocketIOClient;
using TMPro;
using UnityEngine;


public class NetworkConnection: MonoBehaviour
{

    private static NetworkConnection instance;

    public static NetworkConnection Instance
    {
        get
        {
            if (instance == null)
            {

                GameObject singletonObject = new GameObject("NetworkConnection");
                instance = singletonObject.AddComponent<NetworkConnection>();
            }
            return instance;
        }
    }

   
    public GameManager gameManager;
    
    void Awake()
    {

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public static SocketIO client;
    
    public string list = "";
    
    private void Start()
    {
       
        list = "https://ec1b-42-1-77-246.ngrok-free.app/";
        client = new SocketIO(list);
        client.OnConnected += (sender, e) =>
        {
            Debug.Log("Connected");
            client.On("connectionSuccess", resporn => { Debug.Log(resporn); });
           
        };
        client.On("connectionSuccess", response =>
        {
            JArray jsonArray = JArray.Parse(response.ToString());
            Debug.Log("Vaoroi");
            gameManager.CheckConncet(jsonArray);
        });
        if (!client.Connected)
        {
            gameManager.ConnectFail();
        }
        ReceiveData(); 
            client.ConnectAsync();
        var data = new
        {
            key = 9,
        };
    }
   
    public void SendData(object data)
    {
       
        client.EmitAsync("message", data);


    }
    public void ReceiveData()
    {

        client.On("serverMessage", response =>
        {
            string json12 = response.ToString();
            Debug.Log(json12);
            JArray jsonArray = JArray.Parse(json12);
            
            gameManager.receiveDaTaFromSever(jsonArray);

        });

    }
    /*public void SentUserNameToSever()
    {
        var data = new
        {
             key=1,
             username="cuong1",
             password="cuong123"
           
        };
        string jsonData = JsonConvert.SerializeObject(data);
        SendData(jsonData);
       *//* ReceiveData();*//*
       
    }
    public void SentUserNameToSever1()
    {
        var data = new
        {
            key = 2,
            

        };
        string jsonData = JsonConvert.SerializeObject(data);
        SendData(jsonData);
        *//*ReceiveData1();*//*

    }*/


    /*public void ReceiveData()
    {

        client.On("serverMessage", response =>
        {
            string jsonStr = response.ToString();
            Debug.Log("Received JSON string: " + jsonStr);

            JArray jsonArray = JArray.Parse(jsonStr);

            foreach (JObject obj in jsonArray)
            {
                int key = (int)obj["key"];
                JObject metadataObj = (JObject)obj["metadata"];
                JObject infoObj = (JObject)metadataObj["info"];
                string userName = (string)infoObj["user_name"];

                Debug.Log($"Key: {key}, User Name: {userName}");
            }
        });

    }
    public void ReceiveData1()
    {

        client.On("serverMessage", response =>
        {
            string jsonStr = response.ToString();
            Debug.Log("Received JSON string: " + jsonStr);

            // Parse the JSON string into a JObject
            
            JArray jsonArray = JArray.Parse(jsonStr);
            foreach (JObject obj in jsonArray)
            {
                
                int key = (int)obj["key"];
                
                JArray metadataArray = (JArray)obj["metadata"];
                foreach (JObject metadataObj in metadataArray)
                {
                    JArray charactersArray = (JArray)metadataObj["characters"];

                    // Iterate through the characters array
                    foreach (JObject characterObj in charactersArray)
                    {
                        string characterId = (string)characterObj["_id"];
                        Debug.Log($"Key: {key}, Character Id: {characterId}");
                    }
                }
            }
            

            // Iterate through the metadata array
            
        });
    }*/






}

