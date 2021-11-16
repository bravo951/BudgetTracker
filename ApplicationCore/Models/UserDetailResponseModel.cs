using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Models
{
    public class UserDetailResponseModel
    {
        //public int Id { get; set; }
        public string Email { get; set; }
        //public string Password { get; set; }
        public string Fullname { get; set; }
        public DateTime? JoinedOn { get; set; }
        //public List<ExpenditureResponseModel> ExpendituresList { get; set; }
        //public List<IncomeResponseModel> IncomesList { get; set; }
        public List<TransferResponseModel> TransList { get; set; }
    }

    

}
