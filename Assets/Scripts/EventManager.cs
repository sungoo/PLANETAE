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
}
