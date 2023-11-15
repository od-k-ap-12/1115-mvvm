using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1115.Models
{
    internal class SummaryModel
    {
        public string Name {  get; set; }
        public string Surname { get; set; }
        public bool IsEnglish { get; set; }
        public SummaryModel(string name,string surname, bool isEnglish)
        {
            Name = name;
            Surname = surname;
            IsEnglish = isEnglish;
        }
        public override string ToString()
        {
            return Name + " " + Surname;
        }
    }
}
