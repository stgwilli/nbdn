using System;
using System.Collections.Generic;
using nothinbutdotnetprep.infrastructure.extensions;

namespace nothinbutdotnetprep.collections
{
    public class MovieLibrary
    {
        IList<Movie> list_of_movies;

        public MovieLibrary(IList<Movie> list_of_movies)
        {
            this.list_of_movies = list_of_movies;
        }

        public IEnumerable<Movie> all_movies()
        {
            return list_of_movies.one_at_a_time();
        }

        public void add(Movie movie)
        {
            if (already_contains(movie)) return;

            list_of_movies.Add(movie);
        }

        public IEnumerable<Movie> sort_all_movies_by_title_descending()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> sort_all_movies_by_title_ascending()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> sort_all_movies_by_movie_studio_and_year_published()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> sort_all_movies_by_date_published_descending()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> sort_all_movies_by_date_published_ascending()
        {
            throw new NotImplementedException();
        }

        private bool already_contains(Movie movie)
        {
            return list_of_movies.Contains(movie);
        }
    }
}