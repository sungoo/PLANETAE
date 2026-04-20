using UnityEngine;
using Yarn.Unity;

public class CanvasManager : MonoBehaviour
{
    public BackGroundManager BackGroundManager;
    public CharacterManager CharacterManager;

    public DialogueRunner DialogueRunner;

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
    }

    public void FadeIn(float t)
    {
        BackGroundManager.FadeIn(t);
    }

    public void FadeOut(float t)
    {
        BackGroundManager.FadeOut(t);
    }

    public void ChangeBG(string str)
    {
        BackGroundManager.ChangeBG(str);
    }
}
