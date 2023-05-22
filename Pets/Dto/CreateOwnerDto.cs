namespace Pets.Dto
{
    public class CreateOwnerDto
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactInfo { get; set; }
        public IEnumerable<int> PetIds { get; set; }
    }
}
