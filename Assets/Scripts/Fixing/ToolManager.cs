using System;
using System.Collections.Generic;
using UnityEngine;

public class ToolManager : MonoBehaviour
{
    //마우스가 든 것
    public enum MouseState
    {
        None,
        Driver, //드라이버
        Pinch,  //핀셋
        Tower,  //손수건
        WD,     //녹제거
        Buster, //화학약품
    }
    //마우스가 든 것과 대응되는 고칠부분
    public enum have2Fix
    {
        None,
        Nasa,   //나사
        Pintch, //핀셋
        Dirty,  //얼룩
        Rusky,  //녹
        Plant,  //이끼
    }
    //마우스가 든 것과 고칠 부분은 서로 1:1 대응이여야함(enum 위치가 같아야함)

    public MouseState NowHolding = MouseState.None;

    public static ToolManager Instance;

    //이벤트 수신자 목록
    private Dictionary<int, Action> Bindings = new Dictionary<int, Action>();

    private void Awake()
    {
        Debug.Log("ToolManager Started.");

        if (Instance == null)
        {
            Instance = this;
        }
        else if(Instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void ChangeTool(MouseState state)
    {
        NowHolding = state;
    }

    public bool IsHandFree()
    {
        if (NowHolding == MouseState.None)
            return true;
        else
            return false;
    }

    public int WhatAmIHolding()
    {
        return (int)NowHolding;
    }

    //이벤트 수신자 등록
    public void Subscribe(Action subscriber, int sub_num)
    {
        if (Bindings.ContainsKey(sub_num))
        {
            Debug.LogError(sub_num + "번은 이미 할당됨");
            return;
        }
        else
        {
            Debug.Log("Add Subscriber!");
            Bindings.Add(sub_num,subscriber);
        }
    }
    //이벤트 수신자 해지
    public void UnSubscribe(int sub_num)
    {
        Debug.Log("Quit Subscriber!");
        Bindings.Remove(sub_num);
    }
    //모든 수신자 해지
    public void ClearAllSubscrivers()
    {
        Bindings.Clear();
    }
    //메시지 발신
    public void BraoadCast(int toWho)
    {
        Debug.Log("Broadcast for : "+toWho);
        Bindings[toWho]();
    }
}
