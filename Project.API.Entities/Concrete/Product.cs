using Project.API.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.API.Entities.Concrete
{
    public class Product : ITable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int AuthorId { get; set; }
        public AppUser Author { get; set; }

    }
}
