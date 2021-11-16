using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Models
{
    public class UserResponseModel
    {
        public int Id { get; set; }
        public string FullName { set; get; }
        public DateTime JoinOn { set; get; }
    }
}
