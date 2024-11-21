using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

//enum : Int�� ������ ���谡 ����.
public enum State 
{
    Idle = -1,
    Move = -2,
    Attack = 8,
    Die
}

[Flags] 
//Enum �տ� Flags Attribute�� �߰��� ���
//�ش� Enum�� �ߺ� ������ ������ Bit Select ���·� ��� ����
//���� : Flags Attribute�� ������ Enum�� �� �׸��� ����
//1�� 1���� ��Ʈ ������ ���� �ƴ� ��� ���� �۵� ���� �ʴ´�.
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
        //  or | (��Ʈ������ or ����)
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