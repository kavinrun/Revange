using System.Collections;
using System.Collections.Generic;
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
    private string title;
    public string Title
    {
        set
        {
            title = value;
            titleText.text = title;
        }
        get => title;
    }
    private string content;
    public string Content
    {
        set
        {
            content = value;
            contentText.text = content;
        }
        get => content;
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
