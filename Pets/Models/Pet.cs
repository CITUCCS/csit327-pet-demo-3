namespace Pets.Models
{
    // Principal Entity
    public class Pet
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }

        // One-to-one
        /// <summary>
        /// Reference to the PetDetails
        /// </summary>
        public PetDetails Details { get; set; }
    }
}
