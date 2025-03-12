using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Northwind.mvc.Models
{
    public record Thing
    ( 
        [Range(1,10)] int? Id, 
        [Required] string? Color,
        [EmailAddress] string? Email
    );
}