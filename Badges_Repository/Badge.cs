using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badges_Repository
{
    public class Badge
    {
        public int BadgeID { get; set; }
        List<Badge> AccessDoors = new List<Badge>();
        
        public Badge()
        {
                
        } 
        public Badge(int badgeId, List<Badge> accessDoors)
        {
            BadgeID = badgeId;
            AccessDoors = accessDoors;
        }
    }
}
