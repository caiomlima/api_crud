using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_API_CRUD.Models {
    public class Pizza {

        [Key]
        public int PizzaId { get; set; }

        [Required, MinLength(3), MaxLength(100)]
        public string Nome { get; set; }

    }
}
