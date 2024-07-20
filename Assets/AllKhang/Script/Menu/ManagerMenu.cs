using UnityEngine;
using TMPro;
using System.IO;
using Newtonsoft.Json;

public class ManagerMenu : MonoBehaviour
{
    [SerializeField] private GameObject objectMenu;
    [SerializeField] private GameObject objectSetPlayer;
    [SerializeField] private GameObject objectLogin;
    [SerializeField] private GameObject objectSellectConfig;
    [SerializeField] private GameObject panelNotification;
    [SerializeField] private GameObject loading;
    [SerializeField] private GameObject objcetSellectType1Player;
    [SerializeField] private GameObject objcetSellectType2Player;
    [SerializeField] private GameObject objcetSellectType3Player;
    [SerializeField] private GameObject objcetSellectType4Player;
    [SerializeField] private GameObject objectPlayer;
    [SerializeField] private GameObject objcetConnect;

    //notification
    [SerializeField] private TextMeshProUGUI notificationText;
    [SerializeField] private TextMeshProUGUI htTextsTest;
    [SerializeField] private TextMeshProUGUI[] htTexts = new TextMeshProUGUI[4];
    public TextMeshProUGUI[] htTypeTexts = new TextMeshProUGUI[12];

    //set name 
    public string[] nameHts = new string[4];
    public string[] idHts = new string[4];
    public string[] nameTypeHts = new string[12];
    public string[] idTypeHts = new string[12];
    public string clientId;
    public string authorization;
    //private Id

    //input login
    public TextMeshProUGUI useNameStart;
    [SerializeField] private TMP_InputField inputFieldName;
    [SerializeField] private TMP_InputField inputFieldPassword;

    // ảnh nhân vật 
    [SerializeField] private GameObject playerObject;
    [SerializeField] private TextMeshProUGUI typePlayer;
    [SerializeField] private TMP_InputField inputNamePlayer;
    [SerializeField] private Sprite[] hts = new Sprite[4];
    private SpriteRenderer spriteRenderer;

    // tài khoản mật khẩu 
    private string _useName;
    private string _passWord;
    // tên và loại  nhân vật 
    private string namPlayer;
    private string planetId;
    private string characterId;
    private ConectSoketIO conectSoketIO;

    private void Start()
    {
        conectSoketIO = objcetConnect.GetComponent<ConectSoketIO>();
        spriteRenderer = playerObject.GetComponent<SpriteRenderer>();
    }
    // xử lý logics từ connect
    public bool checkConnect = false;
    public bool checkStatus = false;
    public bool checkSetText = false;
    public bool checkLoading = false;
    public bool checkSave = false;
    public string setText;
    private void FixedUpdate()
    {
        // Tắt loading và hiện menu 
        if (checkConnect)
        {
            //ẩn loading hiện menu
            loading.SetActive(false);
            objectMenu.SetActive(true);
            checkConnect = false;
        }
        //Hiện lựa chọn nhân vật và tắt menu 
        else if (checkStatus)
        {
            objectMenu.SetActive(false);
            objectSetPlayer.SetActive(true);
            checkConnect = false;
            for (int i = 0; i < nameHts.Length; i++)
            {
                htTexts[i].text = nameHts[i];
            }
            for (int j = 0; j < nameTypeHts.Length; j++)
            {
                htTypeTexts[j].text = nameTypeHts[j];
            }
            checkStatus = false;
        }
        // hiện thông báo và settext 
        else if (checkSetText)
        {
            panelNotification.SetActive(true);
            notificationText.text = setText;
            checkSetText = false;
        }
        else if (checkLoading)
        {
            SaveLoginData();
            checkLoading = false;
        }
        else if (checkSave)
        {
            LoadLoginData();
            checkSave = false;
        }
    }
    public void HiddenNotification()
    {
        panelNotification.SetActive(false);
    }
    public void PresentlySetPlayer()
    {
        if (_useName != "" && _passWord != "")
        {
            var login = new { key = 1, username = _useName, password = _passWord };
            string jsonData = JsonConvert.SerializeObject(login);
            Debug.Log(jsonData);
            NetworkConnection.Instance.SendData(jsonData);
            NetworkConnection.Instance.ReceiveData();
        }
        else
        {
            notificationText.text = "Chưa có tài khoản";
            panelNotification.SetActive(true);
        }
    }
    public void SetUseNamePassWord(string useName, string password)
    {
        _useName = useName;
        _passWord = password;
    }
    public void PresentlyLogin()
    {
        objectMenu.SetActive(false);
        objectLogin.SetActive(true);
    }

    public void PresentlySellectConfig()
    {
        objectSellectConfig.SetActive(true);
    }
    public bool check = false;
    public void HiddeSellectConfig()
    {
        objectSellectConfig.SetActive(false);
    }

    public void HiddeLogin()
    {
        objectMenu.SetActive(true);
        objectLogin.SetActive(false);
    }

