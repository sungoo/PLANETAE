using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EventManager : MonoBehaviour
{
    [SerializeField] private RawImage EventBG;
    [SerializeField] private TextMeshProUGUI Translate;
    [SerializeField] private TextMeshProUGUI WarpMessege;
    [SerializeField] private TextMeshProUGUI GrossyStore;

    private string[] EvMessasge = {
        "플라네타에 은하계에 도착",
        "워프 안정성 : <color=\"yellow\">양호</color>",
        "지금 플라네타에 은하계의 중심 행성 \n<color=\"grey\">포디나</color> 로 워프할까요?",
        "워프 발동 준비. \n자리에서 움직이지 마십시오.",
        "워프 안정성 : <color=\"red\">불안정</color>"
    };

    int EvMsgCnt = 0;

    public void StartCounting()
    {
        StartCoroutine(Counting());
    }
    private IEnumerator Counting()
    {
        int percent = 0;

        while (percent < 90)
        {
            percent+=3;
            Translate.text = "자동 번역 활성화 .." + percent.ToString() + "%";
            yield return new WaitForSeconds(0.05f);
        }
        while (percent >= 90 && percent < 98)
        {
            percent++;
            Translate.text = "자동 번역 활성화 .." + percent.ToString() + "%";
            yield return new WaitForSeconds(0.2f);
        }
        while (percent >= 98 && percent < 100)
        {
            percent++;
            Translate.text = "자동 번역 활성화 .." + percent.ToString() + "%";
            yield return new WaitForSeconds(0.4f);
        }
    }

    public void EvCounting()
    {
        EvMsgCnt++;
    }
    public void EvMsgUpdate()
    {
        if (EvMsgCnt >= EvMessasge.Length) return;

        WarpMessege.text = EvMessasge[EvMsgCnt];
    }
}
