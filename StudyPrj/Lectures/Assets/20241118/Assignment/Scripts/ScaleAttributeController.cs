using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class ScaleAttributeController : MonoBehaviour
{
    private void Start()
    {
        BindingFlags bind = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;

        MonoBehaviour[] monoBehaviours = FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None);

        foreach (MonoBehaviour mono in monoBehaviours)
        {
            Type type = mono.GetType();

            IEnumerable<FieldInfo> scaleAttribute = type.GetFields(bind).Where(
                x => x.HasAttribute<ScaleAttribute>()
                );
            foreach (FieldInfo fieldInfo in scaleAttribute)
            {
                ScaleAttribute att = fieldInfo.GetCustomAttribute<ScaleAttribute>();
                object value = fieldInfo.GetValue(mono);

                if (value is Transform trs)
                {
                    trs.localScale = att.size;
                }
                else if (value is RectTransform rtrs)
                {
                    rtrs.sizeDelta = att.size;
                }
                else
                {
                    Debug.LogError("not Compatible");
                }
            }
        }
    }
}

[AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
public class ScaleAttribute : Attribute
{
    public Vector3 size;
    public ScaleAttribute(float x = 0f, float y = 0f, float z = 0f)
    {
        size = new Vector3(x, y, z);
    }
}