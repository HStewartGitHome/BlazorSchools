namespace WpfSchools.Client.Models
{
    public class PageDataModel : IPageDataModel
    {
        public string Title { get; set; }
        public bool HasMessage { get; set; }
        public string Message { get; set; }
        public bool HasHeader { get; set; }
        public string Header { get; set; }
        public bool HasContent { get; set; }
        public string[] Content { get; set; }
        public int ContentFontSize { get; set; }
    }
}