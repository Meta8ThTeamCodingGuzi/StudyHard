using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A
{    
    //명시적 캐스팅을 한다면 정의되어있는 연산자를 먼저 호출하게 된다.
    public static implicit operator GameObject(A a) => GameObject.Find("A");
    //public static object operator ==(A a, object b) { return true; }
    //public static object operator !=(A a, object b) { return false; }
}
public class B : A { }
public class IsAs : MonoBehaviour
{
    //is as : 참조타입의 캐스팅(형변환) 과 관련이 있다.
    private void Start()
    {
    }

    private static void IsOut()
    {
        
        /*is : as 가 직접 캐스팅한 객체가 결과로 오는 대신 , 
         * 캐스팅 가능한지 여부만 true / false로 연산
         */
        A a = new A();
        B b = a as B;
        print(a is A);
        print(b is A);

        print(b is null);
        //== 연산자보다 효율적.
        //대신 사용자 정의 연산자를 사용 못한다.
        print(b == null);
    }

    private static void AsCasting()
    {
        /* as 키워드 : ()를 사용한 명시적 캐스팅과는 달리 캐스팅 불가능 하더라도 
         * Exception을 내뱉지 않고 대신 null을 반환하며
         * ()를 사용한 명시적 캐스팅보다 효율적 연산
         * 대신 사용자 정의 명시적 및 암시적 변환 연산자를 사용하지 않는다.*/

        A a = new A();
        B b = a as B;

        print(b?.GetType().ToString() ?? "b is null");
    }
}
