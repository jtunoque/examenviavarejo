using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace App.UI.Web.Models
{
    public class UserViewModel
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string SenhaHash { get; set; }

    }
}