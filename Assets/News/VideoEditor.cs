using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VideoEditor : MonoBehaviour
{
    [SerializeField]
    private string[] paragraphs;
    [SerializeField]
    private Paragraph paragraphPrefab;
    [SerializeField]
    private GameObject optionPanel;
    [SerializeField]
    private GameObject chosenPanel;
    [SerializeField]
    private Button button;
    private void Start()
    {
        button.onClick.AddListener(ChangeTitle);
        foreach (var paragraph in paragraphs) 
        {
            var para = Instantiate(paragraphPrefab, optionPanel.transform);
            para.Clicked += ParagraphSelected;
            para.Content = paragraph;
        }
    }
    private void ParagraphSelected(Paragraph para)
    {
        para.transform.SetParent(chosenPanel.transform);
    }
    private void ChangeTitle()
    {

    }
}
