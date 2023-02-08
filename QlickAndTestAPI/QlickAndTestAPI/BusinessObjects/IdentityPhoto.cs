using System.ComponentModel.DataAnnotations.Schema;

namespace QlickAndTestApi.BusinessObjects
{
    public class IdentityPhoto
    {
        public int IdentityPhotoID { get; set; }
        public byte[] FileBytes { get; set; }
        public int IdentityID { get; set; }
        public string Extension { get; set; }

    }
}
