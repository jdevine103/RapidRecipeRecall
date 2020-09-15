using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;


namespace RapidRecipeRecall.Data
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        // Our added properties
        public List<UserRecipe> MyRecipes
        {
            get
            {

                using (var ctx = new ApplicationDbContext())
                {
                    var query =
                       ctx
                            .UserRecipes
                            .Where(e => e.Recipe.UserId == Id && e.User.Id == Id)
                            .ToList();

                    return EliminateDuplicates(query);
                }
            }
        }

        public List<UserRecipe> MyFavorites
        {
            get
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var query =
                       ctx
                            .UserRecipes
                            .Where(e => e.UserId == Id.ToString() && e.AddToFavorites) // && e.Recipe.UserId != Id
                            .ToList();
                    return query;
                }
            }
        } 
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
        public List<UserRecipe> EliminateDuplicates (List<UserRecipe> query)
        {
            List<int> temp = new List<int>();
            List<UserRecipe> temp2 = new List<UserRecipe>();

            for (int i = 0; i < query.Count; i++)
            {
                int recipeId = query[i].RecipeId;

                if (!temp.Contains(recipeId))
                {
                    temp2.Add(query[i]);
                }
                temp.Add(recipeId);
            }
            return temp2;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<UserRecipe> UserRecipes { get; set; }
        public DbSet<Note> Notes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder
            .Conventions
            .Remove<PluralizingTableNameConvention>();

            modelBuilder
                .Configurations
                .Add(new IdentityUserLoginConfiguration())
                .Add(new IdentityUserRoleConfiguration());
        }
    }
    public class IdentityUserLoginConfiguration : EntityTypeConfiguration<IdentityUserLogin>
    {
        public IdentityUserLoginConfiguration()
        {
            HasKey(iul => iul.UserId);
        }
    }
    public class IdentityUserRoleConfiguration : EntityTypeConfiguration<IdentityUserRole>
    {
        public IdentityUserRoleConfiguration()
        {
            HasKey(iur => iur.UserId);
        }
    }
}