﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public int id { get; set; }

       // public DateTime DataCadastro { get; private set; } = DateTime.UtcNow;
       // public DateTime DataAlteracao { get; private set; } = DateTime.UtcNow;
    }
}
