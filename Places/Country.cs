using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Places
{
    internal class Country
    {
        [RequiredAttribute]
        [KeyAttribute]
        public int Id { get; set; }

        [RequiredAttribute]
        [StringLengthAttribute(2)]
        public string Code { get; set; }

        [RequiredAttribute]
        public string Name { get; set; }

        [RequiredAttribute]
        [StringLengthAttribute(2)]
        public string Continent { get; set; }

        public string WikipediaLink { get; set; }

        public virtual ICollection<Region> Regions { get; set; }
    }
}