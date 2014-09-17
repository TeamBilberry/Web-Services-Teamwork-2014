namespace FeedbackSystem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Comments on feedback posts
    /// </summary>
    public class Comment
    {
        public int ID { get; set; }

        [Required]
        public DateTime PostDate { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(250)]
        public string Text { get; set; }

        [Required]
        public int UserID { get; set; }
    }
}
