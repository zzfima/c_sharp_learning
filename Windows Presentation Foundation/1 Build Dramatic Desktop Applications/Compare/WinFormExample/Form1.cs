using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TailorMadeTours.Models;

namespace WinFormExample {
	public partial class Form1 : Form {
		public Form1() {
			InitializeComponent();


			foreach (TourStop stop in TourSource.GetAllTourStops())
			{
				this.listBox1.Items.Add(stop);
			}

		}

		private void listBox1_SelectedIndexChanged(object sender, EventArgs e) {

		}
	}
}
