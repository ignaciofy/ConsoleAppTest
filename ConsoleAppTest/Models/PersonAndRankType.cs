using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTest.Models
{
    public record Person(long Id, string Name);
    public record CountryRanking(long PersonId, string Country, int Rank);
    public record RankedResult(long PersonId, int Rank);
}
