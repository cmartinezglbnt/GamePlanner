namespace GamePlanner.Web.Data
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class SeedDb
    {
        private readonly DataContext context;
        private Random random;

        public SeedDb(DataContext context)
        {
            this.context = context;
            this.random = new Random();
        }

        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();

            if (!this.context.Technology.Any())
            {
                this.AddTechnology("Unix", "Framework");
                this.AddTechnology("Unity", "Designer");
                this.AddTechnology("C#", "Language");
                this.AddTechnology("Java", "Language");
                this.AddTechnology("Phyton", "Language");
                this.AddTechnology("Assembly", "Language");
                this.AddTechnology("PHP", "Language");
                this.AddTechnology("C++", "Language");
                this.AddTechnology("PlayStation 3", "Console");
                this.AddTechnology("PlayStation 4", "Console");
                this.AddTechnology("XboxOne", "Console");
                this.AddTechnology("PC", "Console");
                this.AddTechnology("Nintendo Switch", "Console");
                await this.context.SaveChangesAsync();
            }
        }

        private void AddTechnology(string name, string type)
        {
            this.context.Technology.Add(new Entities.Technology
            {
                Name = name,
                Type = type
            });
        }
    }

}
