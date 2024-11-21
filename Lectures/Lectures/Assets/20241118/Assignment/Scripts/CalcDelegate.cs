using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;

public class CalcDelegate : MonoBehaviour
{
    public TMP_InputField a;
    public TMP_InputField b;
    public TextMeshProUGUI resultText;

    public delegate float Operation(float a , float b);
    public Operation currentOperation;

    private void Start()
    {
        currentOperation = null;
        resultText.text = "결과";
    }

    public void SetAddButton() 
    {
        currentOperation = Add;
    }

    public void SetMinusButton() 
    {
        currentOperation = Minus;
    }

    public void SetMultiplyButton() 
    {
        currentOperation = Multiply;
    }

    public void SetDivideButton() 
    {
        currentOperation = Divide;
    }

    public float Add(float a, float b) 
    {
        return a + b;
    }

    public float Minus(float a,float b) 
    {
        return a - b;
    }

    public float Multiply(float a,float b) 
    {
        return a * b;
    }

    public float Divide(float a, float b) 
    {
        return a / b;
    }

    public void Calc()
    {
        if (currentOperation == null)
        {
            resultText.text = "연산자를 선택하세요";
            return;
        }
        if (float.TryParse(a.text, out float num1) &&
            float.TryParse(b.text, out float num2))
        {
            float result = currentOperation.Invoke(num1, num2);

            if (float.IsNaN(result))
                resultText.text = "잘못된 계산입니다";
            else
                resultText.text = result.ToString();
        }
        else
        {
            resultText.text = "올바른 숫자를 입력하세요";
        }
    }
}
