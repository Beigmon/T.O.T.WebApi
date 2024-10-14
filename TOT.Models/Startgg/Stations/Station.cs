namespace TOT.Models.Startgg.Stations
{
    public class Station
    {
        public int Id { get; set; }
        public int Number { get; set; }
        /// <summary>
        /// 1 = available, 2 = used
        /// </summary>
        public int State { get; set; }

        public string? SetId { get; set; }
    }
}
