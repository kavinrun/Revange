using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NewsThumbnail : MonoBehaviour, IPointerClickHandler
{
    private News news;
    public News News 
    { 
        set
        {
            news = value;
            titleText.text = news.Title.Title;
            GetComponent<Image>().color = news.Score switch
            {
                var s when s < 0 => negativeColor,
                var s when s > 0 => positiveColor,
                _ => neutralColor,
            };
        }
        get => news;
    }
    [SerializeField]
    private Text titleText;
    [SerializeField]
    private Text contentText;
    [SerializeField]
    private NewsDetailPopup detailPopupPrefab;
    [Category("Color")]
    [SerializeField]
    private Color negativeColor;
    [SerializeField]
    private Color neutralColor;
    [SerializeField]
    private Color positiveColor;
    private NewsDetailPopup popup;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (popup == null)
        {
            var canvas = FindObjectOfType<Canvas>();
            popup = Instantiate(detailPopupPrefab, canvas.transform);
        }
        popup.News = news;
        popup.gameObject.SetActive(true);
        FindObjectOfType<NewsScore>().Score += news.Score;
    }
}
