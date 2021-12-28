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
using System.Windows.Shapes;
using LEISURECore;

namespace DesktopLEISURE.Windows
{
    /// <summary>
    /// Логика взаимодействия для New_Object.xaml
    /// </summary>
    public partial class New_Object : Window
    {
        public List<Type_Object> types { get; set; }
        public New_Object()
        {
            InitializeComponent();
            types = DataAccess.GetTypeObjects();
            this.DataContext = this;
        }

        private void Create_Object_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string Name = Name_Object.Text;
                int ID_Type = (Type_Object.SelectedItem as LEISURECore.Type_Object).ID_Type;
                string Adress_Object = Adress.Text;
                int Capacity_Object = Convert.ToInt32(Capacity.Text);
                if (DataAccess.AddNewObject(Name, ID_Type, Adress_Object, Capacity_Object))
                {
                    MessageBox.Show("Объект успешно создан");
                }
            }
            catch
            {
                MessageBox.Show("Упс... Что-то пошло не так");
            }
        }

        private void QuitClick(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
