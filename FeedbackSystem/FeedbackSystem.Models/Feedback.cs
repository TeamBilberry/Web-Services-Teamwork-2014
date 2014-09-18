namespace FeedbackSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Enums;

    /// <summary>
    /// Praises and complaints to the work of the company
    /// </summary>
    public class Feedback
    {
        private ICollection<Comment> comments;

        public Feedback()
        {
            this.comments = new HashSet<Comment>();
        }

        public int Id { get; set; }

        [Required]
        public FeedbackType Type { get; set; }

        [Required]
        public DateTime PostDate { get; set; }

        [Required]
        [MinLength(10)]
        public string Text { get; set; }

        public string UserId { get; set; }
		
        public User User { get; set; }

        /// <summary>
        /// Specifies whether the feedback is on an employee,
        /// department or the entire company
        /// </summary>
        public string AddressedTo { get; set; }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }
    }
}
