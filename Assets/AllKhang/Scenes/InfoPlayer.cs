using UnityEngine;
using UnityEngine.SceneManagement;
public class InfoPlayer : MonoBehaviour
{
    // Singleton instance
    private static InfoPlayer instance;

    // Public properties
    public static InfoPlayer Instance
    {
        get { return instance; }
    }

    public string namePlayer;
    public int idPLant;
    public int playerID;
    public int hp;
    public int mp;
    public int defence;
    public int power;
    public bool isCheckLoad;

    // Ensure singleton behavior
    private void Awake()
    {
        // If an instance already exists and it's not this one, destroy this instance
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        // Set this instance as the singleton instance
        instance = this;

        // Ensure this GameObject persists across scenes
        DontDestroyOnLoad(this.gameObject);
    }

    // Your setter methods
    public void setIdPlant(int id) { idPLant = id; }
    public void setPlayerID(int id) { playerID = id; }
    public void setHp(int h) { hp = h; }
    public void setMp(int m) { mp = m; }
    public void setDefence(int def) { defence = def; }
    public void setPower(int po) { power = po; }
    public void SetName(string name) { namePlayer = name; }
    public int getIdPlant() { return idPLant; }
    public int getPlayerID() { return playerID; }
    public int getHp() { return hp; }
    public int getMp() { return mp; }
    public int getDefence() { return defence; }
    public int getPower() { return power; }
    public void setName(string name) { this.namePlayer = name; }
    public void SetIsCheck(bool value) { isCheckLoad = value; }
    public bool GetIsCheck() { return isCheckLoad; }
    private void FixedUpdate()
    {
        if (GetIsCheck()==true)
        {
            
            SceneManager.LoadScene("Game");
            SetIsCheck(false);
        }
    }
}
