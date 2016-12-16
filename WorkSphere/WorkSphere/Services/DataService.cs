using System;
using System.Collections.Generic;
using WorkSphere.Enums;
using WorkSphere.Interfaces;
using WorkSphere.Models;
using Xamarin.Forms;

namespace WorkSphere.Services
{
    public class DataService : IDataService
    {
        public IEnumerable<Coworker> GetCoworkers()
        {
            return new List<Coworker>()
            {
                new Coworker()
                {
                    SurName = "Baron",
                    LastName = "Alexis",
                    Id = Guid.NewGuid(),
                    Status = CoworkerStatus.Work,
                    Image = ImageSource.FromResource("WorkSphere.Images.Users.32.jpg")
                },
                new Coworker()
                {
                    SurName = "Abram",
                    LastName = "Corinne",
                    Id = Guid.NewGuid(),
                    Status = CoworkerStatus.Work,
                    Image = ImageSource.FromResource("WorkSphere.Images.Users.65.jpg")
                },
                new Coworker()
                {
                    SurName = "Acosta",
                    LastName = "Tim",
                    Id = Guid.NewGuid(),
                    Status = CoworkerStatus.On_Break,
                    Image = ImageSource.FromResource("WorkSphere.Images.Users.35.jpg")
                },
                new Coworker()
                {
                    SurName = "Artega",
                    LastName = "Devid",
                    Id = Guid.NewGuid(),
                    Status = CoworkerStatus.None,
                    Image = ImageSource.FromResource("WorkSphere.Images.Users.62.jpg")
                },
                new Coworker()
                {
                    SurName = "Garza",
                    LastName = "Ruby",
                    Id = Guid.NewGuid(),
                    Status = CoworkerStatus.Run_Report,
                    Image = ImageSource.FromResource("WorkSphere.Images.Users.2.jpg")
                },
                new Coworker()
                {
                    SurName = "Matthews",
                    LastName = "Patsy",
                    Id = Guid.NewGuid(),
                    Status = CoworkerStatus.Work,
                    Image = ImageSource.FromResource("WorkSphere.Images.Users.47.jpg")
                },
                new Coworker()
                {
                    SurName = "Mitchell",
                    LastName = "Dennis",
                    Id = Guid.NewGuid(),
                    Status = CoworkerStatus.On_Break,
                    Image = ImageSource.FromResource("WorkSphere.Images.Users.88.jpg")
                },
                new Coworker()
                {
                    SurName = "Frazier",
                    LastName = "Rafael",
                    Id = Guid.NewGuid(),
                    Status = CoworkerStatus.Work,
                    Image = ImageSource.FromResource("WorkSphere.Images.Users.94.jpg")
                },
                new Coworker()
                {
                    SurName = "Webb",
                    LastName = "Yvonne",
                    Id = Guid.NewGuid(),
                    Status = CoworkerStatus.None,
                    Image = ImageSource.FromResource("WorkSphere.Images.Users.96.jpg")
                },
                new Coworker()
                {
                    SurName = "Ward",
                    LastName = "Paula",
                    Id = Guid.NewGuid(),
                    Status = CoworkerStatus.Work,
                    Image = ImageSource.FromResource("WorkSphere.Images.Users.3.jpg")
                },
                new Coworker()
                {
                    SurName = "Rice",
                    LastName = "Chester",
                    Id = Guid.NewGuid(),
                    Status = CoworkerStatus.Run_Report,
                    Image = ImageSource.FromResource("WorkSphere.Images.Users.71.jpg")
                },
                new Coworker()
                {
                    SurName = "Sanchez",
                    LastName = "Theodore",
                    Id = Guid.NewGuid(),
                    Status = CoworkerStatus.Run_Report,
                    Image = ImageSource.FromResource("WorkSphere.Images.Users.51.jpg")
                },
            };
        }
    }
}
