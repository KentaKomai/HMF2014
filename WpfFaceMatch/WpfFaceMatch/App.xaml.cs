using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfFaceMatch.Models;
using WpfFaceMatch.Views;

namespace WpfFaceMatch
{
	public partial class App : Application
	{
		public static new App Current
		{
			get { return (App)Application.Current; }
		}

		internal ThemeService ThemeService { get; private set; }

		public App()
		{
			this.ThemeService = new ThemeService(this);
		}
	}
}
