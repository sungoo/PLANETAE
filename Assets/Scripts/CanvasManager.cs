using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Device;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using Yarn.Unity;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] private BackGroundManager BackGroundManager;
    [SerializeField] private CharacterManager CharacterManager;

    [SerializeField] private DialogueRunner DialogueRunner;
    [SerializeField] private LinePresenter LinePresenter;

    [SerializeField] private PlayableDirector[] Events;

    private void Awake()
    {
        // Background
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
        // Character
        DialogueRunner.AddCommandHandler<bool>(
            "AutoDial",
            AutoAdvenceDial
        );
        DialogueRunner.AddCommandHandler<bool>(
            "Gabble",
            Gabble
        );
        DialogueRunner.AddCommandHandler<bool>(
            "AutoSpeakerChange",
            SetAutoChChange
        );
        //Event
        DialogueRunner.AddCommandHandler(
            "LookUp",
            MoveBG
        );
        DialogueRunner.AddCommandHandler(
            "Shake",
            Shake
        );
        DialogueRunner.AddCommandHandler(
            "ResetBG",
            ResetBG
        );
        DialogueRunner.AddCommandHandler<int>(
            "Play",
            PlayEvent
        );
    }
    // Background
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

    // Character
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

    public void SetAutoChChange(bool isOn)
    {
        CharacterManager.AutoSpeakerChange(isOn);
    }

    // Events
    public void MoveBG()
    {
        BackGroundManager.MoveBG_UP();
    }

    public void Shake()
    {
        BackGroundManager.Shake(); 
    }
    public void ResetBG()
    {
        BackGroundManager.ResetBG(); 
    }

    public void PlayEvent(int index)
    {
        if(index >= Events.Length)
        {
            Debug.Log("Wrong Event index");
            return;
        }
        Events[index].Play();
    }
}
