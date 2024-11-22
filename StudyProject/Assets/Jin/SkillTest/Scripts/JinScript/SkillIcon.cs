using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillIcon : MonoBehaviour
{
    
    private Skill data;
    private Image image;
    private skillQWER QWER;
    private Action<Skill> selec;
     
    public void Initialize(Skill sd,skillQWER skillQWER,Action<Skill> onselectd) 
    {
        
        //스킬 데이타 읽음
        //this.data = sd;
        //이미지 세팅
        this.data = sd;
        image = GetComponent<Image>();
        image.sprite = sd.image;
        QWER = skillQWER;
        selec = onselectd;
    }

    public void OnDisable()
    {
        //정보 다날려
        image = null;
        data = null;
        QWER = skillQWER.none;
    }

    public void OnSelect() 
    {
        //플레이어 현재 활성화 스킬 리스트에 스킬 넣어버려
        Player.Instance.selectskillset(QWER,data);
        selec.Invoke(data);
    }




}
