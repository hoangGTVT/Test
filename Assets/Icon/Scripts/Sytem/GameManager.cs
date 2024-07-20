using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Rendering;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {

                GameObject singletonObject = new GameObject("GameManager");
                instance = singletonObject.AddComponent<GameManager>();
            }
            return instance;
        }
    }
    // change
    public bool isCreateCharacter;
    public bool messConnnect;
    public bool canCreate;
    public bool use_Status;
    public string clientID;
    public string authorization;
    public bool loginSuccess;
    public string[] idPlanet = new string[4];
    public string[] namePlanet = new string[4];
    public string[] idPlanetType = new string[12];
    public string[] namePlanetType = new string[12];
    public bool GetIsCreate() { return isCreateCharacter; }
    public string GetIdPlanet(int id) { return idPlanet[id]; }
    public string GetNamePlanet(int name) { return namePlanet[name]; }
    public string GetNamePlanetType(int name) { return namePlanetType[name]; }
    public string GetIdPlanetType(int id) { return (idPlanetType[id]); }
    public bool GetUseStatus() { return use_Status; }
   public bool GetCanCreate() { return canCreate; }
    public bool GetLoginSuccess() { return loginSuccess; }
    public string GetClientID() { return clientID; }
    public string GetAuthorization() { return authorization; }

    public void SetIsCreate(bool value) { isCreateCharacter = value; }
    public void SetCanCreate(bool value) { canCreate = value; }
    public void SetIdPlanet(int id, string name) { idPlanet[id] = name; }
    public void SetNamePlanet(int id, string name) { namePlanet[id] = name; }
    public void SetIdPlanetType(int id, string type) { idPlanetType[id] = type; }
    public void SetNamePlanetType(int id, string name) { namePlanetType[id] = name; }
   public void SetUserStatus(bool value) { use_Status=value; }
    public void SetClientId(string id) { clientID = id; }
    public void SetAuthorization(string id) { authorization = id; }
    public void SetLoginSuccess(bool value) { loginSuccess = value; }




    public GameObject player;
    public GameObject map1;
    public int idmap;
    public string namep;
    [Header("Script")]
    [SerializeField] public GameObject objectManagerMenu;
    [SerializeField] public GameObject loading;
    private ManagerMenu _managerMenu;
    public Character character;
    public ChangeSpriteStatus changeSpriteStatus;
    public MapController mapController;
    [Header("Value")]
    //lấy id và token  
    private string _id;
    private string _tokens;



    //

    int mapid1;
    string playerid1;
    int x1;
    int y1;
    int z1;

    void Start()
    {
        _managerMenu = objectManagerMenu.GetComponent<ManagerMenu>();
        player = Resources.Load<GameObject>("Player");
        map1 = Resources.Load<GameObject>("map1");
        _managerMenu.checkSave = true;

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            var data = new
            {
                key = 1,
                username = "4",
                password = "cuong123"
            };

            Debug.Log(data);
            NetworkConnection.Instance.SendData(data);

        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            var data = new
            {
                key = 11,

                map_id = mapid1,
                playerId = playerid1,
                x = x1,
                y = y1,
                z = z1,
                headers = new
                {
                    clientId = _id,
                    authorization = _tokens,
                }
            };

            Debug.Log(data);
            NetworkConnection.Instance.SendData(data);

        }

    }

    public void receiveDaTaFromSever(JArray data)
    {

        foreach (JObject obj in data)
        {
            int key = (int)obj["key"];
            string checkMessage = (string)obj["message"];
            if (checkMessage == "Ket noi thanh cong")
            {
                messConnnect = true;
            }
            else
            {
                messConnnect = false;
            }
            Debug.Log(key);
            switch (key)
            {
                case 1:
                    HandleCase1(obj);

                    Debug.Log("vo1");
                    break;
                case 2:
                    HandleCase2(obj);
                    break;
                case 3:
                    HandleCase3(obj);
                    break;
                case 4:
                    InFoPlayerRe(obj);
                    Debug.Log("vo");
                    break;
                case 9:
                    Han9(obj);
                    break;
            }
        }

    }
    public void CheckConncet(JArray jArray)
    {

        //ReceiveMessageConnect(response);
        foreach (JObject obj in jArray)
        {
            string checkMessage = (string)obj["message"];
            if (checkMessage == "Ket noi thanh cong")
            {
                _managerMenu.checkConnect = true;
                _managerMenu.setText = "Sever hoạt đông tốt ";
                _managerMenu.checkSetText = true;
            }
        }
    }
    public void ConnectFail()
    {
        /*_managerMenu.setText = "Kết nối đến sever đang lỗi";
        _managerMenu.checkSetText = true;*/
    }
    public void GetInFoUser(JObject jo)
    {
        JObject metadata = jo["metadata"] as JObject;
        JObject info = metadata["info"] as JObject;
        string username = info["user_name"].Value<string>();
        character.SetName(username);


    }
    public void Han9(JObject obj)
    {
        JObject metadata = obj["metadata"] as JObject;
        JArray data = metadata["data"] as JArray;
        int idmap = data["map_id"].Value<int>();
        string name = data["name"].Value<string>();
        Debug.Log(idmap);
    }
    private void HandleCase1(JObject obj)
    {
        if ((bool)obj["metadata"]["success"])
        {

            clientID = (string)obj["metadata"]["info"]["_id"];
            authorization = (string)obj["metadata"]["tokens"]["accessToken"];
            _id = (string)obj["metadata"]["info"]["_id"];
            _tokens = (string)obj["metadata"]["tokens"]["accessToken"];
            string userStatus = (string)obj["metadata"]["info"]["user_status"];
            if (userStatus == "active")
            {
                SetUserStatus(true);            

            }
    
        }
        else
        {
            SetLoginSuccess(false) ;
        }
    }
    private void HandleCase2(JObject obj)
    {
        JArray metadataArray = (JArray)obj["metadata"];
        if (metadataArray != null)
        {
           
            for (int i = 0; i < metadataArray.Count; i++)
            {
                SetIdPlanet(i, (string)metadataArray[i]["_id"]);
                SetNamePlanet(i, (string)metadataArray[i]["name"]);
                JArray charactersArray = (JArray)metadataArray[i]["characters"];
                for (int j = 0; j < charactersArray.Count; j++)
                {
                    int index = i * 3 + j;
                    SetIdPlanetType(index, (string)charactersArray[j]["_id"]) ;
                    SetNamePlanetType(index, (string)charactersArray[j]["name"]);
                }
            }
        }
       
    }

    private void HandleCase3(JObject obj)
    {
        if ((bool)obj["metadata"]["success"])
        {
            SetIsCreate(true);
        }
        else
        {
            SetIsCreate(false);
        }
    }
    public void InFoPlayerRe(JObject jobject)
    {
        JObject metadata = jobject["metadata"] as JObject;
        string userId = metadata["userId"].Value<string>();
        string name = metadata["name"].Value<string>();
        int planet = metadata["planet"].Value<int>();
        int character1 = metadata["character"].Value<int>();
        int gold = metadata["gold"].Value<int>();
        int gem = metadata["gem"].Value<int>();
        int gemlock = metadata["gemlock"].Value<int>();
        JArray item_bag = metadata["item_bag"] as JArray;
        JArray item_body = metadata["item_body"] as JArray;
        JArray item_box = metadata["item_box"] as JArray;
        int box_crack_ball = metadata["box_crack_ball"].Value<int>();

        JObject info = metadata["info"] as JObject;
        string info_id = info["_id"].Value<string>();
        int hp_goc = info["hp_goc"].Value<int>();
        int mp_goc = info["mp_goc"].Value<int>();
        int damage = info["damage"].Value<int>();
        int defense = info["defense"].Value<int>();
        int critical = info["critical"].Value<int>();
        int power = info["power"].Value<int>();
        int potential = info["potential"].Value<int>();
        int stamina = info["stamina"].Value<int>();
        int max_stamina = info["max_stamina"].Value<int>();
        int hp = info["hp"].Value<int>();
        int mp = info["mp"].Value<int>();
        int open_power = info["open_power"].Value<int>();
        int active_point = info["active_point"].Value<int>();
        int indexglt = info["indexglt"].Value<int>();
        JArray optionDamage = info["optionDamage"] as JArray;
        JArray optionHp = info["optionHp"] as JArray;
        JArray optionMp = info["optionMp"] as JArray;
        bool checkGltDisciple = info["checkGltDisciple"].Value<bool>();
        int v = info["__v"].Value<int>();

        int number_cell_bag = metadata["number_cell_bag"].Value<int>();
        int number_cell_box = metadata["number_cell_box"].Value<int>();
        JArray friend = metadata["friend"] as JArray;
        JArray enemy = metadata["enemy"] as JArray;
        JArray skills = metadata["skills"] as JArray;
        bool online = metadata["online"].Value<bool>();
        JArray powers = metadata["powers"] as JArray;
        string id = metadata["_id"].Value<string>();
        DateTime created_at = metadata["created_at"].Value<DateTime>();
        DateTime updated_at = metadata["updated_at"].Value<DateTime>();
        int metadata_v = metadata["__v"].Value<int>();
        Debug.Log("AAA");
        JObject curentMap = metadata["current_map"] as JObject;

        JObject map_id1 = curentMap["map_id"] as JObject;

        string Id = map_id1["_id"].Value<string>();

        int mapid = map_id1["map_id"].Value<int>();
        string plant = map_id1["planet"].Value<string>();
        string nameMap = map_id1["name"].Value<string>();
        string img = map_id1["img_id"].Value<string>();
        Debug.Log(curentMap["x"]);
        int px = curentMap["x"].Value<int>();
        int py = curentMap["y"].Value<int>();
        int z = curentMap["z"].Value<int>();
        mapid1 = mapid;
        playerid1 = id;
        x1 = px;
        y1 = py;
        z1 = z;



    }
}


