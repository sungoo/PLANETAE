using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BackGroundManager : MonoBehaviour
{
    public enum Direct
    {
        UP,
        DOWN,
        LEFT,
        RIGHT,
    }

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

    public void MoveBG_UP()
    {
        StartCoroutine(Move(500, -500, 3.0f, Direct.UP));
    }

    public void Shake()
    {
        StartCoroutine(Move(0, 20, 0.5f, Direct.RIGHT));
        StartCoroutine(Move(20, -20, 0.5f, Direct.RIGHT));
        StartCoroutine(Move(-20, 20, 0.5f, Direct.RIGHT));
        StartCoroutine(Move(20, 0, 0.5f, Direct.RIGHT));
    }

    public void ResetBG()
    {
        bgScreen.gameObject.transform.localPosition = new Vector3(0, 500, 0);
    }

    private IEnumerator Move(float start, float end, float moveTime, Direct direct)
    {
        float currentTime = 0.0f;
        float percent = 0.0f;

        while (percent < 1.0f)
        {
            currentTime += Time.deltaTime;
            percent = currentTime / moveTime;

            float movement;
            movement = Mathf.Lerp(start, end, percent);
            switch (direct)
            {
                case Direct.UP:
                    bgScreen.transform.localPosition = new Vector3(0, movement, 0);
                    break;
                case Direct.DOWN:
                    bgScreen.transform.localPosition = new Vector3(0, -movement, 0);
                    break;
                case Direct.LEFT:
                    bgScreen.transform.localPosition = new Vector3(movement, 500, 0);
                    break;
                case Direct.RIGHT:
                    bgScreen.transform.localPosition = new Vector3(-movement, 500, 0);
                    break;
            }

            yield return null;
        }
    }
}
