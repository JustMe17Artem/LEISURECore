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
    /// Логика взаимодействия для Visit_Event.xaml
    /// </summary>
    public partial class Visit_Event : Window
    {
        public List<Event> events { get; set; }
        public Visit_Event()
        {
            InitializeComponent();
            events = DataAccess.GetEvents();
            this.DataContext = this;
        }

        private void VisitEvent_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Nullable<int> ID_Event = (ListEvents.SelectedItem as LEISURECore.Event).ID_Object;
                //Nullable<int> ID_Object = (ListEvents.SelectedItem as LEISURECore.Event).ID_Object;
                int ID_Object = DataAccess.GetObject(VisitEvent.Content.ToString()).ID_Object;
                int ID_Event = DataAccess.GetEvent(VisitEvent.Content.ToString()).ID_Event;
                Nullable<DateTime> date = DateTime.Now;
                if (DataAccess.AddNewVisiting(ID_Event, date, ID_Object))
                {
                    MessageBox.Show("Мероприятие посещено!");
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

        private void ListEvents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            VisitEvent.Content = $"{(ListEvents.SelectedItem as LEISURECore.Event).Name}";
        }
    }
}
