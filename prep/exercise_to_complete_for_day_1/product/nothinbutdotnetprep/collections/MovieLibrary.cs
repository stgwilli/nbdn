using System;
using System.Collections.Generic;
using nothinbutdotnetprep.infrastructure.extensions;

namespace nothinbutdotnetprep.collections
{
    public class MovieLibrary
    {
        readonly IList<Movie> list_of_movies;

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

        bool already_contains(Movie movie)
        {
            return list_of_movies.Contains(movie);
        }

        
        public IEnumerable<Movie> sort_all_movies_by_title_descending()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> all_movies_published_by_pixar()
        {
            return (list_of_movies.Search(p => p.production_studio == ProductionStudio.Pixar));
        }

        public IEnumerable<Movie> all_movies_published_by_pixar_or_disney()
        {
            return
                (list_of_movies.Search(
                           p => p.production_studio == ProductionStudio.Pixar
                        || p.production_studio == ProductionStudio.Disney));
        }

        public IEnumerable<Movie> sort_all_movies_by_title_ascending()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> sort_all_movies_by_movie_studio_and_year_published()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> all_movies_not_published_by_pixar()
        {
            return list_of_movies.Search(p => p.production_studio != ProductionStudio.Pixar);
        }

        public IEnumerable<Movie> all_movies_published_after(int year)
        {
            return list_of_movies.Search(p => p.date_published.Year > year);
        }

        public IEnumerable<Movie> all_movies_published_between_years(int startingYear, int endingYear)
        {
            return list_of_movies.Search(p => p.date_published.Year >= startingYear
                                              && p.date_published.Year <= endingYear);
        }

        public IEnumerable<Movie> all_kid_movies()
        {
            return list_of_movies.Search(p => p.genre == Genre.kids);
        }

        public IEnumerable<Movie> all_action_movies()
        {
            return list_of_movies.Search(p => p.genre == Genre.action);
        }

        public IEnumerable<Movie> sort_all_movies_by_date_published_descending()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> sort_all_movies_by_date_published_ascending()
        {
            throw new NotImplementedException();
        }
    }
}