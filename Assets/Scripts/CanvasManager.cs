using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Device;
using Yarn.Unity;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] private BackGroundManager BackGroundManager;
    [SerializeField] private CharacterManager CharacterManager;

    [SerializeField] private DialogueRunner DialogueRunner;
    [SerializeField] private LinePresenter LinePresenter;

    private void Awake()
    {
        DialogueRunner.AddCommandHandler<float>(
            "Fade_In",
            FadeIn
        );
        DialogueRunner.AddCommandHandler<float>(
            "Fade_Out",
            FadeOut
        );
        DialogueRunner.AddCommandHandler<string>(
            "ChangeBG",
            ChangeBG
        );
        DialogueRunner.AddCommandHandler(
            "Flash",
            Flash
        );
        DialogueRunner.AddCommandHandler<bool>(
            "AutoDial",
            AutoAdvenceDial
        );
        DialogueRunner.AddCommandHandler<bool>(
            "Gabble",
            Gabble
        );
    }

    public void FadeIn(float t)
    {
        BackGroundManager.FadeIn(t);
    }

    public void FadeOut(float t)
    {
        BackGroundManager.FadeOut(t);
    }

    public void Flash()
    {
        BackGroundManager.Flash();
    }

    public void ChangeBG(string str)
    {
        BackGroundManager.ChangeBG(str);
    }

    public void AutoAdvenceDial(bool isON)
    {
        LinePresenter.autoAdvance = isON;
    }
    public void Gabble(bool isOn)
    {
        if (isOn)
        {
            LinePresenter.autoAdvance = isOn;
            LinePresenter.autoAdvanceDelay = 0.1f;
            LinePresenter.lettersPerSecond = 600;
        }
        else
        {
            LinePresenter.autoAdvance = isOn;
            LinePresenter.autoAdvanceDelay = 1f;
            LinePresenter.lettersPerSecond = 60;
        }
    }

}
