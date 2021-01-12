using TMPro;
using UnityEngine;

[ExecuteInEditMode]
public class TMPTextSizeFitter : MonoBehaviour
{
    private TMP_Text tmpText;
    private RectTransform rectTransform;
    private float lineLenght = 50;

    private void Awake()
    {
        TryGetComponent(out tmpText);
        TryGetComponent(out rectTransform);
        lineLenght = rectTransform.sizeDelta.x;
        tmpText.OnPreRenderText += TmpTextOnOnPreRenderText;
    }

    private void TmpTextOnOnPreRenderText(TMP_TextInfo obj) => rectTransform.sizeDelta = new Vector2(lineLenght, tmpText.textBounds.size.y);
}