using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Models
{
    public class ExpenditureResponseModel
    {
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public DateTime? ExpDate { get; set; }
        public string Remarks { get; set; }
    }
}
