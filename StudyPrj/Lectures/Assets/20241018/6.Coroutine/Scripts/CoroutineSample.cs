using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class CoroutineSample : MonoBehaviour
{

    void Start()
    {
        //StartCoroutine(ReturnNull());
        //StartCoroutine(ReturnWaitForSeconds(1f,7));
        //StartCoroutine(ReturnWaitForSecondsRealTime(1f, 7));
        //StartCoroutine(ReturnUntilWhile());
        //StartCoroutine(ReturnEndOfFrame());
        StartCoroutine(_1st());
    }

    //yield return null : 매 프레임마다 다음 yield return을 반환
    private IEnumerator ReturnNull() 
    {
        print("Return Null 코루틴이 시작되었습니다 .");
        while (true)
        {            
            yield return null;
            print($"Return Null 코루틴이 수행되었습니다 {Time.time} .");
        }
    }

    //yield return new WaitForSeconds(interval) : 코루틴이 yield return 키워드를 만나면 파라미터만큼 대기 후 수행한다.
    private IEnumerator ReturnWaitForSeconds(float interval,int count) 
    {
        print("Return Wait For Seconds 코루틴이 시작되었습니다 .");
        for (int i = 0; i < count; i++) 
        {
            yield return new WaitForSeconds(interval);
            print($"Wait For Seconds{i + 1} 번 호출됨. {Time.time}");
        }
        print("Return Wait For Seconds 코루틴 종료.");
    }

    // yield return new WaitForSecondsRealtime(interval) : WaitForSeconds와 동작은 같으나 TimeScale에 영향받지 않는다.
    private IEnumerator ReturnWaitForSecondsRealTime(float interval, int count) 
    {
        print("Return Wait For Seconds RealTime 코루틴이 시작되었습니다 .");
        for (int i = 0; i < count; i++)
        {
            yield return new WaitForSecondsRealtime(interval);
            print($"Wait For Seconds RealTime {i + 1} 번 호출됨. {Time.time}");
        }
        print("Return Wait For Seconds RealTime 코루틴 종료.");
    }

    public bool continueKey;

    private bool IsContinue() 
    {
        return continueKey;
    }
    //yield return new WaitUntil / WaitWhile (param) : 특정 조건이 True/Fasle가 될 때까지 대기
    private IEnumerator ReturnUntilWhile()
    {
        print("Return Until/While 코루틴 시작됨");
        while (true)
        {
            //new WaitUnitl : 매개변수로 넘어간 함수(대리자)의 return이 false인 동안 대기, true면 넘어감
            yield return new WaitUntil(() => continueKey);
            print("WaitUntil , ContinueKey : True");
            //new WaitWhile : 매개변수로 넘어간 함수(대리자)의 return이 true인 동안 대기, false면 넘어감
            yield return new WaitWhile(() => continueKey);
            print("WaitWhile , ContinueKey : False");
        }
    }

    //yield return new (Frame 계열) : 인 게임의 특정 프레임 뒤에 수행됨

    private IEnumerator ReturnEndOfFrame() 
    {
        //EndOfFrame : 해당 프레임의 가장 마지막까지 기다림
        yield return new WaitForEndOfFrame();
        print("End of Frame.");
        isFirstFrame = false;
    }
    private IEnumerator ReturnFixedUpdate() 
    {
        //FixedUpdate : 물리연산이 끝날 때까지 기다림
        yield return new WaitForFixedUpdate();
        print("Fixed Update");
        isFirstFrame = false;
    }

    bool isFirstFrame = false;
    private void Update()
    {
        if (isFirstFrame) 
        {
            print("Update메시지 함수 호출");
        }
    }

    private void LateUpdate()
    {
        if (isFirstFrame) 
        {
            print("LateUpdate 메세지 함수 호출");
        }
    }

    //yield return coroutine : 해당 코루틴이 끝날때까지 대기

    private IEnumerator _1st() 
    {
        print("1번째 코루틴이 시작됨");
        for (int i = 0; i < 3; i++) 
        {
            yield return new WaitForSeconds(1f);
            print($"1번째 코루틴이 {i + 1}번 수행됨");
        } ;
        yield return StartCoroutine(_2nd());
        print("1번째 코루틴 끝남");
    }

    private IEnumerator _2nd() 
    {
        print("2번째 코루틴 시작");
        print("3번째 코루틴을 시작하고 대기함");
        _3rdCoroutine = StartCoroutine(_3rd());
        yield return StartCoroutine(_3rd());
        for(int i = 0; i < 5; i++) 
        {
            yield return new WaitForSeconds(1f);
            print($"2번째 코루틴 {i + 1}번째 수행됨");
        }
        print("2번째 코루틴 끝남");
    }

    Coroutine _3rdCoroutine;

    private IEnumerator _3rd() 
    {
        print("3번째 코루틴 시작됨");
        for(int i = 0; i < 5; i++) 
        {
            yield return new WaitForSeconds(1f);
            print($"3번째 코루틴 {i + 1}번째 수행됨");
        }
        print("3번째 코루틴 끝남");
    }
}
