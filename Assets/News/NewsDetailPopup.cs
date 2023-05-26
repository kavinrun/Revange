using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NewsDetailPopup : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private Button button;
    [SerializeField]
    private Text titleText;
    [SerializeField]
    private Text contentText;
    [SerializeField]
    private Image popupPanel;
    [SerializeField]
    private GameObject videoEditorPrefab;
    
    private GameObject videoEditorInstance;
    private News news;
    public News News
    {
        set
        {
            news = value;
            titleText.text = news.Title.Title;
            
        }
    }
    private void Start()
    {
        button.onClick.AddListener(ButttonClicked);
    }

    private void ButttonClicked()
    {
        if (videoEditorInstance == null)
        {
            videoEditorInstance = Instantiate(videoEditorPrefab, FindObjectOfType<Canvas>().transform);
        }
        videoEditorInstance.SetActive(true);
        videoEditorInstance.GetComponent<VideoEditor>().News = news;
        gameObject.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        eventData.Use();
        if (RectTransformUtility.RectangleContainsScreenPoint(popupPanel.rectTransform, eventData.position))
        {
            return;
        }
        gameObject.SetActive(false);
    }
}
