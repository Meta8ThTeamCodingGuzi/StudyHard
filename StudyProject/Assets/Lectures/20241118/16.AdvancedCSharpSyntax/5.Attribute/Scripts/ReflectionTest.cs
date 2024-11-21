using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System;
using SAA = SuperAwesomeAttribute;

//Reflection : System.Reflection 네임스페이스에 포함된 기능 전반.
//컴파일 타임에서 생성된 클래스 , 메서드 , 멤버변수 등 여러 컨텍스트에 대한 데이터를
//색인하고 취급하는 기능
//Attribute는 컴파일 타임에서 생성하는 메타데이터이므로 리플렉션을 통해 데이터를 가져올 수 있다.

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
        //먼저 attTest의 타입을 확인
        MonoBehaviour attTestBoxingForm = attTest; //암시적으로 업캐스팅
        Type attTestType = attTestBoxingForm.GetType();
        print(attTestType);

        //AttributeTest 라는 클래스의 데이터를 확인
        BindingFlags bind = BindingFlags.Public | BindingFlags.Instance;
        //public 으로 접근이 가능한 동시에 static이 아니라 객체별로 생성할 요소들(field 또는 property)
        //attTestType : attTest의 GetType을 통해 클래스 명세에 대한 데이터를 가지고 있음
        FieldInfo[] fieldInfos = attTestType.GetFields(bind);
        foreach (FieldInfo fieldInfo in fieldInfos) 
        {
            SAA attribute = fieldInfo.GetCustomAttribute<SAA>();
            print($"{fieldInfo.Name}의 타입은 {fieldInfo.FieldType}");
            if (attribute is null) 
            {
                print($"{fieldInfo.Name} 에는 SAA가 없습니다 ");
                continue;
            }
            print($"{fieldInfo.Name}에는 SAA가 있다");
            print($"{attribute.getAwesomeMsg} ,  {attribute.msg}");
            print($"{fieldInfo.GetValue(attTest)}");
        }
    }
}

