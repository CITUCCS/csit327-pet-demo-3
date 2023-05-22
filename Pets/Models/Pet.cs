namespace Pets.Models
{
    // Principal Entity
    // Dependent Entity for Owner
    public class Pet
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }

        // One-to-one
        /// <summary>
        /// Reference to the PetDetails
        /// </summary>
        public PetDetails? Details { get; set; }

        // One-to-many
        /// <summary>
        /// Foreign Key to the Owner
        /// </summary>
        public int? OwnerId { get; set; }

        /// <summary>
        /// Reference to the Owner
        /// </summary>
        public Owner? Owner { get; set; }
    }
}
