﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EnrollmentService.Dtos
{
    public class StudentForCreateDto
    {
        [Required (ErrorMessage ="Kolom FirstName harus diisi")]
        [MaxLength (20, ErrorMessage ="Tidak Boleh lebih dari 20 karakter")]
        public string FirstName { get; set; }
        
        [Required(ErrorMessage ="Kolom LastName harus diisi")]
        [MaxLength(20, ErrorMessage ="Tidak Boleh lebih dari 20 karakter")]
        public string LastName { get; set; }
        
        [Required]
        public DateTime EnrollmentDate { get; set; }

      
    }
}
