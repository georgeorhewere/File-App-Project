namespace FileManager.Services.ViewModels
{
    public class SearchSubmissionViewModel
    {
        public string Search { get; set; } = string.Empty;
        public int Page { get; set; } = 1;
        public int Take { get; set; } = 30;
    }
}