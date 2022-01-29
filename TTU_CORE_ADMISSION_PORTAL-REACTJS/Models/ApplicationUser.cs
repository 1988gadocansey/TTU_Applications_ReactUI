using Microsoft.AspNetCore.Identity;

namespace TTU_CORE_ADMISSION_PORTAL_REACTJS.Models;

public class ApplicationUser : IdentityUser
{
    public string FormNo { get; set; }
    public int Started { get; set; }
    public string FullName { get; set; }
    public string Type { get; set; }
    public int Sold { set; get; }
    public string SoldBy { set; get; }
    public string Branch { set; get; }
    public string Teller { set; get; }
    public string TellerPhone { set; get; }
    public int FormCompleted { set; get; }
    public int PictureUploaded { set; get; }
    public int Finalized { set; get; }
    public string Year { get; set; }
    public bool ResultUploaded { get; set; }
    public bool Admitted { get; set; }
    public string Pin { get; set; }
    public DateTimeOffset LastLogin { set; get; }
    //public byte[] ProfilePicture { get; set; }


}