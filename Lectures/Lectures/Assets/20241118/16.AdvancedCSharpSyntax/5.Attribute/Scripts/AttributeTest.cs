using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEditor.VersionControl;
using UnityEngine;



//Attribute : ������ �ǹ� �Ӽ� , Ư�� , ����
//C#������ Attribute : Ư�� ���ؽ�Ʈ(Ŭ���� ���� , �Լ� ���� , ������ ����)�� ���� 
//������ Ÿ�ӿ��� �־����� ��Ÿ������

public class AttributeTest : MonoBehaviour
{
    //[SerializeField] private int imPrivate;
    //public MyColor color;

    //Attribute ���� : ��� ���ؽ�Ʈ �տ� [] ���̿� Attribute Ŭ������ �����
    //Ŭ������ �̸� (���� Attribute�� �� �̸�)�� ������ �ȴ�
    [TextArea(1,7)] public string someText;
    [SuperAwesome(getAwesomeMsg = "ggg" , msg = "bbb")] public int awesomeInt; 
}
//�����ڰ� �ۼ��� Ŀ���� ��Ʈ����Ʈ(System.Attribute�� ����� Ŭ����)�տ�
//AttributeUsageAttribute��� ��Ʈ����Ʈ�� �߰��Ͽ� �ش� ��Ʈ����Ʈ�� ����� �����ϰų� �߰� ������ �����ϴ�.
[AttributeUsage(AttributeTargets.Field | AttributeTargets.Method)]
public class SuperAwesomeAttribute : Attribute 
{
    public string msg;
    public string getAwesomeMsg;

    public SuperAwesomeAttribute() 
    {
        msg = "AAA";
        getAwesomeMsg = "BBB";
    }
    public SuperAwesomeAttribute(string msg) 
    {
        this.msg = msg;
    }
}

//[Serializable]
//public class MyColor
//{
//    public float red;
//    public float green;
//    public float blue;
//    public float alpha;
//}