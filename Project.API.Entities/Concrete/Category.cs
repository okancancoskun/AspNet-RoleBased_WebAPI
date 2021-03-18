using Project.API.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.API.Entities.Concrete
{
    public class Category : ITable
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
