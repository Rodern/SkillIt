using System;
using System.Collections.Generic;

#nullable disable

namespace SkillIT_Models.DatabaseModels
{
    public partial class Testimonial
    {
        public int TestimonialId { get; set; }
        public long UserId { get; set; }
        public string Content { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsApproved { get; set; }

        public virtual User User { get; set; }
    }
}
