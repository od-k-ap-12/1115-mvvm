using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace _1115.Models
{
    [Serializable]
    [DataContract]
    internal class SummaryModel
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Surname { get; set; }
        [DataMember]
        public string Phone { get; set; }
        [DataMember]
        public string Bio { get; set; }
        [DataMember]
        public bool IsEngish { get; set; }
        [DataMember]
        public bool IsGerman { get; set; }

        public SummaryModel(string name, string surname, string phone, string bio, bool isEnglish, bool isGerman)
        {
            Name = name;
            Surname = surname;
            Phone = phone;
            Bio = bio;
            IsEngish = isEnglish;
            IsGerman = isGerman;
        }

        public override string ToString()
        {
            return Name + ' ' + Surname;
        }
    }
}
