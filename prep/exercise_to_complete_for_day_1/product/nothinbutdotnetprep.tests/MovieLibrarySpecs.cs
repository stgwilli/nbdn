using System;
using System.Collections.Generic;
using System.Linq;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdddoc.core;
using nothinbutdotnetprep.collections;
using nothinbutdotnetprep.infrastructure.extensions;

/* The following set of Contexts (TestFixture) are in place to specify the functionality that you need to complete for the MovieLibrary class.
 * MovieLibrary is an aggregate root for the Movie class. It exposes the ability to search,sort, and iterate over all of the movies that it aggregates.
 * The current implementation of MovieLibrary has all of its methods throwing a NotImplementedException. Your job is to get all of the Contexts and their
 it should already have so = () =>
 * familiarity with:
 * 
 *      -IEnumerable<T> - The Grandfather of all collection interfaces
 *      -IList<T>
 *      -IEquatable<T>
 *      -IComparer<T>
 *      -Comparison<T> delegate type
 *      -Predicate<T> delegate type
 *      -Generics     
 * 
 * The primary goals of this exercise are to get you familiar with a couple of things:
 *      Automated Builds with powershell
 *      Unit Testing Framework (MbUnit)
 *      BDD Style Test Naming Syntax
 *      Fluent Assertions - You will find most of these are extension methods that live in the BDDExtensions class
 *      Refactoring
 *      Core collection and framework interfaces and types
 *      Encapsulation
 *      Open Closed Principle
 *      Coding to Specs (Tests)
 *      
 *
 * As I said earlier, the tests are complete. You will just need to get the implementation working. As you progress through the exercise you will undoubtebly see areas
 * where refactoring can take place (particularly around the area of methods that don't need to be there on MovieLibrary. This is as much a design exercise as it is
 * an implementation exercise. Do your best to refactor what you end up with to the best of your abilities.
 * 
 * One other stipulation of this exercise is that Linq is not to be used!! We will explore linq options together as we go through completed solutions
 * on the first day of class. I want you to use this opportunity to see how Linq like you can get your solution in spite of not being able to use linq
 * , this just gives you another reason to flex you .net muscles!!
 * 
 * If you have any questions please do not hesitate to email me at jp@jpboodhoo.com
 * Or give me a call at (503)213-3507
 * 
 * Develop With Passion!!
 */

namespace nothinbutdotnetprep.tests
{
    public class MovieLibrarySpecs
    {
        public abstract class concern : observations_for_a_sut_without_a_contract<MovieLibrary>
        {
            static protected IList<Movie> movie_collection;

            context c = () =>
            {
                movie_collection = new List<Movie>();
                provide_a_basic_sut_constructor_argument(movie_collection);
            };
        } ;

        [Concern(typeof (MovieLibrary))]
        public class when_counting_the_number_of_movies : concern
        {
            static int number_of_movies;

            context c = () =>
            {
                movie_collection.add_all(new Movie(), new Movie());
            };

            because b = () =>
            {
                number_of_movies = sut.all_movies().Count();
            };

            it should_return_the_number_of_all_movies_in_the_library = () =>
            {
                number_of_movies.should_be_equal_to(2);
            };
        }

        [Concern(typeof (MovieLibrary))]
        public class when_asked_for_all_of_the_movies : concern
        {
            static Movie first_movie;
            static Movie second_movie;
            static IEnumerable<Movie> all_movies;

            context c = () =>
            {
                first_movie = new Movie();
                second_movie = new Movie();

                movie_collection.add_all(first_movie, second_movie);
            };

            because b = () =>
            {
                all_movies = sut.all_movies();
            };

            it should_receive_a_set_containing_each_movie_in_the_library = () =>
            {
                all_movies.should_only_contain(first_movie, second_movie);
            };
        }

        [Concern(typeof (MovieLibrary))]
        public class when_trying_to_change_the_set_of_movies_returned_by_the_movie_library_to_a_mutable_type : concern
        {
            static Movie first_movie;
            static Movie second_movie;

            context c = () =>
            {
                first_movie = new Movie();
                second_movie = new Movie();
                movie_collection.add_all(first_movie, second_movie);
            };

            because b = () =>
            {
                doing(() => sut.all_movies().downcast_to<IList<Movie>>());
            };

            it should_get_an_invalid_cast_exception = () =>
            {
                exception_thrown_by_the_sut.should_be_an_instance_of<InvalidCastException>();
            };
        }


        [Concern(typeof (MovieLibrary))]
        public class when_adding_a_movie_to_the_library : concern
        {
            static Movie movie;

