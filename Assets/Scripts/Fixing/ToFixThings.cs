using UnityEngine;

public class ToFixThings : MonoBehaviour
{
    [SerializeField]
    private ToolManager.have2Fix thisTingis = ToolManager.have2Fix.None;

    public void gotClicked()
    {
        if(ToolManager.Instance.WhatAmIHolding() == (int)thisTingis)
        {
            gameObject.SetActive(false);
            //없어졌다는걸 이벤트로 쏘기
        }
    }
}
