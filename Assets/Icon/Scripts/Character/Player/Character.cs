using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[JsonObject(memberSerialization: MemberSerialization.OptIn)]
public class Character : MonoBehaviour
{
    [JsonProperty("Gender")]
    public int gender;
    [JsonProperty("Status")]
    public int status;
    [JsonProperty("hp")]
    public int hp;
    [JsonProperty("mp")]
    public int mp;
    [JsonProperty("dame")]
    public int dame;
    [JsonProperty("defence")]
    public int defence;
    [JsonProperty("defence")]
    public string name123;

    private void FixedUpdate()
    {
       
    }

    //Get set info
    public string GetName() { return name123; }
    public int GetHpPlayer() { return hp; }
    public int GetMpPlayer() { return mp; }
    public int GetGender() { return gender; }
    public int GetStatus() { return status; }
    public int GetDefence() { return defence; }
    public int GetAtk() { return dame; }

    public void SetName(string name) { name123=name; }
    public void SetHp(int value) { hp = value; }
    public void SetMp(int value) { mp = value; }
    public void SetATK(int value) { dame = value; }
    public void SetDef(int value) { defence = value; }
    public void SetGender(int value) { gender = value; }
    public void SetStatus(int value) { status = value; }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            showinfo();
        }

    }
    public void showinfo()
    {
        var data = new[]
{
    new
    {
        success = true,
        message = "Player Info",
        key = 4,
        metadata = new
        {
            userId = "668b97061b142341cf2cf5a3",
            name = "adferr",
            planet = 1,
            character = 1,
            gold = 0,
            gem = 0,
            gemlock = 0,
            item_bag = new object[] { },
            item_body = new object[] { },
            item_box = new object[] { },
            box_crack_ball = 0,
            info = new
            {
                _id = "668f95e2b8fb9df153ec90af",
                hp_goc = 100,
                mp_goc = 100,
                damage = 10,
                defense = 0,
                critical = 0,
                power = 1,
                potential = 0,
                stamina = 1000,
                max_stamina = 1000,
                hp = 100,
                mp = 100,
                open_power = 1,
                active_point = 0,
                indexglt = 0,
                optionDamage = new object[] { },
                optionHp = new object[] { },
                optionMp = new object[] { },
                checkGltDisciple = false,
                __v = 0
            },
            number_cell_bag = 0,
            number_cell_box = 0,
            friend = new object[] { },
            enemy = new object[] { },
            skills = new object[] { },
            online = false,
            powers = new object[] { },
            _id = "668f95e2b8fb9df153ec90b1",
            created_at = "2024-07-11T08:20:50.345Z",
            updated_at = "2024-07-11T08:20:50.345Z",
__v = 0
        }
    }
};

        string json12 = JsonConvert.SerializeObject(data);
        Debug.Log(json12);
        JArray jsonArray = JArray.Parse(json12);

        foreach (JObject item in jsonArray)
        {
            bool success = item["success"].Value<bool>();
            string message = item["message"].Value<string>();
            int key = item["key"].Value<int>();
            switch (key)
            {
                case 4:
                    JObject metadata = item["metadata"] as JObject;
                    string userId = metadata["userId"].Value<string>();
                    string name = metadata["name"].Value<string>();
                    int planet = metadata["planet"].Value<int>();
                    int character = metadata["character"].Value<int>();
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

                    Debug.Log(mp);
                    break;
            }

        }

        




    }

}

    /*public void showinfo()
    {
        var data = new
        {
            key = 1,
            hp=5

        };
        string json12=JsonConvert.SerializeObject(data);
            
        JObject json1 = JObject.Parse(json12);
        int key1 = (int)json1["key"];
        Character character1 = GameObject.FindGameObjectWithTag("PlayerA").GetComponent<Character>();
        Debug.Log(key1);
        
        character1=JsonConvert.DeserializeObject<Character>(json12.ToString());
       
        hp = character1.hp;
        mp = character1.mp;
        defence = character1.defence;
        gender = character1.gender;
        status = character1.status;
        dame = character1.dame;
        
    }*/



