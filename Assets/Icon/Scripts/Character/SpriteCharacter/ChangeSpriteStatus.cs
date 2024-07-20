using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class ChangeSpriteStatus : MonoBehaviour
{
    [SerializeField] public int idClan;
    [SerializeField] public int idClanPlayer;

    [Header("Idle")]
    public GameObject[] idle;
    [Header("Run")]
    public GameObject[] run;
    [Header("Jump")]
    public GameObject[] jump;
    [Header("Block")]
    public GameObject[] block;
    [Header("Fly")]
    public GameObject[] fly;
    [Header("Fail")]
    public GameObject[] fail;
    [Header("Skill1")]
    public GameObject[] skill1;
    [Header("Skill2")]
    public GameObject[] skill2;
    [Header("Skill3")]
    public GameObject[] skill3;
    [Header("Skill4")]
    public GameObject[] skill4;
    [Header("Skill5")]
    public GameObject[] skill5;
    [Header("Skill6")]
    public GameObject[] skill6;
    [Header("Skill7")]
    public GameObject[] skill7;
    [Header("Skill8")]
    public GameObject[] skill8;
    [Header("SkillFly1")]
    public GameObject[] skillFly1;
    [Header("SkillFly2")]
    public GameObject[] skillFly2;
    [Header("SkillFly3")]
    public GameObject[] skillFly3;
    [Header("SkillFly4")]
    public GameObject[] skillFly4;
    [Header("SkillFly5")]
    public GameObject[] skillFly5;
    [Header("SkillFly6")]
    public GameObject[] skillFly6;
    [Header("SkillFly7")]
    public GameObject[] skillFly7;
    [Header("SkillFly8")]
    public GameObject[] skillFly8;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            ChangeSpriteFly(1,0);
            ChangeSpriteIdle(1, 0);
            ChangeSpriteRun(1,0);
            ChangeSpriteJump(1, 0);
        }
    }
    //get set id
    public void SetIdClan(int id) { idClan = id; }
    public int GetIdClan() { return idClan; }
    public void SetIdClanPlayer(int id) { idClanPlayer = id; }
    public int GetIdClanPlayer() { return idClanPlayer; }
    public void ChangeClan(int id,int idClanPlayer)
    {
        ChangeSpriteFly(id, idClanPlayer);
        /*ChangeSpriteIdle(id,idClanPlayer);
        ChangeSpriteRun(id, idClanPlayer);
        ChangeSpriteJump(id, idClanPlayer);
        ChangeSpriteFly(id, idClanPlayer);
        ChangeSpriteFail(id, idClanPlayer);
        ChangeSpriteBlock(id, idClanPlayer);
        ChangeSpriteSkill1(id, idClanPlayer);
        ChangeSpriteSkill2(id, idClanPlayer);
        ChangeSpriteSkill3(id, idClanPlayer);
        ChangeSpriteSkill4(id, idClanPlayer);
        ChangeSpriteSkill5(id, idClanPlayer);
        ChangeSpriteSkill6(id, idClanPlayer);
        ChangeSpriteSkill7(id, idClanPlayer);
        ChangeSpriteSkill8(id, idClanPlayer);
        ChangeSpriteSkillFly1(id, idClanPlayer);
        ChangeSpriteSkillFly2(id, idClanPlayer);
        ChangeSpriteSkillFly3(id, idClanPlayer);
        ChangeSpriteSkillFly4(id, idClanPlayer);
        ChangeSpriteSkillFly5(id, idClanPlayer);
        ChangeSpriteSkillFly6(id, idClanPlayer);
        ChangeSpriteSkillFly7(id, idClanPlayer);
        ChangeSpriteSkillFly8(id, idClanPlayer)*/
        ;
    }
    public void ChangeSpriteIdle(int idClan, int idClanPlayer)
    {
      for(int i = 0; i < idle.Length; i++)
        {
            SpriteRenderer sp = idle[i].GetComponent<SpriteRenderer>();
            sp.sprite = Resources.Load<Sprite>("Images/" +idClan+"/"+idClanPlayer+"/"+"Idle"+"/"+ (i + 1));
        }
    }
    public void ChangeSpriteRun(int idClan, int idClanPlayer)
    {
        for (int i = 0; i < run.Length; i++)
        {
            SpriteRenderer sp = run[i].GetComponent<SpriteRenderer>();
            sp.sprite = Resources.Load<Sprite>("Images/" + idClan + "/" + idClanPlayer + "/" + "Run" + "/" + (i + 1));
        }
    }
    public void ChangeSpriteJump(int idClan, int idClanPlayer)
    {
        for (int i = 0; i < jump.Length; i++)
        {
            SpriteRenderer sp = jump[i].GetComponent<SpriteRenderer>();
            sp.sprite = Resources.Load<Sprite>("Images/" + idClan + "/" + idClanPlayer + "/" + "Jump" + "/" + (i + 1));
        }
    }
    public void ChangeSpriteFly(int idClan, int idClanPlayer)
    {
        for (int i = 0; i < fly.Length; i++)
        {
            SpriteRenderer sp = fly[i].GetComponent<SpriteRenderer>();
            sp.sprite = Resources.Load<Sprite>("Images/" + idClan + "/" + idClanPlayer + "/" + "Fly" + "/" + (i + 1));
        }
    }
    public void ChangeSpriteFail(int idClan, int idClanPlayer)
    {
        for (int i = 0; i < fail.Length; i++)
        {
            SpriteRenderer sp = fail[i].GetComponent<SpriteRenderer>();
            sp.sprite = Resources.Load<Sprite>("Images/" + idClan + "/" + idClanPlayer + "/" + "Fail" + "/" + (i + 1));
        }
    }
    public void ChangeSpriteBlock(int idClan, int idClanPlayer)
    {
        for (int i = 0; i < block.Length; i++)
        {
            SpriteRenderer sp = block[i].GetComponent<SpriteRenderer>();
            sp.sprite = Resources.Load<Sprite>("Images/" + idClan + "/" + idClanPlayer + "/" + "Block" + "/" + (i + 1));
        }
    }
    //skill
    public void ChangeSpriteSkill1(int idClan, int idClanPlayer)
    {
        for (int i = 0; i < skill1.Length; i++)
        {
            SpriteRenderer sp = skill1[i].GetComponent<SpriteRenderer>();
            sp.sprite = Resources.Load<Sprite>("Images/" + idClan + "/" + idClanPlayer + "/" + "Skill1" + "/" + (i + 1));
        }
    }
    public void ChangeSpriteSkill2(int idClan, int idClanPlayer)
    {
        for (int i = 0; i < skill2.Length; i++)
        {
            SpriteRenderer sp = skill2[i].GetComponent<SpriteRenderer>();
            sp.sprite = Resources.Load<Sprite>("Images/" + idClan + "/" + idClanPlayer + "/" + "Skill2" + "/" + (i + 1));
        }
    }
    public void ChangeSpriteSkill3(int idClan, int idClanPlayer)
    {
        for (int i = 0; i < skill3.Length; i++)
        {
            SpriteRenderer sp = skill3[i].GetComponent<SpriteRenderer>();
            sp.sprite = Resources.Load<Sprite>("Images/" + idClan + "/" + idClanPlayer + "/" + "Skill3" + "/" + (i + 1));
        }
    }
    public void ChangeSpriteSkill4(int idClan, int idClanPlayer)
    {
        for (int i = 0; i < skill4.Length; i++)
        {
            SpriteRenderer sp = skill4[i].GetComponent<SpriteRenderer>();
            sp.sprite = Resources.Load<Sprite>("Images/" + idClan + "/" + idClanPlayer + "/" + "Skill4" + "/" + (i + 1));
        }
    }
    public void ChangeSpriteSkill5(int idClan, int idClanPlayer)
    {
        for (int i = 0; i < skill5.Length; i++)
        {
            SpriteRenderer sp = skill5[i].GetComponent<SpriteRenderer>();
            sp.sprite = Resources.Load<Sprite>("Images/" + idClan + "/" + idClanPlayer + "/" + "Skill5" + "/" + (i + 1));
        }
    }
    public void ChangeSpriteSkill6(int idClan, int idClanPlayer)
    {
        for (int i = 0; i < skill6.Length; i++)
        {
            SpriteRenderer sp = skill6[i].GetComponent<SpriteRenderer>();
            sp.sprite = Resources.Load<Sprite>("Images/" + idClan + "/" + idClanPlayer + "/" + "Skill6" + "/" + (i + 1));
        }
    }
    public void ChangeSpriteSkill7(int idClan, int idClanPlayer)
    {
        for (int i = 0; i < skill7.Length; i++)
        {
            SpriteRenderer sp = skill7[i].GetComponent<SpriteRenderer>();
            sp.sprite = Resources.Load<Sprite>("Images/" + idClan + "/" + idClanPlayer + "/" + "Skill7" + "/" + (i + 1));
        }
    }
    public void ChangeSpriteSkill8(int idClan, int idClanPlayer)
    {
        for (int i = 0; i < skill8.Length; i++)
        {
            SpriteRenderer sp = skill8[i].GetComponent<SpriteRenderer>();
            sp.sprite = Resources.Load<Sprite>("Images/" + idClan + "/" + idClanPlayer + "/" + "Skill8" + "/" + (i + 1));
        }
    }
    //SKillFly

    public void ChangeSpriteSkillFly1(int idClan, int idClanPlayer)
    {
        for (int i = 0; i < skillFly1.Length; i++)
        {
            SpriteRenderer sp = skillFly1[i].GetComponent<SpriteRenderer>();
            sp.sprite = Resources.Load<Sprite>("Images/" + idClan + "/" + idClanPlayer + "/" + "SkillFly1" + "/" + (i + 1));
        }
    }
    public void ChangeSpriteSkillFly2(int idClan, int idClanPlayer)
    {
        for (int i = 0; i < skillFly3.Length; i++)
        {
            SpriteRenderer sp = skillFly2[i].GetComponent<SpriteRenderer>();
            sp.sprite = Resources.Load<Sprite>("Images/" + idClan + "/" + idClanPlayer + "/" + "SkillFly2" + "/" + (i + 1));
        }
    }
    public void ChangeSpriteSkillFly3(int idClan, int idClanPlayer)
    {
        for (int i = 0; i < skillFly3.Length; i++)
        {
            SpriteRenderer sp = skillFly3[i].GetComponent<SpriteRenderer>();
            sp.sprite = Resources.Load<Sprite>("Images/" + idClan + "/" + idClanPlayer + "/" + "SkillFly3" + "/" + (i + 1));
        }
    }
    public void ChangeSpriteSkillFly4(int idClan, int idClanPlayer)
    {
        for (int i = 0; i < skillFly4.Length; i++)
        {
            SpriteRenderer sp = skillFly4[i].GetComponent<SpriteRenderer>();
            sp.sprite = Resources.Load<Sprite>("Images/" + idClan + "/" + idClanPlayer + "/" + "SkillFly4" + "/" + (i + 1));
        }
    }
    public void ChangeSpriteSkillFly5(int idClan, int idClanPlayer)
    {
        for (int i = 0; i < skillFly5.Length; i++)
        {
            SpriteRenderer sp = skillFly5[i].GetComponent<SpriteRenderer>();
            sp.sprite = Resources.Load<Sprite>("Images/" + idClan + "/" + idClanPlayer + "/" + "SkillFly5" + "/" + (i + 1));
        }
    }
    public void ChangeSpriteSkillFly6(int idClan, int idClanPlayer)
    {
        for (int i = 0; i < skillFly6.Length; i++)
        {
            SpriteRenderer sp = skillFly6[i].GetComponent<SpriteRenderer>();
            sp.sprite = Resources.Load<Sprite>("Images/" + idClan + "/" + idClanPlayer + "/" + "SkillFly6" + "/" + (i + 1));
        }

    }
    public void ChangeSpriteSkillFly7(int idClan, int idClanPlayer)
    {
        for (int i = 0; i < skillFly7.Length; i++)
        {
            SpriteRenderer sp = skillFly7[i].GetComponent<SpriteRenderer>();
            sp.sprite = Resources.Load<Sprite>("Images/" + idClan + "/" + idClanPlayer + "/" + "SkillFly7" + "/" + (i + 1));
        }
    }
    public void ChangeSpriteSkillFly8(int idClan, int idClanPlayer)
    {
        for (int i = 0; i < skillFly1.Length; i++)
        {
            SpriteRenderer sp = skillFly1[i].GetComponent<SpriteRenderer>();
            sp.sprite = Resources.Load<Sprite>("Images/" + idClan + "/" + idClanPlayer + "/" + "SkillFly8" + "/" + (i + 1));
        }
    }
}
