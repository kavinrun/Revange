using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Paragraph : MonoBehaviour, IPointerClickHandler
{
    private bool selected = false;
    [SerializeField]
    private string content;
    [SerializeField]
    private Text text;
    public event Action<Paragraph> Clicked;
    public string Content
    {
        get => content;
        set
        {
            content = value;
            text.text = value;
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        selected = true;
        Clicked?.Invoke(this);
    }
}
