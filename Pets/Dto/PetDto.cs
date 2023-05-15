using System.ComponentModel.DataAnnotations;

namespace Pets.Dto
{
    public class PetDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public string Biography { get; set; }
        public string Type { get; set; }
    }
}
