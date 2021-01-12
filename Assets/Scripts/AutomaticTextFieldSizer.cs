using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AutomaticTextFieldSizer : MonoBehaviour
{
    private TMP_Text tmpText;
    private Rect startRect;
    private RectTransform rectTransform;
    
    private void Awake()
    {
        TryGetComponent(out rectTransform);
        startRect = rectTransform.rect;
        TryGetComponent(out tmpText);
        tmpText.OnPreRenderText += TmpTextOnOnPreRenderText;
    }

    private void TmpTextOnOnPreRenderText(TMP_TextInfo obj)
    {
        if (tmpText.text==".")
        {
            rectTransform.sizeDelta = new Vector2(rectTransform.rect.size.x,0);
        }
        else
        {
            rectTransform.sizeDelta = startRect.size;
        }
    }
}
