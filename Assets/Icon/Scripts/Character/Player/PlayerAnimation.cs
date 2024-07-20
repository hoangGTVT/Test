using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [Header("Animation")]
    [SerializeField] public Animator animator;
    [SerializeField] private const string PlayerIdle = "Player_Idle";
    [SerializeField] private const string PlayerRun = "Player_Run";
    [SerializeField] private const string PlayerJump = "Player_Jump";
    [SerializeField] private const string PlayerFall = "Player_Fall";
    [SerializeField] private const string PlayerFly = "Player_Fly";
    [SerializeField] private const string PlayerBlock = "Player_Block";

    [Header("SkillBase")]
    [SerializeField] private const string PlayerSkill1 = "Player_Skill1";
    [SerializeField] private const string PlayerSkill2 = "Player_Skill2";
    [SerializeField] private const string PlayerSkill3 = "Player_Skill3";
    [SerializeField] private const string PlayerSkill4 = "Player_Skill4";
    [SerializeField] private const string PlayerSkill5 = "Player_Skill5";
    [SerializeField] private const string PlayerSkill6 = "Player_Skill6";
    [SerializeField] private const string PlayerSkill7 = "Player_Skill7";
    [SerializeField] private const string PlayerSkill8 = "Player_Skill8";
    [Header("SkillFly")]
    [SerializeField] private const string PlayerSkillFly1 = "Player_SkillFly1";
    [SerializeField] private const string PlayerSkillFly2 = "Player_SkillFly2";
    [SerializeField] private const string PlayerSkillFly3 = "Player_SkillFly3";
    [SerializeField] private const string PlayerSkillFly4 = "Player_SkillFly4";
    [SerializeField] private const string PlayerSkillFly5 = "Player_SkillFly5";
    [SerializeField] private const string PlayerSkillFly6 = "Player_SkillFly6";
    [SerializeField] private const string PlayerSkillFly7 = "Player_SkillFly7";
    [SerializeField] private const string PlayerSkillFly8 = "Player_SkillFly8";
    [Header("Check")]
    [SerializeField] public bool _isSkill;
    [SerializeField] public bool _isSkillFly;

    private void Awake()
    {
        _isSkill = false;
        DOTween.SetTweensCapacity(1000, 100);
        DOTween.PlayAll();
    }
    void Start()
    {
        animator= GetComponent<Animator>();
        _isSkill = false;
    }
    private void Update()
    {
        ActiveAnimationSkill();
    }
    public void PlayAnimation(string status)
    {
        animator.Play(status);
    }

    public bool GetSkill() { return _isSkill; }
    public void SetSkill(int isSkill) {
        if (isSkill == 0)
        {
            _isSkill = true;
        }else if (isSkill == 1)
        {
            _isSkill = false;
        }
        
        
     }
    //getSet
    public string GetPLayerIdle() { return PlayerIdle; }
    public string GetPLayerRun() { return PlayerRun; }
    public string GetPLayerFall() { return PlayerFall; }
    public string GetPLayerFly() { return PlayerFly; }
    public string GetPLayerBlock() { return PlayerBlock; }
    public string GetPLayerJump() { return PlayerJump; }
    public string GetPlayerSkill(int number, bool value)
    {
        if (value == true)
        {
            switch (number)
            {
                case 1:
                    return PlayerSkill1;

                case 2:
                    return PlayerSkill2;

                case 3:
                    return PlayerSkill3;

                case 4:
                    return PlayerSkill4;

                case 5:
                    return PlayerSkill5;

                case 6:
                    return PlayerSkill6;

                case 7:
                    return PlayerSkill7;

                case 8:
                    return PlayerSkill8;


                default:
                    return null;

            }
        }
        else {
            switch (number)
            {
                case 1:
                    return PlayerSkillFly1;
                case 2:
                    return PlayerSkillFly2;
                case 3:
                    return PlayerSkillFly3;
                case 4:
                    return PlayerSkillFly4;
                case 5:
                    return PlayerSkillFly5;
                case 6:
                    return PlayerSkillFly6;
                case 7:
                    return PlayerSkillFly7;
                case 8:
                    return PlayerSkillFly8;
            

                default:
                    return null;

            }
        }
        
        
    }
    public void ActiveAnimationSkill()
    {
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
                SetSkill(0);
                break;

        }
    }
    
      
}
