using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System;
using SAA = SuperAwesomeAttribute;

//Reflection : System.Reflection ���ӽ����̽��� ���Ե� ��� ����.
//������ Ÿ�ӿ��� ������ Ŭ���� , �޼��� , ������� �� ���� ���ؽ�Ʈ�� ���� �����͸�
//�����ϰ� ����ϴ� ���
//Attribute�� ������ Ÿ�ӿ��� �����ϴ� ��Ÿ�������̹Ƿ� ���÷����� ���� �����͸� ������ �� �ִ�.

[RequireComponent(typeof(AttributeTest))]
public class ReflectionTest : MonoBehaviour
{
    AttributeTest attTest;

    private void Awake()
    {
        attTest = GetComponent<AttributeTest>();
    }

    private void Start()
    {
        //���� attTest�� Ÿ���� Ȯ��
        MonoBehaviour attTestBoxingForm = attTest; //�Ͻ������� ��ĳ����
        Type attTestType = attTestBoxingForm.GetType();
        print(attTestType);

        //AttributeTest ��� Ŭ������ �����͸� Ȯ��
        BindingFlags bind = BindingFlags.Public | BindingFlags.Instance;
        //public ���� ������ ������ ���ÿ� static�� �ƴ϶� ��ü���� ������ ��ҵ�(field �Ǵ� property)
        //attTestType : attTest�� GetType�� ���� Ŭ���� ���� ���� �����͸� ������ ����
        FieldInfo[] fieldInfos = attTestType.GetFields(bind);
        foreach (FieldInfo fieldInfo in fieldInfos) 
        {
            SAA attribute = fieldInfo.GetCustomAttribute<SAA>();
            print($"{fieldInfo.Name}�� Ÿ���� {fieldInfo.FieldType}");
            if (attribute is null) 
            {
                print($"{fieldInfo.Name} ���� SAA�� �����ϴ� ");
                continue;
            }
            print($"{fieldInfo.Name}���� SAA�� �ִ�");
            print($"{attribute.getAwesomeMsg} ,  {attribute.msg}");
            print($"{fieldInfo.GetValue(attTest)}");
        }
    }
}

