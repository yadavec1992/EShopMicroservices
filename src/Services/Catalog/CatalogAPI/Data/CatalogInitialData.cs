using Marten.Schema;

namespace Catalog.API.Data
{
    public class CatalogInitialData : IInitialData
    {
        public async Task Populate(IDocumentStore store, CancellationToken cancellation)
        {
            using var session=store.LightweightSession();
            if(await session.Query<Product>().AnyAsync(cancellation))
            {
                return;
            }
            session.Store<Product>(GetPreconfiguredProduct());
            await session.SaveChangesAsync(cancellation);
        }

        private static IEnumerable<Product> GetPreconfiguredProduct()
        {
            return new List<Product>
            {
                new()
                {
                    Id = Guid.Parse("8f8c7f3b-7f6d-4c0a-9e4f-1c2a8b6d5e10"),
                    Name = "Wireless Noise-Cancelling Headphones",
                    Category = new List<string> { "Audio", "Electronics" },
                    Description = "Over-ear wireless headphones with active noise cancellation and up to 30 hours of battery life.",
                    ImageFile = "headphones.png",
                    Price = 129.99m
                },
                new()
                {
                    Id = Guid.Parse("2a4d6e8f-1b3c-4d5e-9f70-6a8b2c4d5e11"),
                    Name = "Mechanical Gaming Keyboard",
                    Category = new List<string> { "Accessories", "Gaming" },
                    Description = "Full-size mechanical keyboard with RGB backlighting, programmable keys, and a detachable wrist rest.",
                    ImageFile = "gaming-keyboard.png",
                    Price = 89.50m
                },
                new()
                {
                    Id = Guid.Parse("6c8e0a2b-4d5f-4a6b-8c9d-0e1f2a3b4c12"),
                    Name = "Portable Bluetooth Speaker",
                    Category = new List<string> { "Audio", "Portable" },
                    Description = "Compact waterproof Bluetooth speaker with rich sound and up to 12 hours of playback.",
                    ImageFile = "bluetooth-speaker.png",
                    Price = 59.95m
                },
                new()
                {
                    Id = Guid.Parse("9d1f3b5c-7e8a-4b2c-9d0e-1f3a5b7c8d13"),
                    Name = "Smart Fitness Watch",
                    Category = new List<string> { "Wearables", "Fitness" },
                    Description = "Fitness smartwatch with heart-rate monitoring, sleep tracking, GPS, and a seven-day battery.",
                    ImageFile = "fitness-watch.png",
                    Price = 149.00m
                },
                new()
                {
                    Id = Guid.Parse("3e5a7c9f-0b1d-4f2a-8c6e-7d9b0a1c2e14"),
                    Name = "USB-C Laptop Dock",
                    Category = new List<string> { "Accessories", "Computers" },
                    Description = "Universal USB-C dock with dual display support, Ethernet, USB ports, and 100W power delivery.",
                    ImageFile = "usb-c-dock.png",
                    Price = 109.99m
                }
            };
        }
    }
}
