using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    float doubleClickTimeThreshold = 0.2f;  
    float lastClickTime = -1f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    

    void OnMouseDown ()
    {
        if (Time.time - lastClickTime < doubleClickTimeThreshold)
        {
            Vector2 vector2 = transform.position;
            if (player == null)
            {
                player = GameObject.FindGameObjectWithTag("PlayerA");
            }
            else
            {
                CharacterMove characterMove = player.GetComponent<CharacterMove>();
                if (characterMove != null)
                {

                    characterMove.MoveToEnemy(vector2.x, vector2.y);
                }
            }
        }
        lastClickTime = Time.time;
       
    }
   
}
