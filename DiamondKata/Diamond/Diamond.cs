﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Diamond
{

    public class Diamond
    {
        public string Generate(char letter)
        {
            ValidateLetter(letter);

            List<string> result = new List<string>();
            for (char currentLetter = 'A'; currentLetter <= letter; currentLetter++)
            {
                if (currentLetter == 'A')
                    result.Add($"{currentLetter}");
                else
                    result.Add($"{currentLetter} {currentLetter}");
            }

            IEnumerable<string> reverse = result.Where(c => !c.Contains(letter) ).Reverse();
            result.AddRange(reverse);

            return string.Join('\n', result);
        }

        private void ValidateLetter(char letter)
        {
            if (letter == '\0')
            {
                throw new ArgumentException(nameof(letter));
            }
        }
    }

}
