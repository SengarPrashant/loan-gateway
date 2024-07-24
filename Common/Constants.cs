namespace LoanGeteway.Common
{
    public class Message
    {
        public static string UnknownError { get; set; } = "Unable to process the request at the moment.";
        public static string Success { get; set; } = "Request processed successfully";
    }
    public class Status
    {
        public static string Submitted { get; set; } = "SUBMITTED";
        public static string InReview { get; set; } = "IN-REVIEW";
        public static string Approved { get; set; } = "APPROVED";
        public static string PartialApproved { get; set; } = "PARTIALAPPROVED";
        public static string Rejected { get; set; } = "REJECTED";
    }
}
