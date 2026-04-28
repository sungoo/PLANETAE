using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BackGroundManager : MonoBehaviour
{
    public RawImage bgScreen;

    public Image FadeScreen;
    public Image FlashScreen;

    [SerializeField] private BG[] bgs;

    private Rect regularRect;
    private Rect longRect;

    public void FadeIn(float fadeTime)
    {
        StartCoroutine(Fade(1.0f,0.0f,fadeTime, FadeScreen));
    }
    public void FadeOut(float fadeTime)
    {
        StartCoroutine(Fade(0.0f,1.0f,fadeTime, FadeScreen));
    }

    public void Flash()
    {
        //FlashScreen.color = color;
        StartCoroutine(Fade(0.0f, 1.0f, 0.1f, FlashScreen));
        StartCoroutine(Fade(1.0f, 0.0f, 0.1f, FlashScreen));
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

    public void ChangeBG(string str)
    {
        foreach (var bg in bgs)
        {
            if (bg.name == str)
            {
                bgScreen.texture = bg.GetTexture();
                bgScreen.uvRect = bg.GetUV();
                return;
            }
            else
            {
                bgScreen.texture = bgs[0].GetTexture();
                bgScreen.uvRect = bgs[0].GetUV();
            }
        }
    }
}
