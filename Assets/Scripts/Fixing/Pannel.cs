using UnityEngine;

public class Pannel : MonoBehaviour
{
    [SerializeField]
    private ToFixThings[] bindThings;
    private int bindThingsNum = 0;

    private void Start()
    {
        bindThingsNum = bindThings.Length;
    }

    private void Update()
    {
        //toFixThings에서 이벤트 받아, bindThingsNum--
        //bindThingsNum == 0 되면 이것도 SetActive(false)
    }
}
