using UnityEngine;

public class Pannel : MonoBehaviour
{
    [Tooltip("pannel number = it binded")]
    public int pannelNumber;
    [SerializeField]
    private ToFixThings[] bindThings;
    private int bindThingsNum = 0;

    private void Start()
    {
        bindThingsNum = bindThings.Length;
        ToolManager.Instance.Subscribe(BindThingReashed, pannelNumber);
    }

    private void Update()
    {
        //toFixThings에서 이벤트 받아, bindThingsNum--
        //bindThingsNum == 0 되면 이것도 SetActive(false)
        if (bindThingsNum <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    public void BindThingReashed()
    {
        bindThingsNum--;
    }
}
