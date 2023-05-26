using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Paragraph : MonoBehaviour, IPointerClickHandler
{
    private ParagraphOption paragraphOption;
    [SerializeField]
    private Text text;
    [Category("Color")]
    [SerializeField]
    private Color negativeColor;
    [SerializeField]
    private Color neutralColor;
    [SerializeField]
    private Color positiveColor;
    public event Action<Paragraph> Clicked;
    public ParagraphOption ParagraphOption
    {
        get => paragraphOption;
        set
        {
            paragraphOption = value;
            text.text = paragraphOption.Content;
            GetComponent<Image>().color = paragraphOption.Score switch
            {
                var s when s < 0 => negativeColor,
                var s when s > 0 => positiveColor,
                _ => neutralColor,
            };
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        Clicked?.Invoke(this);

    }
}
