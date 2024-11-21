using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class NullableTest : MonoBehaviour
{
    //nullable 문법
    public bool isBlue;
    
    private Renderer rend;

    //리터럴 타입(값타입) 필드를 객체처럼 null 또는 주소(Instance hash)를 사용하고 싶을때
    //거의 C++의 포인터와 비슷한 형태로 쓰고 싶을때, type 뒤에 ? 붙이고 , 이를 nullable type 이라고 함.
    private int? nullableInt;

    private MyClass myClass;
    private Vector2? nullableVector; //structure도 값타입이기에 nullable로 선언이 가능하다.

    private void Awake()
    {
        rend = GetComponent<Renderer>();
    }

    private void Start()
    {
        //1. 3항 연산자 : bool ? 조건 true : 조건 false;
        rend.material.color = isBlue ? Color.blue : Color.red;

        //2. ?. ?? : null 체크 기능.
        //a. 객체?.함수(); : 객체가 null일경우 함수 호출하지 않는다.
        MyClass myClass1 = null;
        myClass1?.GetA();
        myClass1 = new MyClass() { a = 1 };
        myClass1?.GetA();

        //b-1. 객체?.참조필드: 필드가 참조타입일 경우만 가능. 객체가 null일 경우 nullreferenceexcpetion을 내뱉는 대신 그냥 null을 대입
        myClass1 = null;
        
        GameObject someObj = myClass1 ?. obj;

        print(someObj);
        
        //b-2. 객체?.참조필드??다른필드또는객체 : 객체가 null일 경우, ?? 뒤의 값이 대입 됨
        GameObject someObj2 = myClass1 ?. obj ?? new GameObject();
        print(someObj2);

        //c. 객체?.값필드??(필수)대체 값 : 객체가 null일 경우, 접근하는 필드가 리터럴 타입이라면 무조건 대체 값이 지정되야 한다.
        int someInt = myClass1 ?. a ?? 3;
        print(someInt);
        
        if(myClass1 != null) 
        {
            someObj = myClass1.obj;
        }
        else 
        {
            someObj = new GameObject();
        }

        print($"nullableInt : {nullableInt}");

        string intToText = 1.ToString();
        intToText = nullableInt?.ToString()??0.ToString();
        
        print($"intToText : {intToText}");

        nullableInt = 2;

        int localInt = 3;
        nullableInt = localInt;

        nullableInt = null; // nullable 변수에 null을 대입하여 변수를 비움.

        //변수에 접근해봤자 null이기에 접근이 안됨.
        if (nullableInt.HasValue) //명시적으로 null check. 
        {
            localInt = nullableInt.Value;
        }
        else { localInt = 0; }
        
        print(localInt);
        
        localInt = nullableInt ?? 0;
    }

    public class MyClass 
    {
        public int a;
        public GameObject obj;

        public MyClass() 
        {
            obj = new GameObject();
            obj.name = "myClass";
        }
        public int GetA() 
        {
            Debug.Log("Return A");
            return a;
        }
    }
}
