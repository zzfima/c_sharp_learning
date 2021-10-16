using System.Collections.Generic;
using System.Windows;

namespace TailorMadeTours
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static List<MyEntities> MyItems = new List<MyEntities>()
        {
            new MyEntities { Name = "Murka", Age = 4 },
            new MyEntities { Name = "Bloha4", Age = 4 },
            new MyEntities { Name = "Dilona", Age = 4 },
        };
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = MyItems;
        }
    }
}
