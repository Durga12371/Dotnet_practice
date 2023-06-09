using Dapper;
using NHibernate.SqlCommand;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using WebApplication4.Models;
using static System.Formats.Asn1.AsnWriter;

namespace WebApplication4.Services
{
    public class TrainService : ITrainService
    {
        private readonly IConfiguration _configuration;
        //private readonly IDbConnection _connection;
        public string ConnectionString { get; }
        public string ProvideName { get; }

        public TrainService(IConfiguration configuration)
        {
            _configuration = configuration;
            ConnectionString = _configuration.GetConnectionString("DBConnection");
            ProvideName = "System.Data.SqlClient";
            //_connection = connection;   
        }
        public IDbConnection Connection
        {
            get { return new SqlConnection(ConnectionString); }
        }
        public List<output> display(Input input)
        {
            List<output> trains = new List<output>();
            trains = Connection.Query<output>("FindTrains",
                new
                {
                    @StationName = input.StationName,
                    @From_Time = input.From_Time,
                    @To_Time = input.To_Time,
                    @Date = input.Date,

                },
                commandType: CommandType.StoredProcedure
                ).ToList();
            return trains;

        }
        public List<Train> Follow()
        {
            List<Train> trains = new List<Train>();
            trains = Connection.Query<Train>("Select * from Trains").ToList();
            return trains;

        }
        public List<Train> CreateTrains(Train train)
        {
            List<Train> trains = new List<Train>();
            trains = Connection.Query<Train>("CreateTrain",
                new
                {

                    @TrainID = train.TrainID,
                    @TrainName = train.TrainName,
                    @Source_Station_Id = train.Source_Station_Id,
                    @Destination_Station_Id = train.Destination_Station_Id,


                },
                commandType: CommandType.StoredProcedure
                ).ToList();

            return trains;

        }
        //public List<output> Find(Input input)
        //{
        //    List<output> trains = new List<output>();
        //    trains = Connection.Query<output>("FindTrains",
        //        new
        //        {
        //            @StationName = input.StationName,
        //            @From_Time = input.From_Time,
        //            @To_Time = input.To_Time,
        //            @Date=input.Date
        //        },
        //        commandType: CommandType.StoredProcedure
        //        ).ToList();
        //    return trains;

        //}
    }
}
