using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    [Header("ID")]
    public int idMap;
    public int idNpc;
    [Header("Map")]
    public GameObject[] map;
    public string[] nameMap;
    public GameObject[] mapCurrent; 
    [Header("NPC")]
    public GameObject[] mapNpc;
    public GameObject[] mapNpcCurrent;
    public float posxNpc;
    public float posyNpc;
    public GameObject player;
    public int playerID;
    public void SetPosXNPC(int x) { posxNpc = x; }
    public void SetPosYNPC(int y) { posyNpc = y; }
    public float GetPosXNPC() {  return posxNpc; }
    public float GetPosYNPC() { return posyNpc; }
    public void SetIdMap(int value) { idMap = value; }
    public int GetIdMap() { return idMap; }
    public int GetIdNpc() { return idNpc; }
    public void SetNpc(int value) { idNpc = value; }
    
    public void CreateNpc(int id, int posx, int posy)
    {
        mapNpcCurrent[id] = Instantiate(mapNpc[idNpc],new Vector2(posx,posy),Quaternion.identity);
        mapNpcCurrent[id].transform.SetParent(mapCurrent[id].transform);
    }
    public void DestroyMap(int id) { mapCurrent[id] = null; }
    private void Update()
    {
        
    }
    private void Awake()
    {
        LoadMapToFile();
        LoadNpcToFile();
       
        
    }
   
    /*public void CreateMap()
    {
        Instantiate(map[idMap], new Vector2(0, 0), Quaternion.identity);
        GameObject newo = Instantiate(player, new Vector2(0, 0), Quaternion.identity);
        newo.name = "Player1";
    }*/
    public void LoadMapToFile()
    {
        for (int i = 0; i < map.Length; i++)
        {
            map[i] = Resources.Load<GameObject>("Map/Map" + i);
        }
    }
    public void LoadNpcToFile()
    {
        for (int i = 0; i < mapNpc.Length; i++)
        {
            mapNpc[i] = Resources.Load<GameObject>("Npc/Npc" + i);
        }
    }
}
