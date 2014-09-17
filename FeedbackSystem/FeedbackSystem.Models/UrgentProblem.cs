namespace FeedbackSystem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Issues which affect the user in a negative way and need to be addressed
    /// untill a concrete date in the future
    /// </summary>
    public class UrgentProblem
    {
        public int ID { get; set; }

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
        public int UserID { get; set; }
    }
}
