using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VideoEditor : MonoBehaviour
{
    [SerializeField]
    private Button button;
    private void Start()
    {
        button.onClick.AddListener(ChangeTitle);
    }
    private void ChangeTitle()
    {

    }
}
