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
        string testString = "�ȳ� �ϼ���";

        string[] splitResult = testString.Split(' ');
        printLines(
            "Split �׽�Ʈ:",
            $"ù ��° �ܾ�: {splitResult[0]}",
            $"�� ��° �ܾ�: {splitResult[1]}"
        );

        string upperCase = testString.ToUpperCase();
        string lowerCase = testString.ToLowerCase();


        printLines(
            "��ҹ��� ��ȯ �׽�Ʈ:",
            $"�빮��: {upperCase}",
            $"�ҹ���: {lowerCase}"
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