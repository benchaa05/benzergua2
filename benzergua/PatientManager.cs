using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace benzergua
{
    public class PatientManager
    {
        private readonly gmdbEntities _gmDb = new gmdbEntities();

        public patient CreatePatientUniqueCode(patient thePatient)
        {
            var query = from p in _gmDb.patients
                where p.PatientID == thePatient.PatientID
                select p;
            int rightnumber = DateTime.Now.Year;
            string numbers = rightnumber.ToString(CultureInfo.InvariantCulture);
            string[] righttwodigits = numbers.Split('0');
            string twodigits = righttwodigits[1];
            string valueOfPatientID = query.First().PatientID.ToString(CultureInfo.InvariantCulture);
            switch (valueOfPatientID.Length)
            {
                case 1:
                    const string tenthousand = "0000";
                    query.First().PatUniqueCode = string.Concat(tenthousand, valueOfPatientID, "/", twodigits);
                    break;
                case 2:
                    const string thousand = "000";
                    query.First().PatUniqueCode = string.Concat(thousand, valueOfPatientID, "/", twodigits);
                    break;
                case 3:
                    const string hundred = "00";
                    query.First().PatUniqueCode = string.Concat(hundred, valueOfPatientID, "/", twodigits);
                    break;
                case 4:
                    const string ten = "0";
                    query.First().PatUniqueCode = string.Concat(ten, valueOfPatientID, "/", twodigits);
                    break;
                case 5:
                    query.First().PatUniqueCode = string.Concat(valueOfPatientID, "/", twodigits);
                    break;
            }

            _gmDb.SaveChanges();
            return query.First();
        }
    }
}