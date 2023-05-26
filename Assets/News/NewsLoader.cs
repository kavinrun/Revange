using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

internal static class NewsLoader
{
    public static TitleOption[] TitleOptions { private set; get; }
    public static ParagraphOption[] ParagraphOptions { private set; get; }
    public static News[] News { private set; get; }

    public static TextAsset TitleOptionsFile { set; get; }
    public static TextAsset ParagraphOptionsFile { set; get; }
    public static News[] Load(int level)
    {
        if (News != null)
        {
            return News.Where(n => n.LevelId.EndsWith(level.ToString())).ToArray();
        }
        LoadTitleOptions(TitleOptionsFile);
        LoadParagraphOptions(ParagraphOptionsFile);
        return News.Where(n => n.LevelId.EndsWith(level.ToString())).ToArray();
    }

    private static void LoadParagraphOptions(TextAsset optionsFile)
    {
        var text = optionsFile.text;
        var lines = text.Split('\n').Skip(2);
        ParagraphOptions = lines.Select(l =>
        {
            var columns = l.Split(',');
            return new ParagraphOption()
            {
                LevelId = columns[1],
                OptionId = columns[2],
                Score = int.Parse(columns[3]),
                Content = columns[4],
            };
        }).ToArray();
    }

    private static void LoadTitleOptions(TextAsset titleFile)
    {
        var text = titleFile.text;
        var lines = text.Split('\n').Skip(2);
        TitleOptions = lines.Select(l =>
        {
            var columns = l.Split(',');
            return new TitleOption()
            {
                LevelId = columns[1],
                Score = int.Parse(columns[3]),
                Title = columns[4],
            };
        }).ToArray();
    }
}

