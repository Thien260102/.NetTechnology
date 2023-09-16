using AutomobileLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobileLibrary.DataObject
{
	public class CarRepository : ICarRepository
	{
		public IEnumerable<Car> GetCars() => CarManager.Instance.GetCarList();

		public void DeleteCar(Car car) => CarManager.Instance.RemoveCar(car);

		public Car GetCarBy(int carID) => CarManager.Instance.GetCarBy(carID);

		public void InsertCar(Car car) => CarManager.Instance.AddNewCar(car);

		public void UpdateCar(Car car) => CarManager.Instance.UpdateCar(car);
	}
}
