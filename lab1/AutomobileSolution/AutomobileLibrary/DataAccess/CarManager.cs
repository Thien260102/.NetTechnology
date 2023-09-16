using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobileLibrary.DataAccess
{
	public class CarManager
	{
		#region Fields & Properties
		private static CarManager instance;
		public static CarManager Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new CarManager();
				}

				return instance;
			}

			private set
			{
				instance = value;
			}
		}

		#endregion

		#region Methods
		private CarManager()
		{

		}

		public IEnumerable<Car> GetCarList()
		{
			try
			{
				var stockContext = new MyStockContext();
				return stockContext.Cars.ToList();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public Car GetCarBy(int carID)
		{
			try
			{
				var stockContext = new MyStockContext();
				return stockContext.Cars.SingleOrDefault<Car>(car => car.CarId == carID);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public void AddNewCar(Car car)
		{
			try
			{
				if (GetCarBy(car.CarId) == null)
				{
					MyStockContext stockContext = new MyStockContext();
					stockContext.Cars.Add(car);
					stockContext.SaveChanges();
				}
				else
				{
					throw new Exception("The car is already exist.");
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public void UpdateCar(Car car)
		{
			try
			{
				Car _car = GetCarBy(car.CarId);
				if (_car != null)
				{
					MyStockContext stockContext = new MyStockContext();
					stockContext.Entry<Car>(car).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
					stockContext.SaveChanges();
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public void RemoveCar(Car car)
		{
			try
			{
				Car _car = GetCarBy(car.CarId);
				if (_car != null)
				{
					MyStockContext stockContext = new MyStockContext();
					stockContext.Cars.Remove(car);
					stockContext.SaveChanges();
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
		#endregion
	}
}
