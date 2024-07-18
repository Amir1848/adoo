using Adoo.Base;
using Microsoft.EntityFrameworkCore;

namespace Adoo.Models
{
    public class Interest : Entity
    {
        public string Title { get; set; }   
        public string Description { get; set; }
        public string Link { get; set; }
    }
}
