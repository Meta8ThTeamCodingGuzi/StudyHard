using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

//Reflection�� ����Ͽ� ������Ÿ���� Attribute�� ��Ÿ�ӿ� �����ų �� �ִ�.
public class AttributeController : MonoBehaviour
{
    //Scene�� �ִ� ��� Color attribute�� ã�� ���� �����ִ� ���ҷ� �����ڸ�
    private void Start()
    {
        //Color Attribute�� ���� �ʵ带 ã��
        BindingFlags bind = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;

        MonoBehaviour[] monoBehaviours = FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None);
        
        foreach(MonoBehaviour mono in monoBehaviours) 
        {
            Type type = mono.GetType(); //Ÿ�� ������ �����´�.
            //List<FieldInfo> ColorAttributeAttachedFields = new List<FieldInfo>(type.GetFields(bind));
            //ColorAttributeAttachedFields.FindAll((x) => { return x.HasAttribute<ColorAttribute>(); });

            //����Ʈ �� Collection���� Ž����
            //Linq�� ���� ����ȭ �Ҽ��� �ִ�.
            //1.Linq���� �����ϴ� Ȯ�� �޼��� ���
            IEnumerable<FieldInfo> colorAttachedFields = type.GetFields(bind).Where(
                x => x.HasAttribute<ColorAttribute>()
                );

            //2. SQL , �������� ����� ���·ε� ����� �����ϴ�.
            colorAttachedFields = 
                from field in type.GetFields(bind) 
                where field.HasAttribute<ColorAttribute>()
                select field;

            foreach (FieldInfo fieldInfo in colorAttachedFields) 
            {
                ColorAttribute att = fieldInfo.GetCustomAttribute<ColorAttribute>();
                object value = fieldInfo.GetValue(mono);

                if(value is Renderer rend) 
                {
                    rend.material.color = att.color;
                }
                else if(value is Graphic graph) 
                {
                    graph.color = att.color;    
                }
                else
                {
                    Debug.LogError("not Compatable");
                }
            }
        }
    }
}

[AttributeUsage(AttributeTargets.Field, AllowMultiple = false , Inherited = true)]
public class ColorAttribute : Attribute 
{
    public Color color;
    public ColorAttribute(float r = 0, float g = 0, float b = 0, float a = 1) 
    {
        color = new Color(r, g, b, a);
    }
}

public static class AttributeHelper 
{
    public static bool HasAttribute<T>(this MemberInfo info) where T : Attribute 
    {
        return info.GetCustomAttributes(typeof(T), true).Length > 0;
    }
}
