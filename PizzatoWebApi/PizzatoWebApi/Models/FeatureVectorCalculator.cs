using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzatoWebApi.Models
{
    public static class FeatureVectorCalculator
    {
        public static long CalculateFeatureVector(IEnumerable<string> usedTags, IList<string> allTags)
        {
            int[] bytes = new int[allTags.Count];

            for(int i=0; i<allTags.Count; i++)
            {
                bytes[i] = usedTags.Contains(allTags[i]) ? 1 : 0;
            }

            return ConvertVectorToLong(bytes);
        }

        private static long ConvertVectorToLong(int[] bytes)
        {
            long result = 0;

            for(int i=0; i<bytes.Length; i++)
            {
                result *= 2;
                result += bytes[i];
            }

            return result;
        }
    }
}
