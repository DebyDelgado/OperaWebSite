﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; //BASE DE DATOS
using System.Linq;
using System.Web;
using OpenWebSite.Validations;

namespace OpenWebSite.Models
{
    [Table(name:"Opera")] //EF--> DB
    public class Opera
    {

        public int OperaId { get; set; }
        [Required(ErrorMessage ="Is required")]
        [StringLength(150)]
        public string Title { get; set; }
        [Required]
        public string Composer { get; set; }

        [CheckValidYear]
        public int Year { get; set; }
    }
}