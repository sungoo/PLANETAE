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

    private void Awake()
    {
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
}
