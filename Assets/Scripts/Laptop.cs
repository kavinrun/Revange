using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laptop : MonoBehaviour
{
    /// <summary>
    /// Ҫ��ʾ�ĵ�����Ļ
    /// </summary>
    [SerializeField]
    private GameObject screen;

    private void OnMouseDown()
    {
        screen.SetActive(!screen.activeSelf);
    }
}
