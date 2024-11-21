using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A
{    
    //����� ĳ������ �Ѵٸ� ���ǵǾ��ִ� �����ڸ� ���� ȣ���ϰ� �ȴ�.
    public static implicit operator GameObject(A a) => GameObject.Find("A");
    //public static object operator ==(A a, object b) { return true; }
    //public static object operator !=(A a, object b) { return false; }
}
public class B : A { }
public class IsAs : MonoBehaviour
{
    //is as : ����Ÿ���� ĳ����(����ȯ) �� ������ �ִ�.
    private void Start()
    {
    }

    private static void IsOut()
    {
        
        /*is : as �� ���� ĳ������ ��ü�� ����� ���� ��� , 
         * ĳ���� �������� ���θ� true / false�� ����
         */
        A a = new A();
        B b = a as B;
        print(a is A);
        print(b is A);

        print(b is null);
        //== �����ں��� ȿ����.
        //��� ����� ���� �����ڸ� ��� ���Ѵ�.
        print(b == null);
    }

    private static void AsCasting()
    {
        /* as Ű���� : ()�� ����� ����� ĳ���ð��� �޸� ĳ���� �Ұ��� �ϴ��� 
         * Exception�� ������ �ʰ� ��� null�� ��ȯ�ϸ�
         * ()�� ����� ����� ĳ���ú��� ȿ���� ����
         * ��� ����� ���� ����� �� �Ͻ��� ��ȯ �����ڸ� ������� �ʴ´�.*/

        A a = new A();
        B b = a as B;

        print(b?.GetType().ToString() ?? "b is null");
    }
}
