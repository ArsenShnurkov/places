using System.Collections.Generic;

namespace Places
{
    internal class Country
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Continent { get; set; }
        public string WikipediaLink { get; set; }
        public virtual ICollection<Region> Regions { get; set; }
    }
}