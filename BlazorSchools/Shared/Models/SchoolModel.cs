using System.ComponentModel.DataAnnotations;

namespace BlazorSchools.Shared.Models
{
    public class SchoolModel : Common
    {
        [Required]
        public string Name { get; set; }

#nullable enable
        public string? Street { get; set; }

        public string? City { get; set; }

        public string? State { get; set; }

        public string? Zip { get; set; }
#nullable disable
    }
}