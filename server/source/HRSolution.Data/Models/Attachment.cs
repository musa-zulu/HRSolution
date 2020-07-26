using System;

namespace HRSolution.Data.Models
{
    public class Attachment : BaseEntity
    {
        public Guid AttachmentId { get; set; }
        public byte[] AttachmentBytes { get; set; }
    }
}
