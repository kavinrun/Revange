using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NewsThumbnail : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private string title;
    [Multiline]
    [SerializeField]
    private string content;
    [SerializeField]
    private Text titleText;
    [SerializeField]
    private Text contentText;
    [SerializeField]
    private NewsDetailPopup detailPopupPrefab;
    private NewsDetailPopup popup;

    private void Start()
    {
        titleText.text = title;
        contentText.text = content;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (popup == null)
        {
            var canvas = FindObjectOfType<Canvas>();
            popup = GameObject.Instantiate<NewsDetailPopup>(detailPopupPrefab, canvas.transform);
        }
        popup.Title = title;
        popup.Content = content;
        popup.gameObject.SetActive(true);
    }
}
