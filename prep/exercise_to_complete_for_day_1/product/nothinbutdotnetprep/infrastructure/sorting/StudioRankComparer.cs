using System.Collections.Generic;
using nothinbutdotnetprep.collections;

namespace nothinbutdotnetprep.infrastructure.sorting
{

    public class StudioRankComparer : IComparer<Movie>
    {
        private static Dictionary<ProductionStudio, int> StudioRankings = new Dictionary<ProductionStudio, int>
         {
             { ProductionStudio.MGM,        5},
             { ProductionStudio.Pixar,      4},
             { ProductionStudio.Dreamworks, 3},
             { ProductionStudio.Universal,  2},
             { ProductionStudio.Disney,     1}
         };

        public int Compare(Movie x, Movie y)
        {
            return StudioRankings[x.production_studio].CompareTo(StudioRankings[y.production_studio]);
        }
    }
}