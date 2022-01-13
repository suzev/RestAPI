namespace PaymentService.Dtos
{
    public class PaymentOutput
    {
        public int PaymentID { get; set; }
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        public float Bill { get; set; }
    }
}
