using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skillclr : MonoBehaviour
{
    public Transform gg;
    public Image image;

    public SkillIcon skills;

    Action callskill;

    public skillQWER skillKey;

    private Action<Skill> onselectd;



    private void Start()
    {
        image = GetComponent<Image>();
        gg = transform.Find("Panel");
        gg.gameObject.SetActive(false);
        onselectd += selectskill;
    }
    private void selectskill(Skill skill)
    {
        image.sprite = skill.image;
        gg.gameObject.SetActive(false);
    }

    public void onbutton()
    {
        gg.gameObject.SetActive(true);
        foreach (Skill skill in Player.Instance.playerskills)
        {
            SkillIcon icon = Instantiate(skills, gg);
            icon.Initialize(skill,skillKey,onselectd);
           
        }
    }
}
