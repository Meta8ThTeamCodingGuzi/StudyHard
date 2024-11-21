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
        
        //��ų ����Ÿ ����
        //this.data = sd;
        //�̹��� ����
        this.data = sd;
        image = GetComponent<Image>();
        image.sprite = sd.image;
        QWER = skillQWER;
        selec = onselectd;
    }

    public void OnDisable()
    {
        //���� �ٳ���
        image = null;
        data = null;
        QWER = skillQWER.none;
    }

    public void OnSelect() 
    {
        //�÷��̾� ���� Ȱ��ȭ ��ų ����Ʈ�� ��ų �־����
        Player.Instance.selectskillset(QWER,data);
        selec.Invoke(data);
    }




}
