using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace benzergua
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PatientManager _patientManager = new PatientManager();

        public MainWindow()
        {
            InitializeComponent();
        }

// Hi, I am testing this online?
        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
        }

        private void CreateCodeBtn_Click(object sender, RoutedEventArgs e)
        {
            gmdbEntities gmdb = new gmdbEntities();
            var query = from t in gmdb.patients
                where t.PatientID <= 1024
                select t;

            foreach (var getPatient in query)
            {
                _patientManager.AddPatientIDtoConsultation(getPatient);
            }

            MessageBox.Show("finished");

            var query2 = from t in gmdb.patients
                select t;
            PatientGridControl.ItemsSource = query2.ToList();
        }
    }
}