using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UGUIInteraction : MonoBehaviour
{
    //Button ������Ʈ�� OnClick() �̺�Ʈ�� �Ҵ��Ͽ� �ش� ��ư�� Ŭ���ɶ����� ȣ�� �ǵ���.
    //"����Ƽ ������" Inspector�� �Ҵ�� ��� �������� �������ش�.
    //Inspector���� �ش� �Լ��� �����Ϸ��� ���� �����ڰ� public �̿��� �Ѵ�.
    public void ButtonClick() //�� �Լ��� ��ư�� Ŭ���ɶ� ȣ��
    {
        print("��ư Ŭ����.");
    }

    public void ButtonClickWithParameter(string param) 
    {
        print($"��ư Ŭ����. �Ķ���� : {param}");
    }

    public void ButtonClickWithFloatParam(float param) 
    {
        print($"��ư Ŭ����. �Ķ���� : {param}");
    }

    public void ButtonClickWithBool(bool param) 
    {
        print($"��ư Ŭ����. �Ķ���� : {param}");
    }
}
