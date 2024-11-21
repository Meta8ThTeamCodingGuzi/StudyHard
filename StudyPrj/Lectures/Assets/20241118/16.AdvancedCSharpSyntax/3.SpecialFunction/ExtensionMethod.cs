using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtensionMethod : MonoBehaviour
{
    //Ư�� ��Ҹ� �Ķ���� ��� .�տ� �����Ͽ� ��ġ �ش� ��ü�� ���� �޼ҵ��ΰ�ó�� ����ϴ� ���
    private void Start()
    {
        StringHelper.StaticMethod();
        string a = StringHelper.Append("��", "��");
        print(a);
        print("��".Append("��"));
        
        DateTime today = DateTime.Now;
        DateTime nextWeek = DateTime.Parse("2024�� 11�� 25��");

        print($"To1 : {today.To(nextWeek)}");
        print($"To2 : {today.To2(nextWeek)}");
        print($"To3 : {today.To3(nextWeek)}");
        print($"To4 : {today.To4(nextWeek)}");

        print(today.ToString(@"yyyy�� M�� dd�� HH�� mm�� ss��"));
    }
}

//static Ŭ���� : ���� ��ü�� �������� �ʾƵ� data ������ ������ �޼����� ���Ǹ� ���ϰ� �ִ� Ŭ����.
public static class StringHelper 
{
    public static void StaticMethod() 
    {
    }

    //static �޼����� ù �Ķ���� �տ� this Ű���尡 ������ . �ش� �Ķ���ʹ� .�Լ� �տ� �����Ͽ� Ȱ���Ҽ� �ִ�.
    public static string /*prefix.*/Append(this string prefix , string suffix) 
    {
        return prefix + suffix;
    }
}

public static class DateTimeHelper
{
    // ��� 1: string.Format ���
    public static string To(this DateTime start, DateTime end)
    {
        TimeSpan diff = end - start;
        return string.Format("{0:%d}�� {0:%h}�ð� {0:%m}�� {0:%s}��", diff);
    }
    
    // ��� 2: DateTime�� ToString Ŀ���� ���� ���
    public static string To2(this DateTime start, DateTime end)
    {
        return end.Subtract(start).ToString(@"dd\��\ hh\��\��\ mm\��\ ss\��");
    }

    // ��� 3: TimeSpan.FromXXX �޼��� Ȱ��
    public static string To3(this DateTime start, DateTime end)
    {
        TimeSpan diff = end - start;
        return TimeSpan.FromTicks(diff.Ticks).ToString(@"d\��\ h\��\��\ m\��\ s\��");
    }

    // ��� 4: CultureInfo Ȱ��
    public static string To4(this DateTime start, DateTime end)
    {
        var culture = new System.Globalization.CultureInfo("ko-KR");
        return (end - start).ToString("g", culture);
    }

}