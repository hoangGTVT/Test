using DG.Tweening;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using TMPro;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameManager gameManager;
    [Header("GameObject")]
    public GameObject pannel;
    public GameObject loading;
    public GameObject menuStartGame;
    public GameObject menuLogin;
    public GameObject createCharacter;
    public GameObject createTk;

    public GameObject login;
    [Header("Sprite")]
    public GameObject[] icon;
    [Header("Text")]
    public TextMeshProUGUI textPannel;
    public string textLogin;
    public TextMeshProUGUI textLoginShow;
    public TextMeshProUGUI textConnect;
    [Header("InputText")]
    public TMP_InputField inputUserLogin;
    public TMP_InputField inputPasswordLogin;
    public TMP_InputField inputUserCreate;
    public TMP_InputField inputPasswordCreate;
    public TMP_InputField inputNamePlayer;

    [Header("Value")]
    public string idPlant;
    public string idChacracter;
    public string nameplayer;


    private void Start()
    {
        gameManager.SetLoginSuccess(true);
        gameManager.SetUserStatus(true);
        gameManager.messConnnect = true;
        /* PlayerPrefs.DeleteAll();*/
        loading.SetActive(true);
        Invoke("CheckConnect", 1);
        CheckTK();
    }
    public void CheckConnect()
    {
        if (gameManager.messConnnect == true)
        {
            textConnect.text = "Kết nối thành công";
            Invoke("HideLoading", 2);

        }
        else
        {
            textConnect.text = "Kết nối sever thất bại";
        }
    }
    //Hide
    public void HideLoading()
    {
        loading.SetActive(false);
    }
    public void HideIcon()
    {
        for (int i = 0; i < icon.Length; i++) { icon[i].SetActive(false); }
    }
    //get set Value
    public string GetIdPlant() { return idPlant; }
    public string GetIdChacracter() { return idChacracter; }
    public void SetIdPlant(string id) { idPlant = id; }
    public void SetIdCharacter(string id) { idChacracter = id; Debug.Log(idChacracter); }

    //Create Character
    public void CreateCharacter()
    {


        string name = inputNamePlayer.text;
        if (name == "" || name.Length < 5 || name.Length > 10)
        {
            textPannel.text = "Tên không được để trống. Tên chỉ được 5-10 ký tự";
            pannel.SetActive(true);


        }
        else
        {
            if (GetIdPlant() != "" && GetIdChacracter() != "")
            {
                var data = new
                {
                    key = 3,
                    player_name = nameplayer,
                    planetId = GetIdPlant(),
                    characterId = GetIdChacracter(),
                    headers = new { clientId = gameManager.GetClientID(), authorization = gameManager.GetAuthorization() }
                };
                NetworkConnection.Instance.SendData(data);
                Invoke("CheckCreateCharacter", 1);
            }
            else
            {
                textPannel.text = "Vui lòng chọn hành tinh và nhân vật";
                pannel.SetActive(true);
            }
            
        }


    }
    public void CheckCreateCharacter()
    {
        if (gameManager.GetIsCreate())
        {
            menuStartGame.SetActive(false);
            textConnect.text = "";
            loading.SetActive(true);
            Invoke("HideLoading", 2);
        }
        else
        {
            textConnect.text = "Lỗi tạo nhân vật";
            loading.SetActive(true);
            Invoke("HideLoading", 2);
        }
    }
    public void CheckTK()
    {
        string user = PlayerPrefs.GetString("UserPlayer");
        if (user == "")
        {
            textLogin = "Chơi Mới";
            textLoginShow.text = textLogin;
        }
        else
        {
            textLogin = PlayerPrefs.GetString("UserPlayer");
            textLoginShow.text = textLogin;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void CreateAccCount()
    {
        PlayerPrefs.SetString("UserPlayer", inputUserCreate.text);
        textLogin = inputUserCreate.text;
        textLoginShow.text = "Chơi Với:" + textLogin;
        PlayerPrefs.SetString("PassWord", inputPasswordCreate.text);
        createTk.SetActive(false);
        menuLogin.SetActive(true);
    }
    //logintoGame
    public void LoginToGame()
    {
        if (!gameManager.GetLoginSuccess())
        {
            textPannel.text = "Đăng nhập thất bại";
            pannel.SetActive(true);
        }
        else
        {
            if (gameManager.GetUseStatus())
            {
                var playerActive = new
                {
                    key = 4,
                    headers = new { clientId = gameManager.GetClientID(), authorization = gameManager.GetAuthorization() }
                };
                NetworkConnection.Instance.SendData(playerActive);
                menuStartGame.SetActive(false);
                textConnect.text = "";
                loading.SetActive(true);
                Invoke("HideLoading", 2);
            }
            else
            {
                var data = new { key = 2 };
                NetworkConnection.Instance.SendData(data);
                createCharacter.SetActive(true);
                menuLogin.SetActive(false);
            }
        }
    }
    //CheckLoginStartGame
    public void CheckLogin()
    {

        string user = PlayerPrefs.GetString("UserPlayer");
        if (string.IsNullOrEmpty(user))
        {
            menuLogin.SetActive(false);
            createTk.SetActive(true);

        }

        else
        {
            string usertk = PlayerPrefs.GetString("UserPlayer");
            string passtk = PlayerPrefs.GetString("PassWord");
            var data = new
            {
                key = 1,
                username = usertk,
                password = passtk,


            };
            string jsonData = JsonConvert.SerializeObject(data);
            NetworkConnection.Instance.SendData(jsonData);
            Invoke("LoginToGame", 1);



        }
    }


    //ChangeAcc
    public void ChangeAccout()
    {
        string textLogin1 = inputUserLogin.text;
        string password1 = inputPasswordLogin.text;

        if (textLogin1 != "" && password1 != "")
        {
            if (textLogin1.Length > 10 || textLogin1.Length < 5 || password1.Length > 10 || password1.Length < 5)
            {
                textPannel.text = "Tài khoản và mật khẩu tối đa 10 ký tự";
                pannel.SetActive(true);
            }
            else
            {
                textLoginShow.text = "Chơi tiếp:" + textLogin1;
                PlayerPrefs.SetString("UserPlayer", inputUserLogin.text);
                PlayerPrefs.SetString("PassWord", inputPasswordLogin.text);
                login.SetActive(false);
                menuLogin.SetActive(true);
            }

        }
        else
        {
            textPannel.text = "Cần nhập thông tin tài khoản và mật khẩu";
            pannel.SetActive(true);
        }

    }
}
