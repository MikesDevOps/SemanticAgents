using System.ComponentModel;

namespace Products.API.DTOs
{
    [Description("An object which provides the properties needed to delete a Document from a Product's Document collection " +
        $"which is defined by it's Documents property.")]
    public class DeleteDocumentDTO
    {
        [Description("The Id property of the Product from which the Document will be deleted.")]
        public string Id { get; set; }
        [Description("The FileName property of the specific DocumentData object to be deleted. The FileName is used to " +
            $"identify the correct Document to delete.")]
        public string FileName { get; set; }         
        
        public DeleteDocumentDTO(string id, string filename)
        {
            Id = id;
            FileName = filename;
        }
    }
}
