using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMove : MonoBehaviour
{
    [Header("BackGround")]
    [SerializeField] private Transform _background4;
    [SerializeField] private Transform _background3;
    [SerializeField] private Transform _background2;
    [SerializeField] private Transform _background1;
    [SerializeField] private Transform _backgroundBefore1;

    [Header("Move Background")]
    [SerializeField] private float _moveSpeedBackground4;
    [SerializeField] private float _moveSpeedBackground3;
    [SerializeField] private float _moveSpeedBackground2;
    [SerializeField] private float _moveSpeedBackground1;
    [SerializeField] private float _moveSpeedBackgroundBefore1;

    //Khởi tạo giá trị di chuyển
    [SerializeField] private float  _speedPlayerMove ;
    private float _px;
    private float _py;
    private float _move;


    void Update()
    {
        InputMouse();
        PlayerMove1();
    }
    public bool InputMouse()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 10;
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            _px = worldPosition.x;
            _py = worldPosition.y;
            return true;


        }
        else return false;


    }
    private void PlayerMove1()
    {
        if (InputMouse() == true)
        {
            PlayerMoveActive(_px, _py);
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                PlayerMoveActive(transform.position.x + _speedPlayerMove, 0);
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                PlayerMoveActive(transform.position.x - _speedPlayerMove, 0);
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                PlayerMoveActive(0, transform.position.y + _speedPlayerMove);
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                PlayerMoveActive(0, transform.position.y - _speedPlayerMove);
            }
        }
    }
    private void PlayerMoveActive(float px, float py)
    {
        transform.DOMove(new Vector3(px, py, 0), 1, false);
        _background4.DOMove(new Vector3(px * -_moveSpeedBackground4, py * -_moveSpeedBackground4 , 0), 1, false);
        _background3.DOMove(new Vector3(px * -_moveSpeedBackground3, py * -_moveSpeedBackground3, 0), 1, false);
        _background2.DOMove(new Vector3(px * -_moveSpeedBackground2, py * -_moveSpeedBackground2, 0), 1, false);
        _background1.DOMove(new Vector3(px * -_moveSpeedBackground1, py * -_moveSpeedBackground1, 0), 1, false);
        _backgroundBefore1.DOMove(new Vector3(px * -_moveSpeedBackgroundBefore1, py * -_moveSpeedBackgroundBefore1, 0), 1, false);
    }

    //vị trí nhân vật hiện tại 
    public float GetPosXPlayer() { return transform.position.x;}
    public float GetPosYPlayer() { return transform.position.y;}
    // Đặt vị trí mới cho nhân vật
    public void SetPosXPlayer(float x)
    {
        Vector3 position = transform.position;
        position.x = x;
        transform.position = position;
    }

    public void SetPosYPlayer(float y)
    {
        Vector3 position = transform.position;
        position.y = y;
        transform.position = position;
    }

    // tốc độ và tọa độ chuột
    public float GetSpeedPlayerMove() { return _speedPlayerMove; }
    public void SetSpeedPlayerMove(float speed) { _speedPlayerMove = speed; }
    public void SetPx(int i) { _px = i; }
    public float GetPx() { return _px; }
    public void SetPy(int i) { _py = i; }
    public float GetPy() { return _py; }
}
