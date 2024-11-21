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

    //yield return null : �� �����Ӹ��� ���� yield return�� ��ȯ
    private IEnumerator ReturnNull() 
    {
        print("Return Null �ڷ�ƾ�� ���۵Ǿ����ϴ� .");
        while (true)
        {            
            yield return null;
            print($"Return Null �ڷ�ƾ�� ����Ǿ����ϴ� {Time.time} .");
        }
    }

    //yield return new WaitForSeconds(interval) : �ڷ�ƾ�� yield return Ű���带 ������ �Ķ���͸�ŭ ��� �� �����Ѵ�.
    private IEnumerator ReturnWaitForSeconds(float interval,int count) 
    {
        print("Return Wait For Seconds �ڷ�ƾ�� ���۵Ǿ����ϴ� .");
        for (int i = 0; i < count; i++) 
        {
            yield return new WaitForSeconds(interval);
            print($"Wait For Seconds{i + 1} �� ȣ���. {Time.time}");
        }
        print("Return Wait For Seconds �ڷ�ƾ ����.");
    }

    // yield return new WaitForSecondsRealtime(interval) : WaitForSeconds�� ������ ������ TimeScale�� ������� �ʴ´�.
    private IEnumerator ReturnWaitForSecondsRealTime(float interval, int count) 
    {
        print("Return Wait For Seconds RealTime �ڷ�ƾ�� ���۵Ǿ����ϴ� .");
        for (int i = 0; i < count; i++)
        {
            yield return new WaitForSecondsRealtime(interval);
            print($"Wait For Seconds RealTime {i + 1} �� ȣ���. {Time.time}");
        }
        print("Return Wait For Seconds RealTime �ڷ�ƾ ����.");
    }

    public bool continueKey;

    private bool IsContinue() 
    {
        return continueKey;
    }
    //yield return new WaitUntil / WaitWhile (param) : Ư�� ������ True/Fasle�� �� ������ ���
    private IEnumerator ReturnUntilWhile()
    {
        print("Return Until/While �ڷ�ƾ ���۵�");
        while (true)
        {
            //new WaitUnitl : �Ű������� �Ѿ �Լ�(�븮��)�� return�� false�� ���� ���, true�� �Ѿ
            yield return new WaitUntil(() => continueKey);
            print("WaitUntil , ContinueKey : True");
            //new WaitWhile : �Ű������� �Ѿ �Լ�(�븮��)�� return�� true�� ���� ���, false�� �Ѿ
            yield return new WaitWhile(() => continueKey);
            print("WaitWhile , ContinueKey : False");
        }
    }

    //yield return new (Frame �迭) : �� ������ Ư�� ������ �ڿ� �����

    private IEnumerator ReturnEndOfFrame() 
    {
        //EndOfFrame : �ش� �������� ���� ���������� ��ٸ�
        yield return new WaitForEndOfFrame();
        print("End of Frame.");
        isFirstFrame = false;
    }
    private IEnumerator ReturnFixedUpdate() 
    {
        //FixedUpdate : ���������� ���� ������ ��ٸ�
        yield return new WaitForFixedUpdate();
        print("Fixed Update");
        isFirstFrame = false;
    }

    bool isFirstFrame = false;
    private void Update()
    {
        if (isFirstFrame) 
        {
            print("Update�޽��� �Լ� ȣ��");
        }
    }

    private void LateUpdate()
    {
        if (isFirstFrame) 
        {
            print("LateUpdate �޼��� �Լ� ȣ��");
        }
    }

    //yield return coroutine : �ش� �ڷ�ƾ�� ���������� ���

    private IEnumerator _1st() 
    {
        print("1��° �ڷ�ƾ�� ���۵�");
        for (int i = 0; i < 3; i++) 
        {
            yield return new WaitForSeconds(1f);
            print($"1��° �ڷ�ƾ�� {i + 1}�� �����");
        } ;
        yield return StartCoroutine(_2nd());
        print("1��° �ڷ�ƾ ����");
    }

    private IEnumerator _2nd() 
    {
        print("2��° �ڷ�ƾ ����");
        print("3��° �ڷ�ƾ�� �����ϰ� �����");
        _3rdCoroutine = StartCoroutine(_3rd());
        yield return StartCoroutine(_3rd());
        for(int i = 0; i < 5; i++) 
        {
            yield return new WaitForSeconds(1f);
            print($"2��° �ڷ�ƾ {i + 1}��° �����");
        }
        print("2��° �ڷ�ƾ ����");
    }

    Coroutine _3rdCoroutine;

    private IEnumerator _3rd() 
    {
        print("3��° �ڷ�ƾ ���۵�");
        for(int i = 0; i < 5; i++) 
        {
            yield return new WaitForSeconds(1f);
            print($"3��° �ڷ�ƾ {i + 1}��° �����");
        }
        print("3��° �ڷ�ƾ ����");
    }
}
