using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG2500_AF_IMDB.Project.Models;

    public partial class Name
    {

    public string FormattedBirthYear
    {
        get
        {
            return string.Format("Birth Year: ", BirthYear);
        }
    }

    public string FormattedDeathYear
    {
        get
        {
            return string.Format("      Death Year: ", DeathYear);
        }
    }
}

