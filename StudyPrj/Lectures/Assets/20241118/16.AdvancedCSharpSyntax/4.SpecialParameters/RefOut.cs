using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefOut : MonoBehaviour
{
    private void Start()
    {
        OutKeyword();
    }

    private void OutKeyword()
    {
        GameObject outObj1 = new GameObject("Out");

        outObj1.transform.position = new Vector3(1, 2, 3);

        GameObject outObj2 = new GameObject("Not Out");

        outObj2.transform.position = new Vector3(3, 2, 1);

        if (TryGetPosition(outObj1, out Vector3 outPos)) 
        {
            print($"OutPos : {outPos}");
        };
        if (TryGetPosition(outObj2, out Vector3 outPos2)) 
        {
            print($"OutPos : {outPos2}");
        };
        
        //out Ű���� �Ķ���ʹ� Ư���� ����� �ʱ�ȭ �� ���� �ǹ̰� ������� ������
        //�Լ� ȣ��� ���� ���ο��� ������ �����ϴ�
    }

    private void RefRefSwap()
    {
        GameObject obj1 = new GameObject("No.1");
        obj1.transform.position += new Vector3(5,0);
        GameObject obj2 = new GameObject("No.2");
        SwapName(obj1, obj2);
    }

    private void RefTypeSwap()
    {
        GameObject obj1 = new GameObject("No.1");
        GameObject obj2 = new GameObject("No.2");
        Swap(ref obj1, ref obj2);
        print($"obj 1 : {obj1.name} ,  obj 2 : {obj2.name}");
    }

    /*ref Ű���� : Value Type(enum , struct , literal) �����͸� �Ķ���͸� ���� �Լ��� ������ ���
     *�޸𸮿� ���� �����Ͽ� �����ϴµ� , �̸� �����ͷ� ��ü�ϴ� �Ķ����(����)�� ������ ��쿡 ���.
     *ref Ÿ���� ref Ű����� �Ķ���͸� �ѱ� ��� ������ ������ �ּ� ��ü�� Swap*/

    private void Swap(ref int a, ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }
    private void SwapName(GameObject obj1, GameObject obj2) 
    {
        string name = obj1.name;
        obj1.name = obj2.name;
        obj2.name = name;
    }
    private void Swap(ref GameObject obj1 , ref GameObject obj2) 
    {
        GameObject temp = obj1;
        obj1 = obj2;
        obj2 = temp;
    }
    private void ValTypeSwap()
    {
        int a = 10;
        int b = 20;
        Swap(ref a, ref b);
        print($"a : {a} , b : {b}");
    }

    /*
    //return�� �⺻���� ��ȯ�� �ϰ� , �߰����� �����ʹ� out �Ķ���ͷ� ���޵� ������ �����ϴ°����� ��ü
    //�Լ��� out Ű���尡 ���� ���  �ش� �Լ��� ������ �� �Լ��� �ʱ�ȭ �ؾ� �Ѵ�.

    //out : �������� ���α׷��� �������� ������ �� �ϳ�.
    //������ �Լ� ���� ����� �ް���� �����Ͱ� �������� ���� ��ϳ�.

    //private bool TryGetComponent(Type type out Component component)    
    //{
    //    Component comp = GetComponent(type);
    //    bool boolReturn = comp is not null;
        
    //}
    */

    private bool TryGetPosition(GameObject target , out Vector3 pos) 
    {
        if(target.name == "Out") 
        {
            pos = target.transform.position;
            return true;
        }
        else 
        {
            pos = Vector3.zero;
            return false;
        }
    }
}
