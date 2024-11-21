using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineStarter : MonoBehaviour
{
    public PlayerTarget target;

    private void Start()
    {
        //StartCoroutine�� ȣ���ϸ� �ڷ�ƾ�� �ڵ鸵�ϴ� ��ü�� �� �ڽ��� �ǹǷ�
        //�� ���� ������Ʈ�� ��Ȱ��ȭ �ǰų� ������Ʈ�� ��Ȱ��ȭ �Ǹ�
        //���� StartCoroutine�� ���� ������ ��� �ڷ�ƾ�� ������ ����
        target.StartCoroutine(DamageOnTime());
    }

    private IEnumerator DamageOnTime() 
    {
        print($"{name} �� {target.name}���� ��Ʈ �������� �־����ϴ�");

        for (int i = 0; i < 10; i++) 
        {
            yield return new WaitForSeconds(1);
            print($"{target.name}: �ƾ�! x {i}");
        }
    }
}
