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
    /// <summary>
    /// ��ʾ����Ԥ����Content rect��λ��ScrollView��Viewport֮��
    /// </summary>
    [SerializeField]
    private GameObject contentPanel;
    /// <summary>
    /// �����ļ�
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
