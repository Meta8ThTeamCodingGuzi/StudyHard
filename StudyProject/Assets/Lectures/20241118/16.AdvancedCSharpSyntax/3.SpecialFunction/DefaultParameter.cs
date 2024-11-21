using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class DefaultParameter : MonoBehaviour
{
    public Player newPlayer;

    //�⺻ �Ű����� : �Ű������� ������ ���� �Ҵ� ���ص� �⺻������ Ư�� ���� ���� �ǵ��� �� �� ����.
    //��Ÿ���� �ƴ� ������Ÿ�ӿ��� �� �� �ִ� ���̾�� ��. (���ͷ�)
    //[��ȯ��] �Լ��̸�(Ÿ�� �Ű������� = �⺻��){}
    private void Start()
    {
        GameObject a = CreateNewObj();
        //a.name = "New Obj";

        GameObject b = CreateNewObj("New Obj2");

        //�⺻ �Ķ���Ϳ� params Ű���� �迭 �Ķ���͸� ȥ���� �ÿ� ȥ��������.
        newPlayer = CreatePlayer("Player", new int[] { 2,3,4,5,6 });
    }

    //private GameObject CreateNewObj()
    //{
    //    return new GameObject();
    //}

    private GameObject CreateNewObj(string name = "Some Obj") 
    {
        GameObject returnObject = new GameObject();
        returnObject.name = name;
        return returnObject;
    }

    //params Ű���� : �Ķ���Ϳ� �迭�� �ް� ���� ��� ,
    //�� ������ �迭 �Ķ���Ϳ� params Ű���带 �ٿ��θ�
    //�迭���� ��� ��ǥ�� �����Ͽ� �迭�� �ڵ������ϴ� �Ķ����
    private Player CreatePlayer(string name,params int[] items) 
    {
        Player returnPlayer = CreatePlayer(name);
        returnPlayer.items = items;
        return returnPlayer;
    }

    [Serializable]
    public class Player
    {
        public string name;
        public int level;
        public float damage;
        public Vector2 position;
        public GameObject rendererObject;
        public int[] items;

    }

    //ref Ÿ���� defualt �� null�� ����.
    private Player CreatePlayer(string name = "newPlayer", int level = 1,
        float damage = 1f, Vector2 position = default, GameObject obj = default)
    {
        Player returnPlayer = new Player();
        returnPlayer.name = name;
        returnPlayer.level = level;
        returnPlayer.damage = damage;
        returnPlayer.position = position;
        returnPlayer.rendererObject = obj;
        
        return returnPlayer;
    }
}