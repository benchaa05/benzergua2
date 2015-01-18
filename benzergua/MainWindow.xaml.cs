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
                where t.PatientID >= 30000
                // && t.PatientID < 30000
                select t;

            foreach (var getPatient in query)
            {
                string getCode = GetCode(getPatient);
                getPatient.PatUniqueCode = getCode;

                // _patientManager.CreatePatientUniqueCode(getPatient);
            }
            gmdb.SaveChanges();
            MessageBox.Show("finished");

            var query2 = from t in gmdb.patients
                select t;
            PatientGridControl.ItemsSource = query2.ToList();
        }

        private string GetCode(patient getPatient)
        {
            try
            {
                string getedCode;
                int rightnumber = DateTime.Now.Year;
                string numbers = rightnumber.ToString(CultureInfo.InvariantCulture);
                string[] righttwodigits = numbers.Split('0');
                string twodigits = righttwodigits[1];
                string valueOfPatientID = getPatient.PatientID.ToString(CultureInfo.InvariantCulture);
                switch (valueOfPatientID.Length)
                {
                    case 1:
                        const string tenthousand = "0000";
                        getedCode = string.Concat(tenthousand, valueOfPatientID, "/", twodigits);
                        break;
                    case 2:
                        const string thousand = "000";
                        getedCode = string.Concat(thousand, valueOfPatientID, "/", twodigits);
                        break;
                    case 3:
                        const string hundred = "00";
                        getedCode = string.Concat(hundred, valueOfPatientID, "/", twodigits);
                        break;
                    case 4:
                        const string ten = "0";
                        getedCode = string.Concat(ten, valueOfPatientID, "/", twodigits);
                        break;
                    case 5:
                        getedCode = string.Concat(valueOfPatientID, "/", twodigits);
                        break;
                    default:
                        getedCode = "";
                        break;
                }
                return getedCode;
            }
            catch (Exception)
            {
                return "";
            }
        }
    }
}