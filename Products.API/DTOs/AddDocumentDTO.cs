using System.ComponentModel;

namespace Products.API.DTOs
{
    [Description("An object which provides the properties for adding a new Document to a the document collection " +
        "of a specific Product.")]
    public class AddDocumentDTO
    {
        [Description("The Id property of the Product to which the new Document will be added. It is used to identify the specific Product " +
            "to which the Document will be added.")]
        public string Id { get; set; }
        [Description($"The File Name of the new Document.")]
        public string FileName { get; private set; }           
        [Description($"The Title of the new Document.")]
        public string Title { get; private set; }
        [Description($"The URL of the new Document.")]
        public string DocumentUrl { get; private set; }

        public AddDocumentDTO(string id, string filename, string title, string documentUrl)
        {
            Id = id;
            FileName = filename;
            Title = title;
            DocumentUrl = documentUrl;
        }
    }
}
