﻿using System;
using System.Collections.Generic;
using System.Web;
using HtmlAgilityPack;
using RusfootballMobile.Models;

namespace RusfootballMobile.Services
{
    public class LastNewsProvider : DataProviderBase<LastNews>
    {
        public LastNewsProvider() : 
            base("https://www.rusfootball.info/lastnews")
        {
        }

        protected override IEnumerable<LastNews> ParseItems(HtmlDocument doc)
        {
            var contentNode = doc.DocumentNode.SelectSingleNode("//div[@id='contentos']");
            if (contentNode == null)
            {
                throw new Exception("Last news collection not found!");
            }

            var items = contentNode.SelectNodes("//div[@style='margin:10px 0px; border-bottom:1px solid #eee;padding:0px 15px; padding-bottom:10px;']");

            foreach (var story in items)
            {
                var shortStory = new LastNews();
                var innerDoc = new HtmlDocument();
                innerDoc.LoadHtml(story.InnerHtml);

                var innerHtml = innerDoc.DocumentNode;
               
                var ahref = innerHtml.SelectSingleNode("//a");
                shortStory.IsStrong = ahref.ParentNode.Name == "strong";
                shortStory.Title = HttpUtility.HtmlDecode(ahref.InnerHtml);
                shortStory.Details = new Uri(ahref.Attributes["href"].Value);
                var date = HttpUtility.HtmlDecode(innerHtml.SelectSingleNode("/small[@style='color: #999;']").InnerHtml);
                shortStory.Date = date;
                yield return shortStory;
            }
        }
    }
}