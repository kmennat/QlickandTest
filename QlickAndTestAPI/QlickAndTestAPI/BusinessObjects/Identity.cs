using System.ComponentModel.DataAnnotations.Schema;

namespace QlickAndTestApi.BusinessObjects
{
    public class Identity
    {       
        public int IdentityID { get; set; }
        public string FirstName { get; set; }
        public string ?LastName { get; set; }
        public int ?CompanyID { get; set; }
        public string ?Position { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string ?Phone { get; set; }
        public int IdentityTypeID { get; set; }
        public string ?CustomizableOne { get; set; }
        public string ?CustomizableTwo { get; set; }
        public DateTime? LastUpdated { get; set; }
        public bool ?IsActive { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? CardID { get; set; }
        public IdentityPhoto? IdentityPhoto { get; set; }

    }
}
