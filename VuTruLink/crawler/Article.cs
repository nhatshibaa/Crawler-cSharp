namespace VuTruLink
{
    public class Article
    {
        public string Url { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }

        public override string ToString()
        {
            return $"Url: {Url}\n Title: {Title}\n Content: {Content}\n Image: {Image}";
        }

        public string ToShortString()
        {
            return $"Url: {Url}.\n Title: {Title}";
        }
    }
}