﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecursiveStringPermutations
{
    public class RecursivePermutationStringPermutation2
    {
        private string _stringToProcess;

        public RecursivePermutationStringPermutation2(string stringToProcess)
        {
            _stringToProcess = stringToProcess;
        }

        public ISet<string> Process()
        {
            return GetPermutations(_stringToProcess);
        }

        public ISet<string> GetPermutations(string inputString)
        {
            // Base case
            if (inputString.Length <= 1)
            {
                return new HashSet<string>(inputString.Select(c => new string(c, 1)));
            }

            var allCharsExceptLast = inputString.Substring(0, inputString.Length - 1);
            char lastChar = inputString[inputString.Length - 1];

            // Recursive call: get all possible permutations for all chars except last
            var permutationsOfAllCharsExceptLast = GetPermutations(allCharsExceptLast);

            // Put the last char in all possible positions for each of the above permutations
            var permutations = new HashSet<string>();
            foreach (var permutationOfAllCharsExceptLast in permutationsOfAllCharsExceptLast)
            {
                for (int position = 0; position <= allCharsExceptLast.Length; position++)
                {
                    var permutation = permutationOfAllCharsExceptLast.Substring(0, position)
                        + lastChar
                        + permutationOfAllCharsExceptLast.Substring(position);
                    permutations.Add(permutation);
                }
            }

            return permutations;
        }
    }
}
