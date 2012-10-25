namespace Nancy.OAuth2.Demo
{
    using System;

    public class NoodleModel
    {
        public NoodleModel()
        {
            this.Posted = DateTime.Now;
        }

        public string Author { get; set; }

        public string Message { get; set; }

        public DateTime Posted { get; set; }
    }
}