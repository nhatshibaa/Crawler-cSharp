using System.Collections.Generic;

namespace VuTruLink
{
    public interface Crawler
    {
        Article CrawlDetail(string url);

        List<string> GetListLink(string listUrl);
    }
}