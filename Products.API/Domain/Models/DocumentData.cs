using Products.API.DTOs;
using System;

namespace Products.API.Domain.Models
{
    public class DocumentData
    {
        public string Name { get; private set; }           // for Azure blob storage, virtual directory plus filename
        public string Title { get; private set; }
        public int SequenceNumber { get; private set; }
        public string DocumentUrl { get; private set; }

        public DocumentData(string name, string title, int sequenceNumber, string documentUrl)
        {
            Name = name;
            Title = title;
            SequenceNumber = sequenceNumber;
            DocumentUrl = documentUrl;
        }

        public DocumentDataDTO ToDTO()
        {
            return new DocumentDataDTO(Name, Title, SequenceNumber, DocumentUrl);
        }
    }
}
