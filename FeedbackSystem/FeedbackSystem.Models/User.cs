namespace FeedbackSystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class User
    {
        private ICollection<Feedback> feedbacks;
        private ICollection<Comment> comments;
        private ICollection<UrgentProblem> urgentProblems;

        public User()
        {
            this.Comments = new HashSet<Comment>();
            this.Feedbacks = new HashSet<Feedback>();
            this.UrgentProblems = new HashSet<UrgentProblem>();
        }

        [Required]
        public UserStatusType Status { get; set; }

        public virtual ICollection<Feedback> Feedbacks
        {
            get { return this.feedbacks; }
            set { this.feedbacks = value; }
        }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }
        public virtual ICollection<UrgentProblem> UrgentProblems
        {
            get { return this.urgentProblems; }
            set { this.urgentProblems = value; }
        }
    }
}
