using System.Collections.Generic;
using System.Text;
using DG.Tweening;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

public class SpeakerSubTitle : MonoBehaviour
{
    public TMP_Text speaker;
    public TMP_Text message;


    public string testName;
    public string[] testText;
    public float testTime = 5;
    
    public void InitMessage(string speakerName, IEnumerable<string> newMessage, float displayTime)
    {
        speaker.text = speakerName + ": ";
        StringBuilder sb = new StringBuilder();
        foreach (var line in newMessage)
        {
            sb.AppendLine(line);
        }
        message.DOText(sb.ToString(), displayTime, true);
    }

    [Button]
    public void Test()
    {
        InitMessage(testName,testText,testTime);
    }

    public void Reset()
    {
        speaker.text = "";
        message.text = "";
    }

    public void EditorInit(string speakerName, IEnumerable<string> lines, float inputTotalSpeed)
    {
        speaker.text = speakerName + ": ";
        StringBuilder sb = new StringBuilder();
        foreach (var line in lines)
        {
            sb.AppendLine(line);
        }
        message.text = sb.ToString();
    }
}
