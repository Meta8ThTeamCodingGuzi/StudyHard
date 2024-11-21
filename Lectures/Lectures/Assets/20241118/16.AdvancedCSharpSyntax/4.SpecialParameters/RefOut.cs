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
        
        //out 키워드 파라미터는 특성상 선언시 초기화 된 값이 의미가 사라지기 때문에
        //함수 호출과 같은 라인에서 선언이 가능하다
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

    /*ref 키워드 : Value Type(enum , struct , literal) 데이터를 파라미터를 통해 함수에 전달할 경우
     *메모리에 값을 복사하여 전달하는데 , 이를 포인터로 대체하는 파라미터(참조)를 선언할 경우에 사용.
     *ref 타입을 ref 키워드로 파라미터를 넘길 경우 서로의 포인터 주소 자체가 Swap*/

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
    //return은 기본적인 반환만 하고 , 추가적인 데이터는 out 파라미터로 전달된 변수에 대입하는것으로 대체
    //함수에 out 키워드가 있을 경우  해당 함수는 무조건 그 함수를 초기화 해야 한다.

    //out : 전통적이 프로그래밍 문법에서 리턴은 단 하나.
    //하지만 함수 수행 결과를 받고싶은 데이터가 여러개일 경우는 어떡하나.

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
