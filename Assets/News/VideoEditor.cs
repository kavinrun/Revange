using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VideoEditor : MonoBehaviour
{
    [SerializeField]
    private Paragraph paragraphPrefab;
    [SerializeField]
    private GameObject optionPanel;
    [SerializeField]
    private GameObject chosenPanel;
    [SerializeField]
    private Text titleText;
    [SerializeField]
    private Button button;
    private News news;
    public News News 
    { 
        set
        {
            news = value;
            titleText.text = news.Title.Title;
            LoadOptins();
        }
        get => news;
    }
    private int currentParagraph = 0;

    private void ParagraphSelected(Paragraph para)
    {
        para.transform.SetParent(chosenPanel.transform);
        FindObjectOfType<NewsScore>().Score += para.ParagraphOption.Score;
        currentParagraph++;
        LoadOptins();
    }

    private void LoadOptins()
    {
        if (currentParagraph == News.Options.Length)
        {
            foreach (Transform child in optionPanel.transform)
            {
                Destroy(child.gameObject);
            }
            button.gameObject.SetActive(true);
            print(FindObjectOfType<NewsScore>().Score);
            return;
        }
        foreach (Transform child in optionPanel.transform)
        {
            Destroy(child.gameObject);
        }
        foreach (var paragraph in News.Options[currentParagraph])
        {
            var para = Instantiate(paragraphPrefab, optionPanel.transform);
            para.Clicked += ParagraphSelected;
            para.ParagraphOption = paragraph;
        }
    }
}
