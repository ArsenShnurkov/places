namespace Places
{
    internal class Region
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string LocalCode { get; set; }
        public string Name { get; set; }
        public string WikipediaLink { get; set; }
        public virtual Country Country { get; set; }
    }
}