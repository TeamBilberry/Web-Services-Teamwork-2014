namespace FeedbackSystem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Enums;

    /// <summary>
    /// Issues which affect the user in a negative way and need to be addressed
    /// until a concrete date in the future
    /// </summary>
    public class UrgentProblem
    {
        public int Id { get; set; }

        [Required]
        public DateTime PostDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public ProblemStatusType Status { get; set; }

        [Required]
        [MinLength(10)]
        public string Text { get; set; }

        [Required]
        public string UserId { get; set; }

        public User User { get; set; }
    }
}
