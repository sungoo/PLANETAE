using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public Canvas Narrator;
    public Canvas Dialogue;

    public void ToggleNarCanvas()
    {
        if(Narrator.gameObject.activeSelf)
            Narrator.gameObject.SetActive(false);
        else
            Narrator.gameObject.SetActive(true);
    }
    public void ToggleDialCanvas()
    {
        if(Dialogue.gameObject.activeSelf)
            Dialogue.gameObject.SetActive(false);
        else
            Dialogue.gameObject.SetActive(true);
    }
}
