using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineTest : MonoBehaviour
{
    MeshRenderer mr;

    public Material woodMaterial;
    private Material stoneMaterial;
    public Material redMaterial;
    public Transform transformTest;
    private Coroutine matChangeCoroutine;

    private void Awake()
    {
        mr = GetComponent<MeshRenderer>();
        stoneMaterial = mr.material;
        transformTest = GetComponent<Transform>();
    }

    private void Start()
    {
        //��Ȯ�� 3�� �Ŀ� mesh renderer�� material�� woodMaterial�� �ٲٷ���
        //var enumerator = StringEnumerator();
        //while (enumerator.MoveNext()) 
        //{
        //    print(enumerator.Current);
        //}

        //List<int> intList = new List<int>() { 1,2,3 };

        //foreach (int someInt in intList) 
        //{

        //}

        //foreach (Transform someTransform in transformTest) 
        //{
        //    print(someTransform.name);
        //}

        //StartCoroutine("MaterialChange");//���ڿ��� �ڷ�ƾ�� �����ϰ� �����ϴ°��� ��������� �ʴ�.

        //�ϼ���
        //StartCoroutine("MaterialChange");

        //�����
        matChangeCoroutine = StartCoroutine(MaterialChange(redMaterial, 1f));
    }

    

    private void Update()
    {
        //if (Time.time > 3) 
        //{
        //    mr.material = woodMaterial;
        //}

        if (Input.GetButtonDown("Jump"))
        {
            mr.material = stoneMaterial;
        }

        if (Input.GetKeyDown(KeyCode.I)) 
        {
            print("�ڷ�ƾ ��ž");
            
            //�ϼ���
            //StopCoroutine("MaterialChange");

            //�ڷ�ƾ �Լ� ��ü�� ����ȭ �Ͽ� �Ķ���ͷ� �ѱ�� �ִ�.
            StopCoroutine(matChangeCoroutine);
        }

    }

    private IEnumerator<string> StringEnumerator() 
    {
        //IEnumerator�� ��ȯ�ϴ� �Լ���
        //yield return Ű���带 ����
        //���� ���������� ��ȯ �� �� �ִ�.
        yield return "a";
        yield return "b";
        yield return "c";
    }

    private IEnumerator MaterialChange(Material mat, float Interval)
    {
        while (true)
        {
            //�ڷ�ƾ�� 3�ʵ��� ����Ѵ�. 3�ʵ��� ������ ��ٸ��� ���� �ƴ϶� �׵��� null�� ��ȯ�ϸ� ��� üũ�ȴ�.
            //yield return new WaitForSeconds(Interval);
            
            yield return new WaitForSeconds(Interval);
            mr.material = mat;

        }
    }
}
