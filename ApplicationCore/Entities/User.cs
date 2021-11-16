using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApplicationCore.Entities
{
    public class User
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
        [MaxLength(10)]
        public string Password { get; set; }
        [MaxLength(50)]
        public string Fullname { get; set; }
        public DateTime? JoinedOn { get; set; }
        public ICollection<Expenditure> Expenditures { get; set; }
        public ICollection<Income> Incomes { get; set; }
    }
}
