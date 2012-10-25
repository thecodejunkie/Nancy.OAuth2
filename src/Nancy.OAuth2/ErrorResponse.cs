namespace Nancy.OAuth2
{
    public class ErrorResponse
    {
        public string Error { get; set; }

        public string Error_Description { get; set; }

        public string State { get; set; }
    }
}