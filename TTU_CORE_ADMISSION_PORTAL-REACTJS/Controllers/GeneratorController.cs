using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TTU_CORE_ADMISSION_PORTAL_REACTJS.Data;
using TTU_CORE_ADMISSION_PORTAL_REACTJS.Models;
namespace TTU_CORE_ADMISSION_PORTAL_REACTJS.Controllers
{
    public class GeneratorController : Controller
    {
        // GET: /<controller>/
        private readonly IPasswordHasher<ApplicationUser> _passwordHasher;
        private readonly ILogger<GeneratorController> _logger;

        private readonly ApplicationDbContext _dbContext;
        private UserManager<ApplicationUser> _userManager;

        public GeneratorController(ILogger<GeneratorController> logger, IPasswordHasher<ApplicationUser> passwordHasher,
            UserManager<ApplicationUser> userManager, ApplicationDbContext dbContext)
        {
            _passwordHasher = passwordHasher;
            _logger = logger;
            _userManager = userManager;
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> IndexAsync(int? quantity, string? type, string? owner)
        {
            //  Console.Write("hello");
            //  Console.WriteLine(quantity);

            for (int a = 0; a < quantity; a++)
            {
                var Pin = GetPin();
                var Serial = GetSerial();


                //ApplicationUser user = new();
                ApplicationUser applicationUser = new();
                var guid = Guid.NewGuid();
                applicationUser.Id = guid.ToString();
                applicationUser.UserName = Serial + a;
                applicationUser.Email = Serial + a + "@ttu.edu.gh";
                applicationUser.NormalizedUserName = Serial + a;
                applicationUser.Year = (DateTime.Now.Year).ToString();
                applicationUser.Pin = Pin;
                applicationUser.SoldBy = owner.ToUpper();
                applicationUser.Sold = 0;
                applicationUser.Started = 0;
                applicationUser.Type = type.ToUpper();
                applicationUser.EmailConfirmed = true;
                applicationUser.NormalizedEmail = Serial + "@ttu.edu.gh" + a;

                var hashedPassword = _passwordHasher.HashPassword(applicationUser, Pin);
                applicationUser.SecurityStamp = Guid.NewGuid().ToString();
                applicationUser.PasswordHash = hashedPassword;

                var result = _userManager.CreateAsync
                    (applicationUser).Result;

                if (result.Succeeded)
                {
                }

                Console.WriteLine("a is " + a);
            }

            await _dbContext.SaveChangesAsync();

            return Ok("Done");
        }

        private static string GetPin()
        {
            var str = "2F934678ABCDGHJKLMNPRSTUVWXY";

            var shuffled = Shuffle(str);

            var vcode = shuffled.Substring(0, 9);

            var real = vcode.ToUpper();

            return real;
        }

        private static string GetSerial()
        {
            var str = "ABCDEFGHJKLMNPRSTUVWXYZ2346789";

            var shuffled = Shuffle(str);
            var vcode = shuffled.Substring(0, 4);

            var real = vcode.ToUpper();

            return "TTU" + (DateTime.Now.Year).ToString() + real;
        }

        private static string Shuffle(string str)
        {
            //List<char> list1 = new List<char>(array);

            //var rnd = new Random();
            //var randomized = array.ToCharArray().OrderBy(item => rnd.Next());

            //return randomized.ToString();

            // The source string

            // The random number sequence
            var num = new Random();

            // Create new string from the reordered char array
            var rand = new string(str.ToCharArray().OrderBy(s => (num.Next(2) % 2) == 0).ToArray());

            return rand;
        }
    }
}