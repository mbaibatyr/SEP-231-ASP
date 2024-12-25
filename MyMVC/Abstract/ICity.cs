using MyMVC.Models;

namespace MyMVC.Abstract
{
    public interface ICity
    {
        IEnumerable<City> GetAllCity();
        City GetCityById(string id);
        string CityAdd(City city);
        string CityDel(string id);
    }
}
