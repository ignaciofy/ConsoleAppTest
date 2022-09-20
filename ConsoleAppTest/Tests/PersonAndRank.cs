using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleAppTest.Models;

namespace ConsoleAppTest.Tests
{
    public class PersonAndRank
    {
        public static IList<RankedResult> FilterByCountryWithRank(
            IList<Person> people,
            IList<CountryRanking> rankingData,
            IList<string> countryFilter,
            int minRank, int maxRank,
            int maxCount)
        {
            IList<RankedResult> result;

            //If no result required return empty
            if (maxCount == 0)
                return new RankedResult[] { };

            //Filter Counter
            var filterByCountry = rankingData.Where(x => countryFilter.Any(y => y.ToLower() == x.Country.ToLower()) &&
                                    (int)x.Rank >= minRank &&
                                    (int)x.Rank <= maxRank)
                                    .OrderBy(x => x.Rank)
                                    .ThenBy(x => x.PersonId)
                                    .ToList();

            List<Person> listPersonFiltered = new List<Person>();
            //Based on crountry create the list of People
            for (int i = 0; i < filterByCountry.Count; i++)
            {
                if (i > maxCount)
                    break;
                var item = filterByCountry[i];
                listPersonFiltered.Add(new Person(item.PersonId, people.First(p => p.Id == item.PersonId).Name));
            }
            result = listPersonFiltered.Count > 0 ? listPersonFiltered
                                                    .OrderBy(x => x.Name)
                                                    .Select(p => new RankedResult(p.Id, filterByCountry.First(r => r.PersonId == p.Id).Rank))
                                                    .ToList()
                                                    : new RankedResult[] { };

            return result;
        }
    }
}
