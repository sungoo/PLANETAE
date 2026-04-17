using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackGroundManager : MonoBehaviour
{
    public Image[] BackGrounds;
    public Image FadeScreen;
    public Image FlashScreen;

    private Dictionary<string, Image> BGdict;

    private void Start()
    {
        BGdict = new Dictionary<string, Image>();
        BGdict.Add("플라네타에 은하", BackGrounds[0]);
        BGdict.Add("워프 오류", BackGrounds[1]);
        BGdict.Add("가게 추락", BackGrounds[2]);
    }

    public void FadeIn(float fadeTime)
    {
        StartCoroutine(Fade(1.0f,0.0f,fadeTime, FadeScreen));
    }
    public void FadeOut(float fadeTime)
    {
        StartCoroutine(Fade(0.0f,1.0f,fadeTime, FadeScreen));
    }

    private IEnumerator Fade(float start, float end, float fadeTime, Image screen)
    {
        float currentTime = 0.0f;
        float percent = 0.0f;

        while (percent < 1.0f)
        {
            currentTime += Time.deltaTime;
            percent = currentTime / fadeTime;

            Color color = screen.color;
            color.a = Mathf.Lerp(start, end, percent);
            screen.color = color;

            yield return null;
        }
    }

    private void DisableAllBG()
    {
        foreach (var bg in BackGrounds)
        {
            bg.gameObject.SetActive(false);
        }
    }

    public void ChangeBG(int n)
    {
        DisableAllBG();
        BackGrounds[n].gameObject.SetActive(true);
    }
}
