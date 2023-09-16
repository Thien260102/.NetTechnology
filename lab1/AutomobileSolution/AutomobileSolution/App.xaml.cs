using AutomobileLibrary.DataAccess;
using AutomobileLibrary.DataObject;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace AutomobileSolution
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		#region Fields & Properties
		private ServiceProvider serviceProvider;

		#endregion

		#region Methods
		public App()
		{
			ServiceCollection services = new ServiceCollection();
			ConfigurationServices(services);
			serviceProvider = services.BuildServiceProvider();
		}

		private void ConfigurationServices(ServiceCollection services)
		{
			services.AddSingleton(typeof(ICarRepository), typeof(CarRepository));
			services.AddSingleton<MainWindow>();
		}

		private void OnStartup(object sender, StartupEventArgs e)
		{
			var mainWindow = serviceProvider.GetService<MainWindow>();
			mainWindow.Show();
		}
		#endregion
	}
}
