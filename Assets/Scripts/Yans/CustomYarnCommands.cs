using System;
using TMPro;
using UnityEngine;
using Yarn.Unity;

public class CustomYarnCommands : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private TMP_Text descriptionOutputText;
    [SerializeField] private TMP_Text dividerOutputText;

    [Header("Behaviour")]
    [SerializeField] private bool appendDescription = false;
    [SerializeField] private string dividerFormat = "===== {0} =====";

    private static CustomYarnCommands instance;

    private void Awake()
    {
        instance = this;
    }

    private void OnDestroy()
    {
        if (instance == this)
        {
            instance = null;
        }
    }

    [YarnCommand("description_cue")]
    public static void DescriptionCue(string[] args)
    {
        var text = string.Join(" ", args);

        if (instance == null)
        {
            Debug.LogWarning($"description_cue called, but no {nameof(CustomYarnCommands)} instance exists in the scene.");
            return;
        }

        if (instance.descriptionOutputText == null)
        {
            Debug.LogWarning("description_cue called, but Description Output Text is not assigned.");
            return;
        }

        if (instance.appendDescription && !string.IsNullOrEmpty(instance.descriptionOutputText.text))
        {
            instance.descriptionOutputText.text += Environment.NewLine + text;
        }
        else
        {
            instance.descriptionOutputText.text = text;
        }
    }

    [YarnCommand("divider")]
    public static void Divider(string[] args)
    {
        var label = string.Join(" ", args);

        if (instance == null)
        {
            Debug.LogWarning($"divider called, but no {nameof(CustomYarnCommands)} instance exists in the scene.");
            return;
        }

        if (instance.dividerOutputText != null)
        {
            instance.dividerOutputText.text = string.Format(instance.dividerFormat, label);
        }
        else if (instance.descriptionOutputText != null)
        {
            instance.descriptionOutputText.text = string.Format(instance.dividerFormat, label);
        }
        else
        {
            Debug.LogWarning("divider called, but no TMP_Text is assigned for output.");
        }
    }

    [YarnCommand("stop")]
    public static void Stop()
    {
        if (instance == null)
        {
            Debug.LogWarning($"stop called, but no {nameof(CustomYarnCommands)} instance exists in the scene.");
            return;
        }

        if (instance.descriptionOutputText != null)
        {
            instance.descriptionOutputText.text = string.Empty;
        }

        if (instance.dividerOutputText != null)
        {
            instance.dividerOutputText.text = string.Empty;
        }
    }
}