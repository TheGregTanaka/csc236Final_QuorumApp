using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler
{
    public class WorkTeam : Team
    {
        /**
         * Which takes all members as args
         */
        public WorkTeam(int i, string n, int at) : base(i, n, at)
        {
            //casting the enum to an int is not really neccessary here, but is more
            // verbose and avoids "Magic numbers"
            this.TeamTypeID = (int)TypeTeam.WorkT;
        }
        /**
         * Copy constructor
         */
        public WorkTeam(Team t) : base(t)
        {
            this.TeamTypeID = (int)TypeTeam.WorkT;
        }

        /**
         * Calls parent Equals to compare two teams
         */
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        /**
         * Calls parent got get Hash Code
         */
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /**
         * Returns team name as a string
         */
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
