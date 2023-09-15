using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Forms.Model
{
    public class User
    {
        [Required(ErrorMessage = "Id is required")]
        public int id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string name { get; set; }

        [Required(ErrorMessage = "CPF is required")]
        public string cpf { get; set; }


        public string template { get; set; }
    }
}
