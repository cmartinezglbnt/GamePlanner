﻿namespace GamePlanner.Web.Data
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

            if (!this.context.Gender.Any())
            {
                this.AddGender("Action", "Fight games based on repetitive actions.");
                this.AddGender("Arcade", "Platforms, labyrinths and adventures. The user must pass screens to keep playing.");
                this.AddGender("Sport", "Football, tennis, basketball, driving, among others.");
                this.AddGender("Strategy", "Adventures, roles, war games. Consists to create and strategy to win to your opponent.");
                this.AddGender("Simulation", "Flights, instrumental, driving, among others. Allow to the user to experiment how something works like in real life.");
                this.AddGender("Table games", "Cheese, Skills, questions and answers, etcetera.");
                this.AddGender("Music games", "Games focused to interact between the player with music and follow music patterns.");
                await this.context.SaveChangesAsync();
            }

            if (!this.context.Public.Any())
            {
                this.AddPublic("Early Childhood (EC)", "Games focused to children with 3+ years old.");
                this.AddPublic("Everyone (E)", "Games focused to children with 6+ years old.");
                this.AddPublic("Everyone 10+ (E10+)", "Games focused to with between 10+ years old.");
                this.AddPublic("Teen (T)", "Games focused to people with 13+ years old.");
                this.AddPublic("Mature 17+ (M 17+)", "Games focused to people with 17+ years old.");
                this.AddPublic("Adults Only 17+ (AO 18+)", "Games focused to people with 18+ years old.");
                this.AddPublic("Rating Pending (RP)", "Waiting for a final rating.");
                await this.context.SaveChangesAsync();
            }

            if(!this.context.Meeting.Any())
            {
                this.AddMeeting(3, "Johann Jimenez, Fabio Martinez, Cristian Florez");
                this.AddMeeting(2, "Alex Naranjo, Salvador Roque");
                this.AddMeeting(4, "Mairim Verson, Ibis Barrios, Alain Maldonado, Leo Villalonga");
                await this.context.SaveChangesAsync();
            }

            if(!this.context.Idea.Any())
            {
                this.AddIdea("Test Idea 1", "test Features 1", 1, 1, 1);
                this.AddIdea("Test Idea 2", "test Features 2", 2, 2, 2);
                await this.context.SaveChangesAsync();
            }
        }

        private void AddIdea(string description, string features, int genderId, int meetingId, int publicId)
        {
            this.context.Idea.Add(new Entities.Idea
            {
                Description = description,
                Features = features,
                GenderId = genderId,
                MeetingId = meetingId,
                PublicId = publicId,
                RegistrationDate = DateTime.Now
            });
        }

        private void AddMeeting(int totalParticipants, string participants)
        {
            this.context.Meeting.Add(new Entities.Meeting
            {
                Num_Participants = totalParticipants,
                Participants = participants,
                RegistrationDate = DateTime.Now
            });
        }

        private void AddTechnology(string name, string type)
        {
            this.context.Technology.Add(new Entities.Technology
            {
                Name = name,
                Type = type
            });
        }

        private void AddGender(string name, string description)
        {
            this.context.Gender.Add(new Entities.Gender
            {
                Name = name,
                Description = description
            });
        }

        private void AddPublic(string name, string description)
        {
            this.context.Public.Add(new Entities.Public
            {
                Name = name,
                Description = description
            });
        }
    }

}
