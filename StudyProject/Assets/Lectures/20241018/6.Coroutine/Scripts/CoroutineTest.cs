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
        //정확히 3초 후에 mesh renderer의 material을 woodMaterial로 바꾸려면
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

        //StartCoroutine("MaterialChange");//문자열로 코루틴을 시작하고 정지하는것은 고급적이지 않다.

        //하수용
        //StartCoroutine("MaterialChange");

        //고수용
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
            print("코루틴 스탑");
            
            //하수용
            //StopCoroutine("MaterialChange");

            //코루틴 함수 자체를 변수화 하여 파라미터로 넘길수 있다.
            StopCoroutine(matChangeCoroutine);
        }

    }

    private IEnumerator<string> StringEnumerator() 
    {
        //IEnumerator를 반환하는 함수는
        //yield return 키워드를 통해
        //값을 순차적으로 반환 할 수 있다.
        yield return "a";
        yield return "b";
        yield return "c";
    }

    private IEnumerator MaterialChange(Material mat, float Interval)
    {
        while (true)
        {
            //코루틴이 3초동안 대기한다. 3초동안 실제로 기다리는 것이 아니라 그동안 null을 반환하며 계속 체크된다.
            //yield return new WaitForSeconds(Interval);
            
            yield return new WaitForSeconds(Interval);
            mr.material = mat;

        }
    }
}
