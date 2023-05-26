using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laptop : MonoBehaviour
{
    /// <summary>
    /// 要显示的电脑屏幕
    /// </summary>
    [SerializeField]
    private GameObject screen;
    /// <summary>
    /// 显示新闻预览的Content rect。位于ScrollView的Viewport之下
    /// </summary>
    [SerializeField]
    private GameObject contentPanel;
    /// <summary>
    /// 新闻文件
    /// </summary>
    [SerializeField]
    private TextAsset news;
    [SerializeField]
    private TextAsset titleOptions;

    private void OnMouseDown()
    {
        screen.SetActive(!screen.activeSelf);
    }

    private void LoadNews()
    {

    }
}
