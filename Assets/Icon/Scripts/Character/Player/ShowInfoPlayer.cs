using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class ShowInfoPlayer : MonoBehaviour
{
    public Character character;
    public GameObject _player;
    public TextMeshProUGUI _hp;
    public TextMeshProUGUI _mp;
    public TextMeshProUGUI _atk;
    public TextMeshProUGUI _def;
    public TextMeshProUGUI _sm;
    
    private void Start()
    {
        _player = GameObject.Find("Player");
        if(_player != null){

        }
    }

    void Update()
    {

        if (character != null)
        {
            _hp.text ="HP:"+ character.GetHpPlayer().ToString();
            _mp.text = "MP:"+character.GetMpPlayer().ToString();
            _atk.text = "ATK:"+character.GetAtk().ToString();
            _def.text = "Gender:"+character.GetGender().ToString();
            _sm.text = "DEF:"+character.GetDefence().ToString();
        }
    
    }
}
