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
using System.Text.RegularExpressions;

namespace Final
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            combobox.Items.Add("Ford Tourneo Connect");
            combobox.Items.Add("Citroën Berlingo ");
            combobox.Items.Add("Fiat Doblo");
            combobox.Items.Add("Hyundai Accent Blue");
            combobox.Items.Add("Renault Clio");
            combobox.Items.Add("Mercedes A200");
        }
        public string Text { get; private set; }
        private void Ekle(object sender, RoutedEventArgs e)
        {
            if (Musteri.Text.Length > 0 && combobox.SelectedIndex >= 0 && fiyat.Text.Length > 0)
            {
                Kutu1.Items.Add(Musteri.Text);
                Kutu2.Items.Add(combobox.Text);
                Kutu3.Items.Add(fiyat.Text);
            }

            else
            {
                MessageBox.Show("Lütfen Tüm Alanları Doldurunuz!!", "Error");
            }

        }
        private void Sil(object sender, RoutedEventArgs e)
        {
            if (Kutu1.SelectedItems.Count > 0)
            {
                Kutu2.Items.RemoveAt(0 + Kutu1.SelectedIndex);
                Kutu3.Items.RemoveAt(0 + Kutu1.SelectedIndex);
     
                Kutu1.Items.Remove(Kutu1.SelectedItem);
                MessageBox.Show("Silme başarılı!", "Başarılı!");
            }

            else 
            {
                MessageBox.Show("Lütfen Tüm Alanları Seçiniz!","Hata");
            }
        }

        private void Guncelle(object sender, RoutedEventArgs e)
        {
            if (Kutu1.SelectedItems.Count > 0 || Kutu2.SelectedItems.Count > 0 || Kutu3.SelectedItems.Count > 0)
            {
                if (Kutu1.SelectedItems.Count == 1 && Musteri.Text.Length > 0)
                {
                    int index = Kutu1.SelectedIndex;
                    Kutu1.Items.RemoveAt(index);
                    Kutu1.Items.Insert(index, Musteri.Text);
                }

                if (Kutu2.SelectedItems.Count == 1 && combobox.Text.Length > 0)
                {
                    int index1 = Kutu2.SelectedIndex;
                    Kutu2.Items.RemoveAt(index1);
                    Kutu2.Items.Insert(index1, combobox.Text);
                }

                if (Kutu3.SelectedItems.Count == 1 && fiyat.Text.Length > 0)
                {
                    int index2 = Kutu3.SelectedIndex;
                    Kutu3.Items.RemoveAt(index2);
                    Kutu3.Items.Insert(index2, fiyat.Text);
                }
                MessageBox.Show("Güncelleme Tamamlandı!","Başarılı!");
            }
        }

        private void fiyat_TextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}