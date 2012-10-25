namespace Nancy.OAuth2.Demo
{
    using Nancy.OAuth2;
    using Security;

    public class OAuthLogin : IOAuthLogin
    {
        public IUserIdentity GetUser(string token)
        {
            return new DemoUserIdentity { UserName = "admin " };
        }
    }
}