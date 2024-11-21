using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class DefaultParameter : MonoBehaviour
{
    public Player newPlayer;

    //기본 매개변수 : 매개변수에 전달할 값을 할당 안해도 기본적으로 특정 값이 전달 되도록 할 수 있음.
    //런타임이 아닌 컴파일타임에서 알 수 있는 값이어야 함. (리터럴)
    //[반환형] 함수이름(타입 매개변수명 = 기본값){}
    private void Start()
    {
        GameObject a = CreateNewObj();
        //a.name = "New Obj";

        GameObject b = CreateNewObj("New Obj2");

        //기본 파라미터와 params 키워드 배열 파라미터를 혼용할 시에 혼동스럽다.
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

    //params 키워드 : 파라미터에 배열을 받고 싶은 경우 ,
    //맨 마지막 배열 파라미터에 params 키워드를 붙여두면
    //배열생성 대신 쉼표로 구분하여 배열을 자동생성하는 파라미터
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

    //ref 타입의 defualt 는 null과 같다.
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