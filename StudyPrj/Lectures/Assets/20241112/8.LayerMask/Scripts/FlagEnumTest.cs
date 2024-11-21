using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

//enum : Int와 밀접한 관계가 있음.
public enum State 
{
    Idle = -1,
    Move = -2,
    Attack = 8,
    Die
}

[Flags] 
//Enum 앞에 Flags Attribute를 추가할 경우
//해당 Enum은 중복 선택이 가능한 Bit Select 형태로 사용 가능
//주의 : Flags Attribute가 부착된 Enum의 각 항목의 값은
//1에 1번만 비트 연산한 값이 아닐 경우 정상 작동 하지 않는다.
public enum Debuff 
{
    None = 0,
    Poison = 1 << 0,    //1
    Stun = 1 << 1,      //2
    Weak = 1 << 2,      //4
    Burn = 1 << 3,      //8
    Curse = 1 << 4,     //16
    Every = -1
}

public class FlagEnumTest : MonoBehaviour
{
    public State state;
    public Debuff debuff;
    //public List<Debuff> debuffList;

    private void Start()
    {
        //print($"{state} : {(int)state}");
        print($"{debuff} value : {(int)debuff}");
        print($"{debuff.HasFlag(Debuff.Poison)}");

        Debuff playerDebuff = (int)Debuff.Poison + Debuff.Curse;

        Debuff cure = Debuff.Poison;
        int playerDebuffInt = (int)playerDebuff;

        //000001
        //  or | (비트연산의 or 연산)
        //001000
        //  =
        //001001
                                //10001           | 00001
        int cureint = (int)cure;//playerDebuffInt | (int)cure;
        print($"{playerDebuffInt} , {cureint}");

        Debuff curedPlayerDebuff = (Debuff)(playerDebuffInt - cureint);

        print($"{curedPlayerDebuff}");
    }
}