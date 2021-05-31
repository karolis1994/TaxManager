using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaxManager.Domain.Taxes;

namespace TaxManager.DataAccessLayer.EntityTypeConfigurations
{
    internal sealed class MunicipalityTaxEntityTypeConfiguration : IEntityTypeConfiguration<MunicipalityTax>
    {
        public void Configure(EntityTypeBuilder<MunicipalityTax> builder)
        {
            builder.ToTable("MunicipalityTax", TaxManagerContext.SchemaName);
            builder.HasKey(e => e.Id);

            builder.Property(e => e.MunicipalityName).HasMaxLength(100).IsRequired();
            builder.Property(e => e.TaxValue).HasColumnType("decimal(10,4)");
        }
    }
}
