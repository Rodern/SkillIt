using System;
using System.Collections.Generic;

#nullable disable

namespace SkillIT_Models.DatabaseModels
{
    public partial class Country
    {
        public Country()
        {
            Languages = new HashSet<Language>();
            Phones = new HashSet<Phone>();
        }

        public int CountryId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int DialCode { get; set; }
        public string Symbol { get; set; }
        public string Capital { get; set; }
        public string Currency { get; set; }
        public string Continent { get; set; }
        public string ContinentCode { get; set; }
        public string Alpha3 { get; set; }

        public virtual ICollection<Language> Languages { get; set; }
        public virtual ICollection<Phone> Phones { get; set; }
    }
}
