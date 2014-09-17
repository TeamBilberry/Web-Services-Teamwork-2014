namespace FeedbackSystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class User : IdentityUser
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

        // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
