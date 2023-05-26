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
    private TextAsset titlesFile;
    [SerializeField]
    private TextAsset optionsFile;
    [SerializeField]
    private NewsThumbnail newsThumbnailPrefab;
    [SerializeField]
    private int level;
    private News[] news;
    private void OnMouseDown()
    {
        screen.SetActive(!screen.activeSelf);
        if (news == null && screen.activeSelf)
        {
            LoadNews();
        }
    }

    private void LoadNews()
    {
        NewsLoader.TitleOptionsFile = titlesFile;
        NewsLoader.ParagraphOptionsFile = optionsFile;
        news = NewsLoader.Load(level);
        foreach (var n in news)
        {
            var thumb = Instantiate(newsThumbnailPrefab, contentPanel.transform);
            thumb.News = n;
        }
    }
}
