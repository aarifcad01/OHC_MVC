using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OHCPROJ.Controllers;

public class RegisterModel
{
    public string? Username {get; set;}
    public string? Email {get; set;}
    public string? Phone_Number {get; set;}
    public string? Address {get; set;}
    public string? City {get; set;}
    public string? Postal_Zipcode {get; set;}
}
