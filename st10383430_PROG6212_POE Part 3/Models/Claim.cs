namespace st10383430_PROG6212_POE.Models
{
    public class Claim
    {
        public int ClaimID { get; set; }
        public int LecturerID { get; set; }
        public decimal HoursWorked { get; set; }
        public decimal HourlyRate { get; set; }
        public decimal TotalPayment { get; set; }
        public string Status { get; set; } = "Pending";
        public string UploadedFilePath { get; set; }
        public DateTime SubmissionDate { get; set; }

        public Lecturer Lecturer { get; set; }

    

    }
}
