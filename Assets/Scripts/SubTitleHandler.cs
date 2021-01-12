using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using Timeline;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.Serialization;

public class SubTitleHandler : MonoBehaviour
{
    public Transform parentTransform;
    [Required] public SpeakerSubTitle speakerSubTitle;

    private readonly Queue<SpeakerSubTitle> speakerSubTitles = new Queue<SpeakerSubTitle>();

    public int poolCount = 10;

    private void Awake()
    {
        for (int i = 0; i < poolCount; i++)
        {
            var newSpeakerSubTitle = Instantiate(speakerSubTitle, parentTransform);
            newSpeakerSubTitle.gameObject.SetActive(false);
            speakerSubTitles.Enqueue(newSpeakerSubTitle);
        }
    }

    private SpeakerSubTitle tmpSpeakerLine;
    public void NextInQueue(ClipTextSO inputClipTextSo, double inputTotalSpeed)
    {
        if (Application.isPlaying)
        {
            SpeakerSubTitle subTitle = speakerSubTitles.Dequeue();
            subTitle.Reset();
            subTitle.gameObject.SetActive(true);
            subTitle.InitMessage(inputClipTextSo.speakerName, inputClipTextSo.lines, (float) inputTotalSpeed);
            speakerSubTitles.Enqueue(subTitle);
        }
        else
        {
            if(tmpSpeakerLine)DestroyImmediate(tmpSpeakerLine.gameObject);
            tmpSpeakerLine = Instantiate(speakerSubTitle, parentTransform);
            tmpSpeakerLine.EditorInit(inputClipTextSo.speakerName, inputClipTextSo.lines, (float) inputTotalSpeed);
        }
    }
}