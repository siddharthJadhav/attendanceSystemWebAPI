namespace AttendanceSystemWebAPI.Models
{
    public class ContactInfo
    {
        public int ID { get; set; }
            
        public int UserID { get; set; }

        public string Type { get; set; }

        public string Value { get; set; }
    }
}
