//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace benzergua
{
    using System;
    using System.Collections.Generic;
    
    public partial class consultation
    {
        public int ConsultationID { get; set; }
        public Nullable<int> PatientID { get; set; }
        public string ConsultationName { get; set; }
        public Nullable<int> ConsultationFee { get; set; }
        public Nullable<int> ConsultationRemainFee { get; set; }
        public Nullable<double> COD { get; set; }
        public string AGE { get; set; }
        public Nullable<System.DateTime> ConsultationDate { get; set; }
        public string DocumentDesc { get; set; }
        public string ConsSignePhysic { get; set; }
        public string diagExamen { get; set; }
        public string ConsultationMotifvisite { get; set; }
        public string ConsultationWeight { get; set; }
        public string ConsultationTall { get; set; }
        public string ConsultationIMC { get; set; }
        public string ConsultationExamen { get; set; }
        public string ConsultationTraitement { get; set; }
        public string GrossesseState { get; set; }
        public Nullable<int> NumberOfKids { get; set; }
        public string TensionMin { get; set; }
        public string TensionMax { get; set; }
        public string Glycimie { get; set; }
        public string WeightDDS { get; set; }
        public string TailleDDS { get; set; }
        public string IMCnote { get; set; }
        public string PC { get; set; }
    }
}
