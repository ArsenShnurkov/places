using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Places
{
    internal class Region
    {
        [RequiredAttribute]
        [KeyAttribute]
        public int Id { get; set; }

        [RequiredAttribute]
        [StringLengthAttribute(7)]
        public string Code { get; set; }

        [RequiredAttribute]
        [StringLengthAttribute(4)]
        public string LocalCode { get; set; }

        [RequiredAttribute]
        public string Name { get; set; }

        public string WikipediaLink { get; set; }

        [RequiredAttribute]
        public virtual Country Country { get; set; }

        public virtual ICollection<Airport> Airports { get; set; }
    }
}