namespace Nancy.OAuth2.Demo
{
    using System.Collections.Generic;

    public interface INoodleService : IEnumerable<NoodleModel>
    {
        void Add(NoodleModel message);
    }
}