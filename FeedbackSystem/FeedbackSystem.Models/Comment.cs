namespace FeedbackSystem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Comments on feedback posts
    /// </summary>
    public class Comment
    {
        public int Id { get; set; }

        [Required]
        public DateTime PostDate { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(250)]
        public string Text { get; set; }

        [Required]
        public string UserId { get; set; }

        public User User { get; set; }
		
		[Required]
		public int FeedbackId { get; set; }
		
		public Feedback Feedback { get; set;}
    }
}
