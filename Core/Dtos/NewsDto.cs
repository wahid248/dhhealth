namespace Core.Dtos
{
    public class NewsDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        private string content;
        public string Content
        {
            get { return System.Web.HttpUtility.UrlDecode(content); }
            set { content = System.Web.HttpUtility.UrlEncode(value); }
        }
        public string LargeImageUrl{ get; set; }
        public string MediumImagUrl { get; set; }
        public string SmallImageUrl{ get; set; }
    }
}
