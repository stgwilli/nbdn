using System;

namespace nothinbutdotnetprep.collections
{
    public class Movie : IEquatable<Movie>
    {
        public string title { get; set; }
        public ProductionStudio production_studio { get; set; }
        public Genre genre { get; set; }
        public int rating { get; set; }
        public DateTime date_published { get; set; }

        public bool Equals(Movie other)
        {
            if (other == null) return false;

            return ReferenceEquals(this, other) ? true : fields_are_the_same_as(other);
        }

        bool fields_are_the_same_as(Movie other)
        {
            return title == other.title;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Movie);
        }

        public override int GetHashCode()
        {
            return title.GetHashCode();
        }

        static public Predicate<Movie> is_published_after(DateTime date)
        {
            return new IsPublishedAfter(date).is_satisfied_by;
        }

        static public Predicate<Movie> is_published_by(ProductionStudio studio)
        {
            return new IsPublishedBy(studio).is_satisfied_by;
        }
    }
}