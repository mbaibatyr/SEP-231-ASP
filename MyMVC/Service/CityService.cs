using MyMVC.Abstract;
using MyMVC.Models;
using Microsoft.Data.SqlClient;
using System.Data;
using Dapper;

namespace MyMVC.Service
{
    public class CityService : ICity
    {
        IConfiguration config;
        public CityService(IConfiguration config) 
        {
            this.config = config;
        }
        public string CityAdd(City city)
        {
            using (SqlConnection db = new SqlConnection(config["db"]))
            {
                db.Execute("pCity;3", new { @name = city.name}, commandType: CommandType.StoredProcedure);
                return "ok";
            }
        }

        public IEnumerable<City> GetAllCity()
        {
            using (SqlConnection db = new SqlConnection(config["db"]))
            {
                return db.Query<City>("pCity", commandType: CommandType.StoredProcedure);
            }
        }

        public City GetCityById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
