using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Player : MonoBehaviour
{
    private static Player instance;
    public static Player Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Player>();
            }
            return instance;
        }
    }

    public List<Skill> playerskills = new List<Skill>();

    public List<Skill> selectskill;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
            return;
        }

        selectskill = new List<Skill>(4);
        for (int i = 0; i < 4; i++)
        {
            selectskill.Add(null);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            selectskill[0].onskill();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            selectskill[1].onskill();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            selectskill[2].onskill();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            selectskill[3].onskill();
        }

    }
    public void selectskillset(skillQWER qwer, Skill skill)
    {

        switch (qwer)
        {
            case skillQWER.Q:
                selectskill[0] = skill;
                break;
            case skillQWER.W:
                selectskill[1] = skill;
                break;
            case skillQWER.E:
                selectskill[2] = skill;
                break;
            case skillQWER.R:
                selectskill[3] = skill;
                break;
            default:
                break;
        }


    }
}
