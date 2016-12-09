using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirst.Model.ViewModel
{
    public class LoginUser
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string UserPwd { get; set; }
        [Required]
        public string ValidataNum { get; set; }
    }
}
