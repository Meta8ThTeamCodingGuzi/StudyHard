using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtensionMethod : MonoBehaviour
{
    //특정 요소를 파라미터 대신 .앞에 참조하여 마치 해당 객체가 지닌 메소드인것처럼 사용하는 방법
    private void Start()
    {
        StringHelper.StaticMethod();
        string a = StringHelper.Append("나", "너");
        print(a);
        print("와".Append("오"));
        
        DateTime today = DateTime.Now;
        DateTime nextWeek = DateTime.Parse("2024년 11월 25일");

        print($"To1 : {today.To(nextWeek)}");
        print($"To2 : {today.To2(nextWeek)}");
        print($"To3 : {today.To3(nextWeek)}");
        print($"To4 : {today.To4(nextWeek)}");

        print(today.ToString(@"yyyy년 M월 dd일 HH시 mm분 ss초"));
    }
}

//static 클래스 : 따로 객체를 생성하지 않아도 data 영역에 변수와 메서드의 정의를 지니고 있는 클래스.
public static class StringHelper 
{
    public static void StaticMethod() 
    {
    }

    //static 메서드의 첫 파라미터 앞에 this 키워드가 붙으면 . 해당 파라미터는 .함수 앞에 참조하여 활용할수 있다.
    public static string /*prefix.*/Append(this string prefix , string suffix) 
    {
        return prefix + suffix;
    }
}

public static class DateTimeHelper
{
    // 방법 1: string.Format 사용
    public static string To(this DateTime start, DateTime end)
    {
        TimeSpan diff = end - start;
        return string.Format("{0:%d}일 {0:%h}시간 {0:%m}분 {0:%s}초", diff);
    }
    
    // 방법 2: DateTime의 ToString 커스텀 포맷 사용
    public static string To2(this DateTime start, DateTime end)
    {
        return end.Subtract(start).ToString(@"dd\일\ hh\시\간\ mm\분\ ss\초");
    }

    // 방법 3: TimeSpan.FromXXX 메서드 활용
    public static string To3(this DateTime start, DateTime end)
    {
        TimeSpan diff = end - start;
        return TimeSpan.FromTicks(diff.Ticks).ToString(@"d\일\ h\시\간\ m\분\ s\초");
    }

    // 방법 4: CultureInfo 활용
    public static string To4(this DateTime start, DateTime end)
    {
        var culture = new System.Globalization.CultureInfo("ko-KR");
        return (end - start).ToString("g", culture);
    }

}