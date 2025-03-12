using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Northwind.mvc.Models
{
    public record HomeModelBindingViewModel
    (
        Thing Thing, 
        bool HasErrors, 
        IEnumerable<string> ValidationErrors
    );
}