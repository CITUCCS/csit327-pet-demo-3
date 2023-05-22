using System.ComponentModel.DataAnnotations.Schema;

namespace Pets.Models
{
    // Principal entity
    public class Owner
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string ContactInfo { get; set; } = string.Empty;

        /// <summary>
        /// One to many. A list of Pets
        /// </summary>
        public ICollection<Pet> Pets { get; set; }
    }
}
