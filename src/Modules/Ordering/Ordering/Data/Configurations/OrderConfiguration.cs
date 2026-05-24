namespace Ordering.Data.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(o => o.CustomerId);

            builder.HasIndex(e => e.OrderName)
                .IsUnique();

            builder.Property(e => e.OrderName)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasMany(s => s.Items)
                .WithOne()
                .HasForeignKey(si => si.OrderId);

            builder.ComplexProperty(o => o.ShippingAddress, addresBuilder =>
            {
                addresBuilder.Property(a => a.FirstName)
                    .HasMaxLength(50)
                    .IsRequired();

                addresBuilder.Property(a => a.LastName)
                    .HasMaxLength(50)
                    .IsRequired();

                addresBuilder.Property(a => a.AddressLine)
                    .HasMaxLength(180)
                    .IsRequired();

                addresBuilder.Property(a => a.Country)
                    .HasMaxLength(50);

                addresBuilder.Property(a => a.State)
                    .HasMaxLength(50);

                addresBuilder.Property(a => a.ZipCode)
                    .HasMaxLength(5)
                    .IsRequired();

            });

            builder.ComplexProperty(o => o.BillingAddress, addresBuilder =>
            {
                addresBuilder.Property(a => a.FirstName)
                    .HasMaxLength(50)
                    .IsRequired();

                addresBuilder.Property(a => a.LastName)
                    .HasMaxLength(50)
                    .IsRequired();

                addresBuilder.Property(a => a.AddressLine)
                    .HasMaxLength(180)
                    .IsRequired();

                addresBuilder.Property(a => a.Country)
                    .HasMaxLength(50);

                addresBuilder.Property(a => a.State)
                    .HasMaxLength(50);

                addresBuilder.Property(a => a.ZipCode)
                    .HasMaxLength(5)
                    .IsRequired();
            });

            builder.ComplexProperty(o => o.Payment, paymentBuilder =>
            {
                paymentBuilder.Property(p => p.CardName)
                    .HasMaxLength(50);

                paymentBuilder.Property(p => p.CardNumber)
                    .HasMaxLength(24)
                    .IsRequired();

                paymentBuilder.Property(p => p.Expiration)
                    .HasMaxLength(10);

                paymentBuilder.Property(p => p.CVV)
                    .HasMaxLength(3);

                paymentBuilder.Property(p => p.PaymentMethod);
            });
        }
    }
}
