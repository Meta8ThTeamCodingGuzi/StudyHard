//using 키워드.
//1. 외부의 라이브러리 중 내가 사용할 라이브러리를 추가.
//C/C++의 #include와 비슷하고, Java의 import와 똑같다.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using UnityEngine;
using UnityEngine.UI;
/*2. 이 텍스트 파일에서만 사용할 컨텍스트(클래스 , 구조체 , 대리자 , 인터페이스 등) 
 * 이름을 지정할 수 있다.
 */
using Random = UnityEngine.Random;

public class Using : MonoBehaviour
{
    //~ : C++의 소멸자와 같은 소멸자 자체는 C#에서도 정의가 가능하나.
    //기본적으로 IDisposable 인터페이스를 통해 Dispose()를 호출하도록 한다.
    private void Start()
    {
        /*3. IDisposable 인터페이스를 구현한 객체가 특정 블록 내에서만 동작을 한 후에
        블록 끝에서 암시적으로 메모리를 해제하도록 하는 기능*/
        using (HttpClient httpClient = new HttpClient())
        {
            /*이렇게 사용할시 블럭안에서 암시적으로 생성과 초기화가 발생하고
             *블럭을 탈출할 시 자동으로 dispose를 호출하여 메모리 해제가 발생하기에
             *블럭 바깥에서는 접근이 불가능하다.
             */
        }

        HttpClient client = new HttpClient ();
        //~~~
        client.Dispose();
    }
}
