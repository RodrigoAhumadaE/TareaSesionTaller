#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

namespace TareaSesionTaller.Models;

public class Usuario{

    [Required(ErrorMessage = "debe ingresar un nombre por favor")]
    public string Nombre {get;set;}
}