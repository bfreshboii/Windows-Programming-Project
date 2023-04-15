using System;
using System.Collections.Generic;

namespace PROG2500_AF_IMDB.Project.Models;

public partial class Rating
{
    public string TitleId { get; set; } = null!;

    public decimal? AverageRating { get; set; }

    public int? NumVotes { get; set; }

    public virtual Title Title { get; set; } = null!;

    //public string FormattedRating
    //{

    //    get
    //    {
    //        return string.Format("Rating: {0}", AverageRating);
    //    }
    //}
}