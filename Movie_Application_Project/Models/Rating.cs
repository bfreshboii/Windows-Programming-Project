using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG2500_AF_IMDB.Project.Models;

public partial class Rating
{

    public string FormattedRating
    {

        get
        {
            return string.Format("Rating: {0:N2}", AverageRating);
        }
    }
}
