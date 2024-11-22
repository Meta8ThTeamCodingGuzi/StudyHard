using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skillclr : MonoBehaviour
{
    public Transform gg;
    public Image image;

    [SerializeField]
    private SkillIcon skillPrefab;

    private List<SkillIcon> activatedIcons;

    Action callskill;

    public skillQWER skillKey;

    private Action<Skill> onselectd;

    private void Start()
    {
        image = GetComponent<Image>();
        gg = transform.Find("Panel");
        gg.gameObject.SetActive(false);
        onselectd += selectskill;
        activatedIcons = new List<SkillIcon>();
    }
    private void selectskill(Skill skill)
    {
        image.sprite = skill.image;
        gg.gameObject.SetActive(false);
        foreach (SkillIcon icon in activatedIcons) 
        {
            PoolManager.Instance.Despawn(icon);
        }
        activatedIcons.Clear();
    }

    public void onbutton()
    {
        gg.gameObject.SetActive(true);

        if (skillPrefab == null)
        {
            Debug.LogError("SkillIcon prefab is not assigned!");
            return;
        }

        if (PoolManager.Instance == null)
        {
            Debug.LogError("PoolManager instance is null!");
            return;
        }

        foreach (Skill skill in Player.Instance.playerskills)
        {
            SkillIcon icon = PoolManager.Instance.Spawn<SkillIcon>(
                skillPrefab.gameObject,
                gg.position,
                Quaternion.identity
            );

            activatedIcons.Add(icon);

            if (icon != null)
            {
                icon.transform.SetParent(gg);
                icon.Initialize(skill, skillKey, onselectd);
            }
        }
    }
}
