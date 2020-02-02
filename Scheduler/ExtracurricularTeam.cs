using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler
{
    class ExtracurricularTeam : Team
    {
        /**
         * Constructor which takes all member details
         */
        public ExtracurricularTeam(int i, string n, int at) : base(i, n, at)
        {   //casting the enum to an int is not really neccessary here, but is more
            // verbose and avoids "Magic numbers"
            this.TeamTypeID = (int)TypeTeam.ExtracurricularT;
        }

        /**
         * Copy constructor
         */
        public ExtracurricularTeam(Team t) : base(t)
        {
            this.TeamTypeID = (int)TypeTeam.ExtracurricularT;
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