            context c = () =>
            {
                movie = new Movie();
            };

            because b = () =>
            {
                sut.add(movie);
            };

            it should_store_it_in_the_movie_collection = () =>
            {
                movie_collection.Contains(movie).should_be_true();
                movie_collection.Count.should_be_equal_to(1);
            };
        }

        [Concern(typeof (MovieLibrary))]
        public class when_adding_an_existing_movie_in_the_collection_again : concern
        {
            static Movie movie;

            context c = () =>
            {
                movie = new Movie();
                movie_collection.Add(movie);
            };

            because b = () =>
            {
                sut.add(movie);
            };

            it should_not_restore_the_movie_in_the_collection = () =>
            {
                movie_collection.Count.should_be_equal_to(1);
            };
        }

        [Concern(typeof (MovieLibrary))]
        public class when_adding_two_different_copies_of_the_same_movie : concern
        {
            static Movie another_copy_of_speed_racer;
            static Movie speed_racer;

            context c = () =>
            {
                speed_racer = new Movie {title = "Speed Racer"};
                another_copy_of_speed_racer = new Movie {title = "Speed Racer"};
                movie_collection.Add(speed_racer);
            };

            because b = () =>
            {
                sut.add(another_copy_of_speed_racer);
            };

            it should_store_only_1_copy_in_the_collection = () =>
            {
                movie_collection.Count.should_be_equal_to(1);
            };
        }

        [Concern(typeof (MovieLibrary))]
        public class when_searching_for_movies : searching_and_sorting_concerns_for_movie_library
        {
            /* Look at the potential method explosion that can start to occur as you start to search on different criteria
             * see if you can apply OCP (Open closed principle) to ensure that you can accomodate all means of searching for
             * movies using different criteria. Feel free to change/remove explicit methods if you find a way to encompass searching
             * without the need for using explicit methods. For this exercise, no linq queries are allowed!!.*/

            it should_be_able_to_find_all_movies_published_by_pixar = () =>
            {
                var results = sut.all_movies_published_by_pixar();

                results.should_only_contain(cars, a_bugs_life);
            };

            it should_be_able_to_find_all_movies_published_by_pixar_or_disney = () =>
            {
                var results = sut.all_movies_published_by_pixar_or_disney();

                results.should_only_contain(a_bugs_life, pirates_of_the_carribean, cars);
            };

            it should_be_able_to_find_all_movies_not_published_by_pixar = () =>
            {
                var results = sut.all_movies_not_published_by_pixar();

                results.should_not_contain(cars, a_bugs_life);
            };

            it should_be_able_to_find_all_movies_published_after_a_certain_year = () =>
            {
                var results = sut.all_movies_published_after(2004);

                results.should_only_contain(the_ring, shrek, theres_something_about_mary);
            };

            it should_be_able_to_find_all_movies_published_between_a_certain_range_of_years = () =>
            {
                var results = sut.all_movies_published_between_years(1982, 2003);

                results.should_only_contain(indiana_jones_and_the_temple_of_doom, a_bugs_life, pirates_of_the_carribean);
            };

            it should_be_able_to_find_all_kid_movies = () =>
            {
                var results = sut.all_kid_movies();

                results.should_only_contain(a_bugs_life, shrek, cars);
            };

            it should_be_able_to_find_all_action_movies = () =>
            {
                var results = sut.all_action_movies();

                results.should_only_contain(indiana_jones_and_the_temple_of_doom, pirates_of_the_carribean);
            };
        }

        [Concern(typeof (MovieLibrary))]
        public class when_sorting_movies : searching_and_sorting_concerns_for_movie_library
        {
            /* Look at the potential method explosion that can start to occur as you start to sort on different criteria
             * see if you can apply OCP (Open closed principle) to ensure that you can accomodate all means of sorting for
             * movies using different criteria. Feel free to change/remove explicit methods if you find a way to encompass sorting
             * without the need for using explicit methods. For this exercise, no linq queries are allowed!!. */

            it should_be_able_to_sort_all_movies_by_title_descending = () =>
            {
                var results = sut.sort_all_movies_by_title_descending();

                results.should_only_contain_in_order(theres_something_about_mary, the_ring, shrek, pirates_of_the_carribean, indiana_jones_and_the_temple_of_doom,
                                                     cars, a_bugs_life);
            };

