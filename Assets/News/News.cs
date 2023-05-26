using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class News
{
    public string OriginalTitle { get; set; }
    public string LevelId { get; set; }
    public TitleOption[] TitleOptions { get; set; }
    public ParagraphOption[] Options { get; set; }
    public int Score { get; set; }
    public string ContentId { get; set; }
}

public class ParagraphOption
{
    public string LevelId { get; set; }
    public string OptionId { get; set; }
    public int Score { set; get; }
    public string Content { set; get; }
}

public class TitleOption
{
    public string LevelId { get; set; }
    public string Title { get; set; }
    public int Score { set; get; }
}
