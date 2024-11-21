using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//1.Delegate : �븮�� , �Լ��� �̸��� ��ü���ش�.
//���������δ� ������ Classó�� �����Ѵ�.

//delegate�� ���� ���� : [��ȯ��] ��������Ʈ �̸�(�Ķ����);
public delegate void SomeMethod(int a); //return�� ���� �Լ�(Method)
public delegate int SomeFunction(int a, int b); //return�� �ִ� �Լ�(Function)


//2.delegate : ���� �޼��� ����(����)���� Ȱ��.
public class DelegateTest : MonoBehaviour
{
    public Text text;
    private void Start()
    {
        SomeMethod myMethod = PrintInt;
        myMethod(1); //Console : 1 ���
        myMethod += CreateInt;
        myMethod(2); //Console : 2 ��� �� , 2��� �̸��� ���ӿ�����Ʈ ����
        myMethod -= PrintInt;
        myMethod(3);
        myMethod -= CreateInt;
        myMethod?.Invoke(4); //myMethod�� null�Ͻ� ȣ�� ����.

        if(myMethod != null) myMethod?.Invoke(4);

        SomeMethod delegateisclass = new SomeMethod(PrintInt);
        delegateisclass(5);

        SomeFunction idk = Plus;

        int firstReturn = idk(1, 2);
        print(firstReturn);
        idk += Multiply;
        //Function ��������Ʈ�� ���� function�� ���ؼ� ����Ҷ����� ��� �Լ��� ȣ���� ������ ���������� ������ �Լ��� return�� ��ȿ�ϰ� �ȴ�.
        int secondReturn = idk(1, 2);
        print(secondReturn);
        //idk += PlusFloat; ����

        //delegate�� ���� �޼��� Ȱ��
        SomeMethod someUnnmaedMethod = 
            delegate (int a) 
            { 
                text.text = a.ToString(); 
            };
        
        //1�� ����ȭ : delegate Ű���� ��� => �����ڷ� ��ü
        someUnnmaedMethod += (int a) => { print(a); };

        //2�� ����ȭ : �Ķ���� ������Ÿ���� ���� ����

        someUnnmaedMethod += (b) => { 
            print(b); 
            text.text = b.ToString(); 
        };

        //3�� ����ȭ : �Լ� ������ 1��(�����ݷ� ; �� 1���� ����� ���, �߰�ȣ ��� ����)
        someUnnmaedMethod += (c) => print(c);

        //�Լ� 1�� ����ȭ�� ��� return Ű������� ���� ����
        SomeFunction someUnamedFunction = (someIntA,someIntB) => Plus(someIntA,someIntB);

        someUnnmaedMethod(4);

        myMethod += someUnnmaedMethod;
        
        myMethod -= someUnnmaedMethod;

        //����޼����� ���� : �ش� �޼��带 ���Ŀ� �ٽ� �����Ҽ� ����. ���� ���������� ������ �����ϴ�.


        //string stringA = new string("");
        //string stringB = "";


        //.netFramework ���� delegate

        //1. ������ ���� �Լ�(Method) : Action
        Action nonParoamMethod = () => { };
        Action<int> intParamMethod = (a) => { };
        Action<string> stringParamMethod = (b) => { };
        Action<int, string> multiParamMethod = (c, d) => { };

        //2. ������ �ִ� �Լ� (Function) : Func
        Func<int> nonParamFunc = () => { return 3; };
        Func<int, int, string> multiParamFunc = (a, b) => { return (a + b).ToString(); };

        //3. ���ǰ˻縦 ���� ������ bool ������ ���� �Լ� : Predicate
        Predicate<int> isOne = (a) => { return a == 1; };

        //�׿�
        Comparison<Color> compare = (a, b) => { return (int)(a.a - b.a); };
    }



    private void PrintInt(int a) 
    {
        print(a);
    }

    private void CreateInt(int a) 
    {
        new GameObject().name = a.ToString();
    }

    private int Plus(int a, int b) 
    {
        return a + b;
    }

    private int Multiply(int c,int d)
    {
        return c * d;
    }

    private float PlusFloat(float e, float f) 
    {
        return e + f;
    }
}
