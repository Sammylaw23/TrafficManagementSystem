namespace TrafficManagementSystem.Application.DTOs.Offence
{
    public class NewOffenceRequest
    {
        //public int OffenceTypeId { get; set; }
        public Guid? Id { get; set; }
        public string? OffenceTypeCode { get; set; }
        public string? OffenderName { get; set; }
        public string? PlateNumber { get; set; }
        public string? LicenseNo { get; set; }

        public string? CreatedBy { get; set; } //TODO: get this from Login
        public DateTime? ReportDate { get; set; } 
    }
}
