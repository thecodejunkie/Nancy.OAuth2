namespace Nancy.OAuth2.Demo
{
    using System.Collections;
    using System.Collections.Generic;

    public class InMemoryNoodleService : INoodleService
    {
        private readonly IList<NoodleModel> cache;

        public InMemoryNoodleService()
        {
            this.cache = new List<NoodleModel>();
        }

        public IEnumerator<NoodleModel> GetEnumerator()
        {
            return this.cache.GetEnumerator();
        }

        public void Add(NoodleModel message)
        {
            this.cache.Add(message);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}