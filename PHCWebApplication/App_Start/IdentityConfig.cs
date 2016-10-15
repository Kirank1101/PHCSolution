using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using PHCWebApplication.Models;
using PHC.DataAccess;
using PHC.BAInterfaces.Business;
using PHC.Binder.BackEnd;

namespace PHCWebApplication
{
    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your email service here to send an email.
            return Task.FromResult(0);
        }
    }

    public class SmsService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your SMS service here to send a text message.
            return Task.FromResult(0);
        }
    }


    public class CustomUser : IUser<string>
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string EmailId { get; set; }

        public string Password { get; set; }

        public string StateId { get; set; }
        public string TalukId { get; set; }
        public string DistrictId { get; set; }
        public string VillageId { get; set; }
        public string PHCID { get; set; }
    }

    public class CustomUserManager : UserManager<CustomUser>
    {
        public CustomUserManager(IUserStore<CustomUser> store)
            : base(store)
        {
        }

        public static CustomUserManager Create()
        {
            var manager = new CustomUserManager(new CustomUserStore());
            return manager;
        }

        public override Task<bool> CheckPasswordAsync(CustomUser user, string password)
        {
            return Task.Run(() => MyCheckPasswordAsync());
        }

        private bool MyCheckPasswordAsync()
        {
            return true;
        }
    }

    public class CustomSignInManager : SignInManager<CustomUser, string>
    {
        public CustomSignInManager(CustomUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public static CustomSignInManager Create(IdentityFactoryOptions<CustomSignInManager> options, IOwinContext context)
        {
            return new CustomSignInManager(context.GetUserManager<CustomUserManager>(), context.Authentication);
        }



        public virtual SignInStatus PasswordSignIn(string userName, string password, bool isPersistent, bool shouldLockout)
        {
            CustomUser user = this.UserManager.FindById(userName);
            bool result = this.UserManager.CheckPassword(user, password);
            if (!result)
            {
                return SignInStatus.Failure;
            }
            else
            {
                return SignInStatus.Success;
            }



        }

    }

    public class CustomUserStore : IUserStore<CustomUser>, IUserPasswordStore<CustomUser>
    {
        //private PHCSolutions database;
        ITransactionBusiness objITransactionBusiness = BinderSingleton.Instance.GetInstance<ITransactionBusiness>();
        public CustomUserStore()
        {
            // this.database = new PHCSolutions();
        }

        public void Dispose()
        {
            //this.database.Dispose();
        }

        public Task CreateAsync(CustomUser user)
        {
            // TODO
            //throw new NotImplementedException();

            objITransactionBusiness.AddUser(user.PHCID, null, user.DistrictId, user.TalukId, null, user.Password, user.PHCID, user.EmailId, user.UserName);
            return FindByIdAsync(user.PHCID);
        }

       

        public Task UpdateAsync(CustomUser user)
        {
            // TODO
            throw new NotImplementedException();
        }

        public Task DeleteAsync(CustomUser user)
        {
            // TODO
            throw new NotImplementedException();
        }

        public async Task<CustomUser> FindByIdAsync(string userId)
        {
            CustomUser user = ToCustomUser(objITransactionBusiness.FindByIdAsync(userId)); //await this.database.Where(c => c.UserId == userId).FirstOrDefaultAsync();
            return user;
        }

        private CustomUser ToCustomUser(User user)
        {
            if (user is User)
            {

                return new CustomUser

                {

                    Id = user.UserID,



                    UserName = user.LoginID

                };
            }
            return null;

        }

        public async Task<CustomUser> FindByNameAsync(string userName)
        {
            CustomUser user = ToCustomUser(objITransactionBusiness.FindByIdAsync(userName)); //await this.database.Where(c => c.UserId == userId).FirstOrDefaultAsync();
            return user;
        }

        public Task<string> GetPasswordHashAsync(CustomUser user)
        {
            var identityUser = ToIdentityUser(user);
            var task = userStore.GetPasswordHashAsync(identityUser);
            SetApplicationUser(user, identityUser);
            return task;
        }
        UserStore<IdentityUser> userStore = new UserStore<IdentityUser>(new ApplicationDbContext());

        public Task<bool> HasPasswordAsync(CustomUser user)
        {
            var identityUser = ToIdentityUser(user);
            var task = userStore.HasPasswordAsync(identityUser);
            SetApplicationUser(user, identityUser);
            return task;

        }

        private static void SetApplicationUser(CustomUser user, IdentityUser identityUser)
        {



            user.Id = identityUser.Id;

            user.UserName = identityUser.UserName;

        }

        private IdentityUser ToIdentityUser(CustomUser user)
        {

            return new IdentityUser

            {

                Id = user.Id,



                UserName = user.UserName

            };

        }




        public Task<string> GetPasswordHashAsync(ApplicationUser user)
        {

            var identityUser = ToIdentityUser(user);

            var task = userStore.GetPasswordHashAsync(identityUser);

            SetApplicationUser(user, identityUser);

            return task;

        }

        public Task<bool> HasPasswordAsync(ApplicationUser user)
        {

            var identityUser = ToIdentityUser(user);

            var task = userStore.HasPasswordAsync(identityUser);

            SetApplicationUser(user, identityUser);

            return task;

        }

        public Task SetPasswordHashAsync(ApplicationUser user, string passwordHash)
        {

            var identityUser = ToIdentityUser(user);

            var task = userStore.SetPasswordHashAsync(identityUser, passwordHash);

            SetApplicationUser(user, identityUser);

            return task;

        }

        public Task<string> GetSecurityStampAsync(ApplicationUser user)
        {

            var identityUser = ToIdentityUser(user);

            var task = userStore.GetSecurityStampAsync(identityUser);

            SetApplicationUser(user, identityUser);

            return task;

        }

        public Task SetSecurityStampAsync(ApplicationUser user, string stamp)
        {

            var identityUser = ToIdentityUser(user);

            var task = userStore.SetSecurityStampAsync(identityUser, stamp);

            SetApplicationUser(user, identityUser);

            return task;

        }

        private static void SetApplicationUser(ApplicationUser user, IdentityUser identityUser)
        {

            user.PasswordHash = identityUser.PasswordHash;

            user.SecurityStamp = identityUser.SecurityStamp;

            user.Id = identityUser.Id;

            user.UserName = identityUser.UserName;

        }

        private IdentityUser ToIdentityUser(ApplicationUser user)
        {

            return new IdentityUser

            {

                Id = user.Id,

                PasswordHash = user.PasswordHash,

                SecurityStamp = user.SecurityStamp,

                UserName = user.UserName

            };

        }



        public Task SetPasswordHashAsync(CustomUser user, string passwordHash)
        {
            var identityUser = ToIdentityUser(user);

            var task = userStore.SetPasswordHashAsync(identityUser, passwordHash);

            SetApplicationUser(user, identityUser);

            return task;

        }
    }




    // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
            : base(store)
        {
        }

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
        {
            var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(context.Get<ApplicationDbContext>()));
            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<ApplicationUser>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };

            // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
            // You can write your own provider and plug it in here.
            manager.RegisterTwoFactorProvider("Phone Code", new PhoneNumberTokenProvider<ApplicationUser>
            {
                MessageFormat = "Your security code is {0}"
            });
            manager.RegisterTwoFactorProvider("Email Code", new EmailTokenProvider<ApplicationUser>
            {
                Subject = "Security Code",
                BodyFormat = "Your security code is {0}"
            });

            // Configure user lockout defaults
            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;

            manager.EmailService = new EmailService();
            manager.SmsService = new SmsService();
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider = new DataProtectorTokenProvider<ApplicationUser>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }
    }

    public class ApplicationSignInManager : SignInManager<ApplicationUser, string>
    {
        public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager) :
            base(userManager, authenticationManager) { }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(ApplicationUser user)
        {
            return user.GenerateUserIdentityAsync((ApplicationUserManager)UserManager);
        }

        public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
        {
            return new ApplicationSignInManager(context.GetUserManager<ApplicationUserManager>(), context.Authentication);
        }
    }
}
