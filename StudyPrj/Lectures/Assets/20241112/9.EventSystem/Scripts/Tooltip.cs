using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class Tooltip : MonoBehaviour
{
    public TextMeshProUGUI text;

    public void SetData(ShapeData data) 
    {
        StringBuilder sb = new StringBuilder();
        
        sb.Append("<color=red>");
        sb.Append("Shape : ");
        sb.Append(data.shape);
        sb.AppendLine("</color>");
        
        sb.Append("<color=green>");
        sb.Append("Scale : ");
        sb.Append(data.Scale);
        sb.AppendLine("</color>");

        sb.Append($"<color={data.color.ToString()}>");
        sb.Append("Color : ");
        sb.Append(data.color);
        sb.AppendLine("</color>");

        text.text = sb.ToString();
    }
}
