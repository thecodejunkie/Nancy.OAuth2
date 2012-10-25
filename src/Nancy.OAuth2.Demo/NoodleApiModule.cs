namespace Nancy.OAuth2.Demo
{
    using Security;

    public class NoodleApiModule : NancyModule
    {
        public NoodleApiModule(INoodleService service) : base("/noodle/api")
        {
            this.RequiresAuthentication();

            Post["/"] = parameters => {
                service.Add(new NoodleModel
                    {
                        Author = string.Concat(Context.CurrentUser.UserName, " (from API)"),
                        Message = "This message was automatically generated when posting from the API"
                    });

                return 200;
            };
        }
    }
}