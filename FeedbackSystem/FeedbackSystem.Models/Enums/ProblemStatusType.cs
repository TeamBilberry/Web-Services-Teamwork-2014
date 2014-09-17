namespace FeedbackSystem.Models
{
    public enum ProblemStatusType
    {
        // Yet to be examined
        Awaiting, 
        // Is being processed 
        Pending,
        // Awaiting to be approved by user as solved
        Processed,
        // Resolved by the company and closed by the user
        Solved,
        // Has not been approved by user as solved
        Unsolved,
        // Will not be processed for whatever reason
        Closed
    }
}
