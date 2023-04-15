using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG2500_AF_IMDB.Project.Models;

    public partial class Title
    {

    public string FormattedTitle
    {
        get
        {
            return string.Format("Original Title: {0}", Rating);
        }
    }
}

