using System;
using nothinbutdotnetprep.infrastructure.searching;

namespace nothinbutdotnetprep.collections
{
    public class IsPublishedAfter : Specification<Movie>
    {
        DateTime date;

        public IsPublishedAfter(DateTime date)
        {
            this.date = date;
        }

        public bool is_satisfied_by(Movie movie)
        {
            return movie.date_published > date;
        }
    }
}