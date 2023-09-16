using AutomobileLibrary.DataAccess;
using AutomobileLibrary.DataObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AutomobileSolution
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		#region Fields & Properties
		ICarRepository carRepository;

		#endregion

		#region Methods
		public MainWindow(ICarRepository repository)
		{
			InitializeComponent();
			carRepository = repository;
		}

		public void LoadCarList()
		{
			lvCars.ItemsSource = carRepository.GetCars();
		}

		private void btnLoad_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				LoadCarList();
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message, "Load car list");
			}
		}

		private void btnInsert_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				Car car = GetCarObject();
				carRepository.InsertCar(car);
				LoadCarList();
				MessageBox.Show($"{car.CarName} inserted successfully ", "Insert car");
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Insert car");
			}
		}

		private void btnUpdate_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				Car car = GetCarObject();
				carRepository.UpdateCar(car);
				LoadCarList();
				MessageBox.Show($"{car.CarName} updated successfully ", "Update car");
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "UPdate car");
			}
		}

		private void btnDelete_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				Car car = GetCarObject();
				carRepository.DeleteCar(car);
				LoadCarList();
				MessageBox.Show($"{car.CarName} deleted successfully ", "Delete car");
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Delete car");
			}
		}

		private void btnClose_Click(object sender, RoutedEventArgs e) => Close();

		private Car GetCarObject()
		{
			try
			{
				return new Car {
							CarId = int.Parse(txtCarId.Text),
							CarName = txtCarName.Text,
							Manufacturer = txtManufacturer.Text,
							Price = decimal.Parse(txtPrice.Text),
							ReleaseYear = int.Parse(txtReleasedYear.Text)};
			}
			catch(Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
		#endregion
	}
}
