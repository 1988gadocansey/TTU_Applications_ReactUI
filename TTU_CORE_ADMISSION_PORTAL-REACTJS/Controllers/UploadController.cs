    using System.Drawing;
    using System.Net.Mime;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TTU_CORE_ADMISSION_PORTAL_REACTJS.Data;
using TTU_CORE_ADMISSION_PORTAL_REACTJS.Models;
using TTU_CORE_ADMISSION_PORTAL_REACTJS.Services;

    namespace TTU_CORE_ADMISSION_PORTAL_REACTJS.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UploadController : ControllerBase
    {
        /*private readonly ILogger<UploadController> _logger;
        private string serverUrl = "https://photos.ttuportal.com/public/albums/thumbnails";
        private readonly IConfiguration _configuration;

        private readonly IWebHostEnvironment _hostingEnvironment;

        private UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _dbContext;
        private readonly IHelper _helper;


        public UploadController(ILogger<UploadController> logger, IWebHostEnvironment environment,
            UserManager<ApplicationUser> userManager, ApplicationDbContext dbContext, IHelper helper,
            IConfiguration configuration)
        {
            _logger = logger;
            _hostingEnvironment = environment;
            _userManager = userManager;
            _dbContext = dbContext;
            _helper = helper;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return Ok();
        }


        [HttpPost, Obsolete]
        public async Task<IActionResult> UploadAsync(IFormFile file)
        {
            if (Request.Form.Files.Count > 0)
            {
                var applicationUser = await _userManager.GetUserAsync(User);

                var applicationNo = applicationUser?.FormNo;

                var fileName = file.FileName;

                var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "pictures");

               
                var extension = Path.GetExtension(fileName).ToLower();


                var PictureToSave = applicationNo + extension;

                var filePath = Path.Combine(uploads, PictureToSave);

                if (file.IsImage())
                {
                    if (file.Length <= 250000)
                    {
                        using var image = MediaTypeNames.Image.Load(file.OpenReadStream());
                       
                        image.Mutate(img => img.AutoOrient());
                        image.Mutate(x => x.Resize(192, 192));
                        //image.Mutate(x => x.Crop(189, 189));

                        try
                        {
                             

                            Console.WriteLine(filePath);
                            image.Save(filePath);

                            var port = Convert.ToInt32(_configuration["sftpport"]);
                            var host = _configuration["sftphost"];
                            var username = _configuration["sftpusername"];
                            var password = _configuration["sftppassword"];

                            if (_helper.SendFileToServer(host, port, username, password, filePath) == 1)
                            {
                                var fileInfo = new FileInfo(filePath);
                                fileInfo.Delete();
                            }
                            else
                            {
                                return Ok(new {message="Photo Server down!!.. check later",type="error"});
                            }

                            var user = await _userManager.GetUserAsync(User);


                            user.PictureUploaded = 1;

                            await _dbContext.SaveChangesAsync();
                        }
                        catch (Exception exp)
                        {
                            System.Console.WriteLine("Exception generated when uploading file - " + exp.Message);

                          
                            return Ok(new {message="Error reaching picture server",type="error"});
                        }

                        return Ok(new {message="Picture uploaded successfully!!",type="success"});
                    }
                    else
                    {
                       
                        return Ok(new {message="File size too big. Upload only file of size less than 251KB!!",type="error"});

                    }
                }
                else
                {
                   
                    return Ok(new {message="Upload only JPEG Photograph",type="error"});

                }
            }
            else
            {
             
                return Ok(new {message="No file uploaded.",type="error"});
                
            }
        }

*/
        
    }
}