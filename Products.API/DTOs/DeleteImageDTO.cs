using System.ComponentModel;

namespace Products.API.DTOs
{
    [Description("An object which provides the properties needed to delete an Image from a Product's Image collection " +
        $"which is defined by it's Images property.")]
    public class DeleteImageDTO
    {
        [Description("The Id property of the Product from which the Image will be deleted.")]
        public string Id { get; set; }
        [Description("The FileName property of the specific ImageData object to be deleted. The FileName is used to " +
            $"identify the correct Image to delete.")]
        public string FileName { get; set; }           

        public DeleteImageDTO(string id, string filename)
        {
            Id = id;
            FileName = filename;
        }
    }
}
