using System;
namespace HneuConferenсe
{
    public class ParticipantModel
    {
        public ParticipantModel()
        {
        }

        public string CompanyName { get; set; }
        public string ReportName { get; set; }
        public string ReporterName { get; set; }
        public string Section { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string LeadName { get; set; }
        public bool NeededSendEmail { get; set; }
        public bool NeededHostel { get; set; }
    }
}
