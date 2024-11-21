using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//1.Delegate : 대리자 , 함수의 이름을 대체해준다.
//내부적으로는 일종의 Class처럼 동작한다.

//delegate의 선언 형태 : [반환형] 델리게이트 이름(파라미터);
public delegate void SomeMethod(int a); //return이 없는 함수(Method)
public delegate int SomeFunction(int a, int b); //return이 있는 함수(Function)


//2.delegate : 무명 메서드 선언(정의)으로 활용.
public class DelegateTest : MonoBehaviour
{
    public Text text;
    private void Start()
    {
        SomeMethod myMethod = PrintInt;
        myMethod(1); //Console : 1 출력
        myMethod += CreateInt;
        myMethod(2); //Console : 2 출력 후 , 2라는 이름의 게임오브젝트 생성
        myMethod -= PrintInt;
        myMethod(3);
        myMethod -= CreateInt;
        myMethod?.Invoke(4); //myMethod가 null일시 호출 안함.

        if(myMethod != null) myMethod?.Invoke(4);

        SomeMethod delegateisclass = new SomeMethod(PrintInt);
        delegateisclass(5);

        SomeFunction idk = Plus;

        int firstReturn = idk(1, 2);
        print(firstReturn);
        idk += Multiply;
        //Function 델리게이트에 여러 function을 더해서 사용할때에는 모든 함수를 호출을 하지만 마지막으로 더해진 함수만 return만 유효하게 된다.
        int secondReturn = idk(1, 2);
        print(secondReturn);
        //idk += PlusFloat; 에러

        //delegate의 무명 메서드 활용
        SomeMethod someUnnmaedMethod = 
            delegate (int a) 
            { 
                text.text = a.ToString(); 
            };
        
        //1차 간소화 : delegate 키워드 대신 => 연산자로 대체
        someUnnmaedMethod += (int a) => { print(a); };

        //2차 간소화 : 파라미터 데이터타입을 생략 가능

        someUnnmaedMethod += (b) => { 
            print(b); 
            text.text = b.ToString(); 
        };

        //3차 간소화 : 함수 내용이 1줄(세미콜론 ; 이 1개만 사용일 경우, 중괄호 사용 가능)
        someUnnmaedMethod += (c) => print(c);

        //함수 1줄 간소화의 경우 return 키워드까지 생략 가능
        SomeFunction someUnamedFunction = (someIntA,someIntB) => Plus(someIntA,someIntB);

        someUnnmaedMethod(4);

        myMethod += someUnnmaedMethod;
        
        myMethod -= someUnnmaedMethod;

        //무명메서드의 단점 : 해당 메서드를 추후에 다시 참조할수 없다. 선언 시점에서만 참조가 가능하다.


        //string stringA = new string("");
        //string stringB = "";


        //.netFramework 내장 delegate

        //1. 리턴이 없는 함수(Method) : Action
        Action nonParoamMethod = () => { };
        Action<int> intParamMethod = (a) => { };
        Action<string> stringParamMethod = (b) => { };
        Action<int, string> multiParamMethod = (c, d) => { };

        //2. 리턴이 있는 함수 (Function) : Func
        Func<int> nonParamFunc = () => { return 3; };
        Func<int, int, string> multiParamFunc = (a, b) => { return (a + b).ToString(); };

        //3. 조건검사를 위해 무조건 bool 리턴을 가진 함수 : Predicate
        Predicate<int> isOne = (a) => { return a == 1; };

        //그외
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
