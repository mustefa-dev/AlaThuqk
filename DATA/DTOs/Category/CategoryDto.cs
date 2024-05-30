using System.ComponentModel.DataAnnotations.Schema;
using AlaThuqk.Entities;
using Newtonsoft.Json;

namespace AlaThuqk.DATA.DTOs;

public class CategoryDto: BaseDTO<Guid>{
    public string Name { get; set; }
}