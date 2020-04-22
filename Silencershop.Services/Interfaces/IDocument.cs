
namespace Silencershop.ServiceLayer.Interfaces
{
    public class IDocument
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string CreationDate { get; set; }
        public string ExpirationDate { get; set; }
        public int DocumentStatusId { get; set; }
        public string TSN { get; set; }
        public bool IsFlagged { get; set; }
        public bool IsAssigned { get; set; }
        public int CreatedByUser { get; set; }
        public int VersionNumber { get; set; }
    }

}
