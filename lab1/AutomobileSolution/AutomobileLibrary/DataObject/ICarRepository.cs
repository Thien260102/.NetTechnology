﻿using AutomobileLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobileLibrary.DataObject
{
	public interface ICarRepository
	{
		IEnumerable<Car> GetCars();
		Car GetCarBy(int carID);
		void InsertCar(Car car);
		void DeleteCar(Car car);
		void UpdateCar(Car car);
	}
}
