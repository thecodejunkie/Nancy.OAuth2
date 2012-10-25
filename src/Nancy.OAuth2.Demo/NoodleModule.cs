namespace Nancy.OAuth2.Demo
{
    using ModelBinding;
    using Nancy;
    using Security;

    public class NoodleModule : NancyModule
    {
        public NoodleModule(INoodleService service) : base("/noodle")
        {
            this.RequiresAuthentication();

            Get["/"] = parameters =>
            {
                return View["noodle/index", service];
            };

            Post["/"] = parameters =>
            {
                var model =
                    this.Bind<NoodleModel>(new[] { "Posted" });

                service.Add(model);

                return Response.AsRedirect("~/noodle");
            };
        }
    }
}