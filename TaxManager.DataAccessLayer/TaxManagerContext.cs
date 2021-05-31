using Microsoft.EntityFrameworkCore;
using TaxManager.DataAccessLayer.EntityTypeConfigurations;
using TaxManager.Domain.Core;
using TaxManager.Domain.Taxes;

namespace TaxManager.DataAccessLayer
{
    public class TaxManagerContext : DbContext, IUnitOfWork
    {
        public TaxManagerContext(DbContextOptions<TaxManagerContext> options)
            : base(options)
        {
        }

        public DbSet<MunicipalityTax> MunicipalityTaxes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MunicipalityTaxEntityTypeConfiguration());
        }

        public const string SchemaName = "TaxManager";
    }
}
