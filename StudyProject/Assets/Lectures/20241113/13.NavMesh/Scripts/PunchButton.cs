using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class PunchButton : MonoBehaviour
{
    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();

        button.onClick.AddListener(Shake);
    }

    Tweener punchTween;

    public void Punch() 
    {
        if(punchTween != null) 
        {
            punchTween.Complete(); //Ʈ���� �������̸� Ʈ���� ������ ����
        }

        Vector3 punchSize = new Vector3(.1f,.1f,.1f); 
        punchTween = transform.DOPunchScale(punchSize , 0.5f);
    }

    Tweener shakeTween;
    public void Shake() 
    {
        if (shakeTween != null)
        {
            shakeTween.Complete(); //Ʈ���� �������̸� Ʈ���� ������ ����
        }

        shakeTween = transform.DOShakePosition(0.5f,10f,80);
    }
}
