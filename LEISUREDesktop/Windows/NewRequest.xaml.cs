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
    /// Логика взаимодействия для NewRequest.xaml
    /// </summary>
    public partial class NewRequest : Window
    {
        public List<LEISURECore.Object> objects { get; set; }
        public List<Type_Event> types { get; set; }
        public NewRequest()
        {
            InitializeComponent();
            objects = DataAccess.GetObjects();
            types = DataAccess.GetTypeEvents();
            this.DataContext = this;
        }

        private void Create_Object_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string Name = Name_Event.Text;
                int Id_Object = (Object.SelectedItem as LEISURECore.Object).ID_Object;
                DateTime start = Start.SelectedDate.Value;
                DateTime end = End.SelectedDate.Value;
                int Id_Type = (Type_Event.SelectedItem as LEISURECore.Type_Event).ID_Type;
                string Contact = Phone.Text;
                if (DataAccess.AddNewRequest(Id_Object, Name, Id_Type, start, end, Contact))
                {
                    MessageBox.Show("Заявка подана. Ожидайте");
                }
            }
            catch
            {
                MessageBox.Show("Упс... Что-то пошло не так");
            }
        }

        private void QuitClick(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }
    }
}
