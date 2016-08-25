using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PHCForms
{
    
    public class Patient
    {
        public string Name { get; set; }
        public string Dosage { get; set; }

    }
   public class LabTest
    {
        public string Labtests { get; set; }
        public string Result { get; set; }
    }

    public class employee
    {
        public string name { get; set; }
        public int age { get; set; }
        public string sex { get; set; }
        public string contactno { get; set; }
        public string place { get; set; }

    }
    public class PatientHistory
    {
        public string prescriptionid { get; set; }
        public string Decease { get; set; }
        public string Description { get; set; }
    }
    public class Druginfo
    {
        public string Drugid { get; set; }
        public string DrugName { get; set; }
    }
    class BloodGroups
    {
        public string BloodGroupID { get; set; }
        public string BloodGroup { get; set; }
    }
}
