using System.ComponentModel.DataAnnotations;

namespace Places
{
    internal class Airport
    {
        [RequiredAttribute]
        [KeyAttribute]
        public int Id { get; set; }

        [RequiredAttribute]
        [StringLengthAttribute(7)]
        public string Ident { get; set; }

        [RequiredAttribute]
        public string Type { get; set; }

        [RequiredAttribute]
        public string Name { get; set; }

        [RequiredAttribute]
        public double Latitude { get; set; }

        [RequiredAttribute]
        public double Longitude { get; set; }

        public int? Elevation { get; set; }

        public string Municipality { get; set; }

        [RequiredAttribute]
        public bool ScheduledService { get; set; }

        [StringLengthAttribute(4)]
        public string GpsCode { get; set; }

        [StringLengthAttribute(3)]
        public string IataCode { get; set; }

        [StringLengthAttribute(4)]
        public string LocalCode { get; set; }

        public string HomeLink { get; set; }

        public string WikipediaLink { get; set; }

        [RequiredAttribute]
        public virtual Region Region { get; set; }
    }
}
