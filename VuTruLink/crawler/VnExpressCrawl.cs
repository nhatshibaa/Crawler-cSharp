using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using HtmlAgilityPack;

namespace VuTruLink
{
    public class VnExpressCrawl : Crawler
    {
        public Article CrawlDetail(string url)
        {
            try
            {
                var htmlWeb = new HtmlWeb();
                var htmlDocument = htmlWeb.Load(url);
                var titleNode = htmlDocument.DocumentNode.SelectSingleNode("//h1[contains(@class, 'title-detail')]");
                var title = titleNode.InnerText;
                var contentNode = htmlDocument.DocumentNode.SelectSingleNode("//article[contains(@class, 'fck_detail')]");;
                var content = contentNode.InnerText;
                var imageNode = htmlDocument.DocumentNode.SelectSingleNode("//picture/img");
                var image = imageNode.Attributes["src"].Value;
                var article = new Article
                {
                    Title = title,
                    Content = content,
                    Image = image,
                    Url = url
                };
                return article;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public List<string> GetListLink(string urlToGetListLink)
        {
            var listLink = new List<string>();
            var htmlWeb = new HtmlWeb();
            var htmlDocument = htmlWeb.Load(urlToGetListLink);
            var listNode = htmlDocument.DocumentNode.SelectNodes("//h3[contains(@class, 'title-news')]/a");
            for (var i = 0; i < listNode.Count; i++)
            {
                var link = listNode.ElementAt(i).Attributes["href"].Value;
                listLink.Add(link);
            }
            return listLink;
        }
    }
}