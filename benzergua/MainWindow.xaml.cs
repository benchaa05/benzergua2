using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            var getAllPatients = new BackgroundWorker();
            getAllPatients.DoWork += GetAllConsultationOnDoWork;
            getAllPatients.RunWorkerCompleted += GetAllConsultationOnRunWorkerCompleted;
            getAllPatients.RunWorkerAsync();
        }

        private void GetAllConsultationOnRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("finished");
            gmdbEntities gmdb = new gmdbEntities();
            var query2 = from t in gmdb.consultations
                select t;
            PatientGridControl.ItemsSource = query2.ToList();
        }

        private void GetAllConsultationOnDoWork(object sender, DoWorkEventArgs e)
        {
            gmdbEntities gmdb = new gmdbEntities();
            var query = from t in gmdb.consultations
                select t;

            foreach (var getCnsultation in query)
            {
                getCnsultation.ConsultationName = "CN 400;";
                getCnsultation.ConsultationFee = 400;
                getCnsultation.ConsultationRemainFee = 0;
            }
            gmdb.SaveChanges();
        }
    }
}