﻿using System;

namespace HRSolution.Data.Models
{
    public class Leave : BaseEntity
    {
        public Guid LeaveId { get; set; }
        public string Comments { get; set; }
        public string Reference { get; set; }
        public string Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int NoOfDays { get; set; }
        public Guid StatusId { get; set; }
        public Status Status { get; set; }
        public Guid AttachmentId { get; set; }
        public virtual Attachment Attachment { get; set; }
    }
}
