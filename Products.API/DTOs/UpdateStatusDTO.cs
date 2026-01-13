namespace Products.API.DTOs
{
    public class UpdateStatusDTO
    {
        public string Id { get; set; }
        public string Status { get; set; }

        public UpdateStatusDTO(string id, string status)
        {
            Id = id;
            Status = status;
        }

    }
}
