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

    private void OnMouseDown()
    {
        screen.SetActive(!screen.activeSelf);
    }
}