    public void HiddeSetPlayer()
    {
        objectMenu.SetActive(true);
        objectSetPlayer.SetActive(false);
    }
    // Đổi tài khoản 
    public void SetLogin()
    {
        if (inputFieldName.text != "" && inputFieldPassword.text != "")
        {
            _useName = inputFieldName.text;
            _passWord = inputFieldPassword.text;
            useNameStart.text = "Chơi với : " + _useName;
            HiddeLogin();
        }
        else
        {
            notificationText.text = "Tài khoản mật khẩu không được để trống";
            panelNotification.SetActive(true);
        }
    }
    // xét dữ liệu dữ liệu hành tinh 
    private void SetHt(int index)
    {
        // hiện lựa chọn của từng hành tinh
        objcetSellectType1Player.SetActive(index == 0);
        objcetSellectType2Player.SetActive(index == 1);
        objcetSellectType3Player.SetActive(index == 2);
        objcetSellectType4Player.SetActive(index == 3);
        // hiện nhân vật 
        objectPlayer.SetActive(true);
        //truyền dữ liệu vào biến id và hình ảnh của các hành tinh
        planetId = idHts[index];
        spriteRenderer.sprite = hts[index];
    }

    public void SetHt1() => SetHt(0);
    public void SetHt2() => SetHt(1);
    public void SetHt3() => SetHt(2);
    public void SetHt4() => SetHt(3);
    // xét dữ liệu type nhân vật  theo hành tinh
    private void SetHtType(int htIndex, int typeIndex)
    {
        int arrayIndex = htIndex * 3 + typeIndex;
        // truyền dữ liệu id các nhân vật theo hành tinh và hiện tên nhân vật theo hành tinh
        characterId = idTypeHts[arrayIndex];
        typePlayer.text = nameTypeHts[arrayIndex];
    }

    public void SetHt1Type1() => SetHtType(0, 0);
    public void SetHt1Type2() => SetHtType(0, 1);
    public void SetHt1type3() => SetHtType(0, 2);
    public void SetHt2Type1() => SetHtType(1, 0);
    public void SetHt2Type2() => SetHtType(1, 1);
    public void SetHt2type3() => SetHtType(1, 2);
    public void SetHt3Type1() => SetHtType(2, 0);
    public void SetHt3Type2() => SetHtType(2, 1);
    public void SetHt3type3() => SetHtType(2, 2);
    public void SetHt4Type1() => SetHtType(3, 0);
    public void SetHt4Type2() => SetHtType(3, 1);
    public void SetHt4type3() => SetHtType(3, 2);

    public void SetAllPlayer()
    {
        namPlayer = inputNamePlayer.text;
        if (string.IsNullOrEmpty(namPlayer))
        {
            notificationText.text = "Vui lòng nhập tên nhân vật";
            panelNotification.SetActive(true);
        }
        else if (string.IsNullOrEmpty(planetId))
        {
            notificationText.text = "Vui lòng chọn hành tinh";
            panelNotification.SetActive(true);
        }
        else if (string.IsNullOrEmpty(characterId))
        {
            notificationText.text = "Vui lòng loại nhân vật theo hành tinh";
            panelNotification.SetActive(true);
        }
        else
        {
            var paramaterPlayer = new
            {
                key = 3,
                player_name = namPlayer,
                planetId = planetId,
                characterId = characterId,
                headers = new { clientId = clientId, authorization = authorization }
            };
            conectSoketIO.SendData(paramaterPlayer);
            conectSoketIO.ReceiveMessage();
        }
    }
    public void SetTextStart(string setText)
    {
        useNameStart.text = setText;
    }
    private void SaveLoginData()
    {

        
        LoadLogin loadLogin = new LoadLogin
        {
            username = _useName,
            password = _passWord
        };
        // Chuyển đổi object thành JSON
        string json = JsonUtility.ToJson(loadLogin);
        string jsonString = JsonConvert.SerializeObject(loadLogin);
        // Khởi tạo đường dẫn đầy đủ cho file JSON
        string path = Path.Combine(Application.persistentDataPath, "LoginData.json");

        // Ghi JSON vào file
        File.WriteAllText(path, jsonString);

        Debug.Log("Saved JSON file at: " + path);
    }
    private void LoadLoginData()
    {
        string path = Path.Combine(Application.persistentDataPath, "LoginData.json");
        Debug.Log(path);
        if (File.Exists(path))
        {
            string jsonFromFile = File.ReadAllText(path);
            Debug.Log("chuỗi đối tượng +  " + jsonFromFile);
            LoadLogin loadedLogin = JsonConvert.DeserializeObject<LoadLogin>(jsonFromFile);
            if (jsonFromFile != "")
            {
                if (!string.IsNullOrEmpty(loadedLogin.username) && !string.IsNullOrEmpty(loadedLogin.password))
                {
                    SetUseNamePassWord(loadedLogin.username, loadedLogin.password);
                    SetTextStart("Tiếp tục với : " + loadedLogin.username);
                }
                else
                {
                    SetTextStart("Chơi mới");
                }
            }
            else
            {
                Debug.LogWarning("There is no data in the file");
            }
        }
        else
        {
            Debug.Log("File does not exist at path: " + path);
            // Xử lý khi không tìm thấy tệp
        }
    }
}
public class LoadLogin
{
    public string username { get; set; }
    public string password { get; set; }
}