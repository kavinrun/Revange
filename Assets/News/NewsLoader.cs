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
        LoadNews(level);
        return News;
    }

    private static void LoadNews(int level)
    {
        var titles = TitleOptions.Where(t => t.LevelId.EndsWith(level.ToString())).ToArray();
        News = titles.Select(t =>
        {
            var paragraphs = ParagraphOptions
            .Where(p => p.LevelId.EndsWith(level.ToString()) && p.OptionId.StartsWith("news" + t.Id));
            return new News()
            {
                Title = t,
                Score = t.Score,
                LevelId = t.LevelId,
                Options = paragraphs
                .GroupBy(p => p.OptionId[p.OptionId.Length-2])
                .OrderBy(g => g.Key)
                .Select(g => g.OrderBy(o => o.OptionId.Last()).ToArray())
                .ToArray(),
            };
        }).ToArray();
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
                Id = columns[0],
                LevelId = columns[1],
                Score = int.Parse(columns[3]),
                Title = columns[4],
            };
        }).ToArray();
    }
}

