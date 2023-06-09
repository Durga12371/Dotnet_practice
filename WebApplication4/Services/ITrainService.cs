using WebApplication4.Models;

namespace WebApplication4.Services
{
    public interface ITrainService
    {
        public List<output> display(Input input);
        public List<Train> Follow();
        public List<Train> CreateTrains(Train train);
        //public List<output> Find(Input input);
    }
}
