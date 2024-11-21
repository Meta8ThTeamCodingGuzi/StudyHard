using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PrintLines : MonoBehaviour
{
    public string[] Lines;

    public string splitLines;

    public TextMeshProUGUI resultText;

    private void Start()
    {
        string testString = "안녕 하세요";

        string[] splitResult = testString.Split(' ');
        printLines(
            "Split 테스트:",
            $"첫 번째 단어: {splitResult[0]}",
            $"두 번째 단어: {splitResult[1]}"
        );

        string upperCase = testString.ToUpperCase();
        string lowerCase = testString.ToLowerCase();


        printLines(
            "대소문자 변환 테스트:",
            $"대문자: {upperCase}",
            $"소문자: {lowerCase}"
        );
    }

    public void printLines(params string[] lines)
    {
        resultText.text = "";
        foreach (string line in lines)
        {
            resultText.text += line + "\n";
        }
    }
}