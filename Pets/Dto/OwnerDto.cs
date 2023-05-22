namespace Pets.Dto
{
    public class OwnerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactInfo { get; set; }
        public ICollection<PetDto> Pets { get; set; }
    }
}
