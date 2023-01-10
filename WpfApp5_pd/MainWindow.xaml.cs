using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp5_pd
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Product> Products { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            //Random random = new Random();
            //Products = new List<Product>
            //{
            //    new Product{Name="Шоколад", Count=2,Price = 17,Code = random.Next(999999)},
            //    new Product{Name="Какао", Count=1,Price = 25,Code = random.Next(999999)},
            //    new Product{Name="Молоко", Count=2,Price = 18,Code = random.Next(999999)},
            //    new Product{Name="Мандарины", Count=3,Price = 45,Code = random.Next(999999)},
            //    new Product{Name="Апельсиновый сок", Count=1,Price = 23,Code = random.Next(999999)},
            //    new Product{Name="Зефир", Count=1,Price = 32,Code = random.Next(999999)},
            //    new Product{Name="Бананы", Count=4,Price = 28,Code = random.Next(999999)},
            //    new Product{Name="Консервированные персики", Count=3,Price = 28,Code = random.Next(999999)}
            //};
            Load();


            //foreach (var item in Products)
            //{
            //    lbProducts.Items.Add(item.Name);
            //}
        }

        private void lbProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Save();
        }

        private void Save()
        {
            BinaryFormatter bf = new BinaryFormatter();
            try
            {
                using (Stream fStream = File.Create("Data.bin"))
                {
                    bf.Serialize(fStream, Products);
                }
            }
            catch
            {
                MessageBox.Show("Data save error!");
            }
        }

        private void Load()
        {
            BinaryFormatter bf = new BinaryFormatter();
            try
            {
                using (var fr = new FileStream("Data.bin", FileMode.Open))
                {
                    Products = bf.Deserialize(fr) as List<Product>;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
