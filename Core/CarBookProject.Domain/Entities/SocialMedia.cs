using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Domain.Entities
{
    public class SocialMedia
    {
        public int SocialMediaId { get; set; }
        public int Name { get; set; }
        public int Url { get; set; }
        public int Icon { get; set; }
    }
}
