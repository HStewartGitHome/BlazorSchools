namespace WpfSchools.Client.Models
{
    public interface IPageDataModel
    {
        string[] Content { get; set; }
        bool HasContent { get; set; }
        bool HasHeader { get; set; }
        bool HasMessage { get; set; }
        string Header { get; set; }
        string Message { get; set; }
        string Title { get; set; }
        int ContentFontSize { get; set; }
    }
}