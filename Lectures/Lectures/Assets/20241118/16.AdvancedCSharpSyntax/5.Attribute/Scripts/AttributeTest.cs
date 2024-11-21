using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEditor.VersionControl;
using UnityEngine;



//Attribute : 사전적 의미 속성 , 특성 , 형질
//C#에서의 Attribute : 특정 컨텍스트(클래스 정의 , 함수 정의 , 변수의 선언)에 대한 
//컴파일 타임에서 주어지는 메타데이터

public class AttributeTest : MonoBehaviour
{
    //[SerializeField] private int imPrivate;
    //public MyColor color;

    //Attribute 사용법 : 대상 컨텍스트 앞에 [] 사이에 Attribute 클래스를 상속한
    //클래스의 이름 (에서 Attribute를 뺀 이름)을 적으면 된다
    [TextArea(1,7)] public string someText;
    [SuperAwesome(getAwesomeMsg = "ggg" , msg = "bbb")] public int awesomeInt; 
}
//개발자가 작성한 커스텀 어트리뷰트(System.Attribute를 상속한 클래스)앞에
//AttributeUsageAttribute라는 어트리뷰트를 추가하여 해당 어트리뷰트의 사용을 제한하거나 추가 설정이 가능하다.
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