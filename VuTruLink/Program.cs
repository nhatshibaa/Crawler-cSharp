using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;

//https://dantri.com.vn
//https://vnexpress.net/the-thao
namespace VuTruLink
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding= Encoding.UTF8;
            
            //VnExpress
            VnExpressCrawl crawl = new VnExpressCrawl();
            List<string> listLinkVn = crawl.GetListLink("https://vnexpress.net/the-thao");
            for (int i = 0; i < listLinkVn.Count; i++)
            {
                Article article = crawl.CrawlDetail(listLinkVn[i]);
                Console.WriteLine(article.ToString());
            }
            
            //DanTri
            DanTriCrawl danTriCrawl = new DanTriCrawl();
            List<string> listLinkDanTri = danTriCrawl.GetListLink("https://dantri.com.vn/the-thao.htm");
            for (int i = 0; i < listLinkDanTri.Count; i++)
            {
                Article article = danTriCrawl.CrawlDetail(listLinkDanTri[i]);
                Console.WriteLine(article.ToString());
            }
        }
    }
}