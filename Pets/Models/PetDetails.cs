namespace Pets.Models
{
    // Dependent Entity
    public class PetDetails
    {
        public int Id { get; set; }
        public string Type { get; set; } = string.Empty;
        public string Biography { get; set; } = string.Empty;
        
        // One-to-one

        /// <summary>
        /// Id of the Pet
        /// </summary>
        public int PetId { get; set; }
        /// <summary>
        /// Actual object reference of the Pet
        /// </summary>
        public Pet Pet { get; set; }
    }
}
