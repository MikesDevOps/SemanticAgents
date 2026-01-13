using System.ComponentModel;

namespace Products.API.DTOs
{
    [Description("An object which contains the properties used to update only the Status property of a Product in the database.")]
    public class UpdateStatusDTO
    {
        [Description("The Id property of the Product to be updated.")]
        public string Id { get; set; }
        [Description("The updated Status property to use for the Product to be updated.")]
        public string Status { get; set; }

        public UpdateStatusDTO(string id, string status)
        {
            Id = id;
            Status = status;
        }

    }
}
