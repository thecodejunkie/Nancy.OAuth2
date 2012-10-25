namespace Nancy.OAuth2
{
    using ModelBinding;

    public class TokenModule : NancyModule
    {
        public TokenModule(ITokenEndPointService service) : base("/oauth/token")
        {
            Get["/"] = parameters => {
                var request =
                    this.Bind<TokenRequest>();

                return 200;
            };
        }
    }

    public interface ITokenEndPointService
    {
    }

    public class DefaultTokenEndPointService : ITokenEndPointService
    {
    }

    public class TokenRequest
    {
    }
}