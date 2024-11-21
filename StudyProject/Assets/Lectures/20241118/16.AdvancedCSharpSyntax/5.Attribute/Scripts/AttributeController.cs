using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

//Reflection을 사용하여 컴파일타임의 Attribute를 런타임에 적용시킬 수 있다.
public class AttributeController : MonoBehaviour
{
    //Scene에 있는 모든 Color attribute를 찾아 색을 입혀주는 역할로 만들자면
    private void Start()
    {
        //Color Attribute를 가진 필드를 찾자
        BindingFlags bind = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;

        MonoBehaviour[] monoBehaviours = FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None);
        
        foreach(MonoBehaviour mono in monoBehaviours) 
        {
            Type type = mono.GetType(); //타입 정보를 가져온다.
            //List<FieldInfo> ColorAttributeAttachedFields = new List<FieldInfo>(type.GetFields(bind));
            //ColorAttributeAttachedFields.FindAll((x) => { return x.HasAttribute<ColorAttribute>(); });

            //리스트 등 Collection에서 탐색은
            //Linq를 통해 간소화 할수도 있다.
            //1.Linq에서 제공하는 확장 메서드 사용
            IEnumerable<FieldInfo> colorAttachedFields = type.GetFields(bind).Where(
                x => x.HasAttribute<ColorAttribute>()
                );

            //2. SQL , 쿼리문과 비슷한 형태로도 사용이 가능하다.
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
