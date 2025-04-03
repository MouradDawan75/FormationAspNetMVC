using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _06_DemoHtmlHelpers.Models
{
    public enum EmployeType
    {
        JUNIOR,
        SENIOR
    }
    public class Employe
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public double Salaire { get; set; }
        public bool isActif { get; set; }
        public DateTime DateEntree { get; set; }
        public EmployeType EmployeType { get; set; }
        public int DepartementId { get; set; }
    }
}   