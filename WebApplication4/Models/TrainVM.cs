namespace WebApplication4.Models
{
    public class TrainVM
    {
        public output output { get; set; }
        public List<output> outputs { get; set; }
        public List<output> FindTrains { get; set; }
        public List<output> Find { get; set; }
        public List<Train> TrainsDetails { get; set; }
        public List<Train> Create { get; set; }
    }

}
