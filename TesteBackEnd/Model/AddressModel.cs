namespace TesteBackEnd.Model
{
    public class AddressModel
    {
        public Guid Id { get; set; }

        public string? CEP { get; set; }

        public int? Number { get; set; }

        public string? State { get; set; }

        public string? City { get; set; }

        public string? Country { get; set; }
    }
}