            it should_be_able_to_sort_all_movies_by_title_ascending = () =>
            {
                var results = sut.sort_all_movies_by_title_ascending();

                results.should_only_contain_in_order(a_bugs_life, cars, indiana_jones_and_the_temple_of_doom, pirates_of_the_carribean, shrek, the_ring, theres_something_about_mary);
            };

            it should_be_able_to_sort_all_movies_by_date_published_descending = () =>
            {
                var results = sut.sort_all_movies_by_date_published_descending();

                results.should_only_contain_in_order(theres_something_about_mary, shrek, the_ring, cars, pirates_of_the_carribean, a_bugs_life, indiana_jones_and_the_temple_of_doom);
            };

            it should_be_able_to_sort_all_movies_by_date_published_ascending = () =>
            {
                var results = sut.sort_all_movies_by_date_published_ascending();

                results.should_only_contain_in_order(indiana_jones_and_the_temple_of_doom, a_bugs_life, pirates_of_the_carribean, cars, the_ring, shrek, theres_something_about_mary);
            };

            it should_be_able_to_sort_all_movies_by_studio_rating_and_year_published = () =>
            {
                //Studio Ratings (highest to lowest)
                //MGM
                //Pixar
                //Dreamworks
                //Universal
                //Disney
                var results = sut.sort_all_movies_by_movie_studio_and_year_published();
                /* should return a set of results 
                 * in the collection sorted by the rating of the production studio (not the movie rating) and year published. for this exercise you need to take the studio ratings
                 * into effect, which means that you first have to sort by movie studio (taking the ranking into account) and then by the
                 * year published. For this test you cannot add any extra properties/fields to either the ProductionStudio or
                 * Movie classes.*/

                results.should_only_contain_in_order(the_ring, theres_something_about_mary, a_bugs_life, cars, shrek, indiana_jones_and_the_temple_of_doom,
                                                     pirates_of_the_carribean);
            };
        }

        public abstract class searching_and_sorting_concerns_for_movie_library : concern
        {
            static protected Movie a_bugs_life;
            static protected Movie cars;
            static protected Movie indiana_jones_and_the_temple_of_doom;
            static protected Movie pirates_of_the_carribean;
            static protected Movie shrek;
            static protected Movie the_ring;
            static protected Movie theres_something_about_mary;


            context c = () =>
            {
                populate_with_default_movie_set(movie_collection);
            };


            static void populate_with_default_movie_set(IList<Movie> movieList)
            {
                indiana_jones_and_the_temple_of_doom = new Movie
                                                       {
                                                           title = "Indiana Jones And The Temple Of Doom",
                                                           date_published = new DateTime(1982, 1, 1),
                                                           genre = Genre.action,
                                                           production_studio = ProductionStudio.Universal,
                                                           rating = 10
                                                       };
                cars = new Movie
                       {
                           title = "Cars",
                           date_published = new DateTime(2004, 1, 1),
                           genre = Genre.kids,
                           production_studio = ProductionStudio.Pixar,
                           rating = 10
                       };

                the_ring = new Movie
                           {
                               title = "The Ring",
                               date_published = new DateTime(2005, 1, 1),
                               genre = Genre.horror,
                               production_studio = ProductionStudio.MGM,
                               rating = 7
                           };
                shrek = new Movie
                        {
                            title = "Shrek",
                            date_published = new DateTime(2006, 5, 10),
                            genre = Genre.kids,
                            production_studio = ProductionStudio.Dreamworks,
                            rating = 10
                        };
                a_bugs_life = new Movie
                              {
                                  title = "A Bugs Life",
                                  date_published = new DateTime(2000, 6, 20),
                                  genre = Genre.kids,
                                  production_studio = ProductionStudio.Pixar,
                                  rating = 10
                              };
                theres_something_about_mary = new Movie
                                              {
                                                  title = "There's Something About Mary",
                                                  date_published = new DateTime(2007, 1, 1),
                                                  genre = Genre.comedy,
                                                  production_studio = ProductionStudio.MGM,
                                                  rating = 5
                                              };
                pirates_of_the_carribean = new Movie
                                           {
                                               title = "Pirates of the Carribean",
                                               date_published = new DateTime(2003, 1, 1),
                                               genre = Genre.action,
                                               production_studio = ProductionStudio.Disney,
                                               rating = 10
                                           };

                movieList.Add(cars);
                movieList.Add(indiana_jones_and_the_temple_of_doom);
                movieList.Add(pirates_of_the_carribean);
                movieList.Add(a_bugs_life);
                movieList.Add(shrek);
                movieList.Add(the_ring);
                movieList.Add(theres_something_about_mary);
            }
        }
    }
}