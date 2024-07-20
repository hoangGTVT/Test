using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputController : MonoBehaviour
{
   
  
    private static InputController instance;
   
    public static InputController Instance
    {
        get
        {
            if (instance == null)
            {
                
                GameObject singletonObject = new GameObject("InputController");
                instance = singletonObject.AddComponent<InputController>();
            }
            return instance;
        }
    }


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
    [Header("Input")]
    public float _hori;
    public float _ver;
    public GameObject player;
    //Get,set input
    public float GetHorizontal() { return _hori; }
    public float GetVertical() { return _ver; }
    public void SetHorizontal(float value) { _hori = value;}
    public void SetVertical(float value) { _ver = value;}
    

    private void Update()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("PlayerA");
        }
        CheckInput();
        CheckInputKeyBoard();
    }
    
    public void CheckInput()
    {
        SetHorizontal(Input.GetAxis("Horizontal"));
        SetVertical(Input.GetAxis("Vertical"));
    }
    public string CheckInputKeyBoard()
    {
        if (Input.anyKeyDown)
        {
            string buttonPressed = Input.inputString;
            
            return buttonPressed != null ? buttonPressed : "";
        }

        
        return null;


    }

    

    public  bool CheckIfClickedObject()
    {
        // Tạo một ray từ vị trí chuột
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Kiểm tra xem ray có va chạm với đối tượng nào không
        if (Physics.Raycast(ray, out hit))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
