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
