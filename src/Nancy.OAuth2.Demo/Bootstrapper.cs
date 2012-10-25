namespace Nancy.OAuth2.Demo
{
    using Authentication.Forms;
    using Cryptography;
    using Nancy.Bootstrapper;
    using Nancy.OAuth2;
    using TinyIoc;

    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            base.ApplicationStartup(container, pipelines);

            var cryptographyConfiguration = new CryptographyConfiguration(
                new RijndaelEncryptionProvider(new PassphraseKeyGenerator("SuperSecretPass", new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 })),
                new DefaultHmacProvider(new PassphraseKeyGenerator("UberSuperSecure", new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 })));

            var formsAuthConfiguration =
                new FormsAuthenticationConfiguration()
                {
                    RedirectUrl = "~/login",
                    UserMapper = container.Resolve<IUserMapper>(),
                    CryptographyConfiguration = cryptographyConfiguration
                };

            FormsAuthentication.Enable(pipelines, formsAuthConfiguration);

            OAuth.Enable();

            OAuthAuthentication.Enable(
                pipelines, 
                container.Resolve<IOAuthLogin>()
            );

            InMemorySessions.Enable(pipelines);
        }
    }
}