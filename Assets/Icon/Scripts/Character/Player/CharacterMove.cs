using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Newtonsoft.Json;
[JsonObject(MemberSerialization =MemberSerialization.OptIn)]
public class CharacterMove : MonoBehaviour
{
    public RuntimeAnimatorController[] controller;
    [Header("Player")]
    [SerializeField] public  GameObject _player;
    [SerializeField] public Tween _playerTween;
    [JsonProperty("key")]
    [SerializeField] public float _id;
    [JsonProperty("px")]
    [SerializeField] public float _px;
    [JsonProperty("py")]
    [SerializeField] public float _py;
    [JsonProperty("dir")]
    [SerializeField] public float _dir;
    [SerializeField] public float _distanceMove;
    [SerializeField] public float _speedMove;
    [SerializeField] public bool _isRight;
    [SerializeField] float _isY;
    [SerializeField] public bool _isCanMoveMouse;
    public float checkRadius = 2f; 
    public LayerMask groundLayer;
    public BoxCollider2D _boxCollider;
    [Header("Script")]
    [SerializeField] public PlayerAnimation _playerAnimation;
    [SerializeField] public Rigidbody2D _rigidbody2;
    
    void Start()
    {
        _playerAnimation = GetComponentInChildren<PlayerAnimation>();
        _rigidbody2 =GetComponent<Rigidbody2D>();
      _isRight=true;
        _px=GetPosXPlayer()+1;
        _py=GetPosYPlayer()+1;
        

    }
   

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        ChangeAnimation();
  
    }

    
    //Player Move
    public float GetSpeedMove() {  return _speedMove; }
    public void SetSpeedMove(float value) {  _speedMove = value; }
    public float GetDistanceMove() { return _distanceMove; }
    public void SetDistanceMove(float speed) { _distanceMove = speed; }
    public void PlayerMove()
    {
       
        if (InputMouse()==true && !IsGroundedAround())
        {
            
            if (GetPosXPlayer() != _px)
            {
                float pos = _px;
                if (pos > transform.position.x) { if (!CheckRight()) { PlayerRotate(1); } }
                if (pos < transform.position.x) { if (CheckRight()) { PlayerRotate(-1); } }
                float posMouse = _py - GetPosYPlayer();
                if (IsGroundedLeft() || IsGroundedRight())
                {
                    if (posMouse > 0)
                    {
                        
                        PlayerMoveActive(GetPosXPlayer(), _py, 1f);
                        
                        Invoke("PlayerMoveMouse", 0.5f);

                    }
                    else if (posMouse < 0)
                    {
                        
                        PlayerMoveActive(_px, GetPosYPlayer(), 1f);
                        
                    }
                }
                else
                {
                    PlayerMoveActive(_px, _py,1);
                }
            }          
                  
        }
        else
        {
            if (_playerAnimation.GetSkill() == false)
            {
                if (InputController.Instance.GetVertical() > 0 && !IsGroundedUp())
                {              
                    MoveUp();
                }

               /* if (InputController.Instance.GetVertical() < 0 && !IsGroundedDown())
                {                  
                    MoveDown();
                }*/
                if (InputController.Instance.GetHorizontal() > 0 && !IsGroundedRight())
                {
                    MoveRight();
                }
                else if (InputController.Instance.GetHorizontal() < 0 && !IsGroundedLeft())
                {
                    MoveLeft();
                }
                
            }
            
           
            
        }
    }
    public void MoveToEnemy(float x, float y)
    {
        if (!IsGroundedAround())
        {
           
            if (GetPosXPlayer() != _px)
            {
                float pos = _px;
                if (pos > transform.position.x) { if (!CheckRight()) { PlayerRotate(1); } }
                if (pos < transform.position.x) { if (CheckRight()) { PlayerRotate(-1); } }
                float posMouse = _py - GetPosYPlayer();
                if (IsGroundedLeft() || IsGroundedRight())
                {
                    if (posMouse > 0)
                    {

                        PlayerMoveActive(GetPosXPlayer(), _py, 1f);

                        Invoke("PlayerMoveMouse", 0.5f);

                    }
                    else if (posMouse < 0)
                    {

                        PlayerMoveActive(_px, GetPosYPlayer(), 1f);

                    }
                }
                else
                {
                    PlayerMoveActive(_px, _py, 1);
                }
            }
        }
    }
    //move
    public void MoveUp()
    {
        if (GetPosYPlayer() != _py)
        {

            PlayerMoveActive(GetPosXPlayer(), GetPosYPlayer() + GetDistanceMove(), GetSpeedMove());
        }
    }
    public void MoveDown()
    {
        if (GetPosYPlayer() != _py)
        {

            PlayerMoveActive(GetPosXPlayer(), GetPosYPlayer() - GetDistanceMove(), GetSpeedMove());

        }
    }
    public void MoveRight()
    {
        if (!CheckRight())
        {
            _dir = 1;

            PlayerRotate(_dir);
        }


        if (GetPosXPlayer() != _px)
        {

            PlayerMoveActive(GetPosXPlayer() + GetDistanceMove(), GetPosYPlayer(), GetSpeedMove());
        }
    }
    public void MoveLeft()
    {
        if (!CheckLeft())
        {
            _dir = -1;
            PlayerRotate(_dir);
        }

        if (GetPosXPlayer() != _px)
        {

            PlayerMoveActive(GetPosXPlayer() - GetDistanceMove(), GetPosYPlayer(), GetSpeedMove());
        }
    }
    public bool InputMouse()
    {
            if (Input.GetMouseButtonDown(0))
            {              
                Vector3 mousePosition = Input.mousePosition;
                mousePosition.z = 10;
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
               SetPx(worldPosition.x);
                SetPy(worldPosition.y);

            return true;
             }
        else return false;
    }
    public void PlayerMoveActive(float px, float py,float speed)
    {
        _playerTween=transform.DOMove(new Vector3(px, py, 0), speed, false);
        
    }
    public void PlayerMoveMouse()
    {
        PlayerMoveActive(_px, _py,1);
    }
    //Set Get Position move
    public void SetDir(float i)
    {

    _dir = i; }
    public void SetPx(float i)
    {
        _px = i;
    }
    public float GetPx()
    {
        return _px;
    }
    public void SetPy(float i) { 
        _py = i;
    }
    public float GetPy()
    {
         return _py;
    }

    
    //Get PositionPlayer
    public float GetPosXPlayer()
    {
        if(_player!=null)
        {
            return _player.transform.position.x;
        }else return 0;
       
    }
    public float GetPosYPlayer()
    {
        if (_player != null)
        {
            return _player.transform.position.y;
        }
        else return 0;

    }
    //CheckGround
    
    
     public bool IsGroundedRight()
      {
            return Physics2D.BoxCast(_boxCollider.bounds.center, _boxCollider.bounds.size, 0f, Vector2.right, checkRadius, groundLayer);
      }
    public bool IsGroundedLeft()
    {
        return Physics2D.BoxCast(_boxCollider.bounds.center, _boxCollider.bounds.size, 0f, Vector2.left, checkRadius, groundLayer);
    }
    public bool IsGroundedDown()
    {
        return Physics2D.BoxCast(_boxCollider.bounds.center, _boxCollider.bounds.size, 0f, Vector2.down, checkRadius, groundLayer);
    }
    public bool IsGroundedUp()
    {
        return Physics2D.BoxCast(_boxCollider.bounds.center, _boxCollider.bounds.size, 0f, Vector2.up, checkRadius, groundLayer);
    }
     public bool IsGroundedAround()
    {
        Vector2 playerPosition = new Vector2(_px,_py);

        
        Collider2D[] colliders = Physics2D.OverlapCircleAll(playerPosition, checkRadius, groundLayer);

        
        return colliders.Length > 0;
    }

    //RotatePlayer

    public void PlayerRotate(float index)
    {

        _isRight = !_isRight;

        Vector3 currentScale = transform.localScale;
        currentScale.x *= -1;
        transform.localScale = currentScale;
        Vector3 currentTranform = transform.position;
       /* currentTranform.x -= index;*/
        transform.position = currentTranform;

    }
    public bool CheckRight()
    {
        if (_isRight==true) return true;
        else return false;

    }
    public bool CheckLeft()
    {
        if (_isRight != true) return true;
        else return false;

    }

    //chansge Animation
    public void ChangeAnimation()
    {
       
        if (IsGroundedDown())
        {
            if (_playerAnimation.GetSkill() == false)
            {

                if (InputController.Instance.GetVertical() <= 0)
                {
                    if (InputController.Instance.GetHorizontal() != 0)
                    {
                        _playerAnimation.PlayAnimation(_playerAnimation.GetPLayerRun());
                    }
                    else { _playerAnimation.PlayAnimation(_playerAnimation.GetPLayerIdle()); }
                }
                else 
                {
                    SetGravity(0);
                    _playerAnimation.PlayAnimation(_playerAnimation.GetPLayerJump());
                }
            }
            else {
                switch (InputController.Instance.CheckInputKeyBoard())
                {
                    case "1":
                    case "2":
                    case "3":
                    case "4":
                    case "5":
                    case "6":
                    case "7":
                    case "8":
                        Debug.Log("Skill:" + InputController.Instance.CheckInputKeyBoard());
                        _playerAnimation.PlayAnimation(_playerAnimation.GetPlayerSkill(int.Parse(InputController.Instance.CheckInputKeyBoard()),true));
                        break;
                }
               
            }
            
        }
        else
        {
            if (_playerAnimation.GetSkill() == false)
            {
                
                if (InputController.Instance.GetHorizontal() != 0)
                {
                    SetGravity(0);
                    _playerAnimation.PlayAnimation(_playerAnimation.GetPLayerFly());
                }
                else if(InputController.Instance.GetHorizontal() == 0&& InputController.Instance.GetVertical()==0)
                {
                    
                    _playerAnimation.PlayAnimation(_playerAnimation.GetPLayerFall());
                    SetGravity(1);
                }
            }
            else
            {
                _rigidbody2.bodyType = RigidbodyType2D.Static;
                switch (InputController.Instance.CheckInputKeyBoard())
                {
                    case "1":
                    case "2":
                    case "3":
                    case "4":
                    case "5":
                    case "6":
                    case "7":
                    case "8":
                        
                        _playerAnimation.PlayAnimation(_playerAnimation.GetPlayerSkill(int.Parse(InputController.Instance.CheckInputKeyBoard()), false));
                        break;
                }
            }
            
        }
      
    }

    public void SetGravity(int value)
    {
        _rigidbody2.gravityScale=value;
    }
    

}
