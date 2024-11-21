//using Ű����.
//1. �ܺ��� ���̺귯�� �� ���� ����� ���̺귯���� �߰�.
//C/C++�� #include�� ����ϰ�, Java�� import�� �Ȱ���.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using UnityEngine;
using UnityEngine.UI;
/*2. �� �ؽ�Ʈ ���Ͽ����� ����� ���ؽ�Ʈ(Ŭ���� , ����ü , �븮�� , �������̽� ��) 
 * �̸��� ������ �� �ִ�.
 */
using Random = UnityEngine.Random;

public class Using : MonoBehaviour
{
    //~ : C++�� �Ҹ��ڿ� ���� �Ҹ��� ��ü�� C#������ ���ǰ� �����ϳ�.
    //�⺻������ IDisposable �������̽��� ���� Dispose()�� ȣ���ϵ��� �Ѵ�.
    private void Start()
    {
        /*3. IDisposable �������̽��� ������ ��ü�� Ư�� ��� �������� ������ �� �Ŀ�
        ��� ������ �Ͻ������� �޸𸮸� �����ϵ��� �ϴ� ���*/
        using (HttpClient httpClient = new HttpClient())
        {
            /*�̷��� ����ҽ� ���ȿ��� �Ͻ������� ������ �ʱ�ȭ�� �߻��ϰ�
             *���� Ż���� �� �ڵ����� dispose�� ȣ���Ͽ� �޸� ������ �߻��ϱ⿡
             *�� �ٱ������� ������ �Ұ����ϴ�.
             */
        }

        HttpClient client = new HttpClient ();
        //~~~
        client.Dispose();
    }
}
