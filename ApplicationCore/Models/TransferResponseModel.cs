using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Models
{
    public class TransferResponseModel
    {
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public DateTime? TransDate { get; set; }
        public string Remarks { get; set; }
    }
}
