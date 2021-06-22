using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace quickTask.Models
{
    public class Patient
    {
        [Key]
        [Required(ErrorMessage = "Id it is required")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter  Name it is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter Gender it is required")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Please enter City it is required")]
        public string City { get; set; }

    }

}

