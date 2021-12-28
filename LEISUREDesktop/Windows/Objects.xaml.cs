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




namespace LEISUREDesktop.Windows
{
    /// <summary>
    /// Логика взаимодействия для Objects.xaml
    /// </summary>
    public partial class Objects : Window
    {
        public List<LEISURECore.Object> objects { get; set; }
        public Objects()
        {
            InitializeComponent();
            objects = DataAccess.GetObjects();
            this.DataContext = this;
        }

        private void ListObjects_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            VisitObject.Content = $"{(ListObjects.SelectedItem as LEISURECore.Object).Name}";
        }

        private void VisitObject_Click(object sender, RoutedEventArgs e)
        {
            //int IdTattoo = DataAccess.GetTattoo(btnTattoo.Content.ToString()).IdTattoo;
            try
            {
                
                int ID_Obj = (ListObjects.SelectedItem as LEISURECore.Object).ID_Object;
                //int ID_Obj = DataAccess.GetObject(VisitObject.Content.ToString()).ID_Object;
                Nullable<DateTime> date = DateTime.Now.Date;
                if (DataAccess.AddNewVisiting(ID_Obj, date))
                {
                    
                    MessageBox.Show("Объект посещён!");
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
