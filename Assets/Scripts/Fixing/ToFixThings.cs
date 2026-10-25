using UnityEngine;

public class ToFixThings : MonoBehaviour
{
    [SerializeField]
    private ToolManager.have2Fix thisTingis = ToolManager.have2Fix.None;

    [Tooltip("-1 : binding 없음. / 그 외 : binding 된 것.")]
    public int itBinded = -1;

    public void gotClicked()
    {
        if(ToolManager.Instance.WhatAmIHolding() == (int)thisTingis)
        {
            gameObject.SetActive(false);
            //없어졌다는걸 이벤트로 쏘기
            if(itBinded!=-1)
            ToolManager.Instance.BraoadCast(itBinded);
        }
    }
}
