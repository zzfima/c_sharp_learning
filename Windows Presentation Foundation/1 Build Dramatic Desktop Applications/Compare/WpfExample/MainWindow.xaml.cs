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
using TailorMadeTours.Models;

namespace WpfExample {
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window {
		public MainWindow() {
			InitializeComponent();
			this.DataContext = TourSource.GetAllTourStops();
		}

		private void AnimatedMenu_Click(object sender, RoutedEventArgs e) {
			var win = new SplashWindow();
			win.Show();
		}

		private void Button1_Click(object sender, RoutedEventArgs e) {
			ListBox1.Visibility = Visibility.Collapsed;
			ListBox2.Visibility = Visibility.Visible;
			ListBox3.Visibility = Visibility.Collapsed;
		}

		private void Button2_Click(object sender, RoutedEventArgs e) {
			ListBox2.Visibility = Visibility.Collapsed;
			ListBox3.Visibility = Visibility.Visible;
			ListBox1.Visibility = Visibility.Collapsed;
		}

		private void MediaElement1_MediaEnded(object sender, RoutedEventArgs e) {
			Media1.Stop();
			Media1.Position = TimeSpan.Zero;
			Media1.Play();
		}

		private void MediaElement2_MediaEnded(object sender, RoutedEventArgs e) {
		
			Media2.Stop();
			Media2.Position = TimeSpan.Zero;
			Media2.Play();
		}

	
		private void Media1_Loaded(object sender, RoutedEventArgs e) {
			Media1.Position = TimeSpan.Zero;
			Media1.Play();
		}

		private void Media2_Loaded(object sender, RoutedEventArgs e) {
			Media2.Position = TimeSpan.Zero;
			Media2.Play();
		}
	}
}
