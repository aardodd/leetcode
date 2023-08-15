// LeetCode - my solutions to LeetCode or competitive-programming problems
// Copyright (C) 2023  Aaron Dodd
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <https://www.gnu.org/licenses/>.

namespace LeetCode.Challenges.Solutions;

using System.Globalization;
using FluentAssertions;

public class ValidPalindromeTests
{
    [Fact]
    public void IsPalindrome_GivenEmptyString_ReturnsFalse()
    {
        // Arrange
        var input = string.Empty;

        // Act
        var result = IsPalindrome(input);

        // Assert
        _ = result.Should().BeFalse();
    }

    [Fact]
    public void IsPalindrome_GivenNonPalindrome_ReturnsFalse()
    {
        // Arrange
        const string input = "hello";

        // Act
        var result = IsPalindrome(input);

        // Assert
        _ = result.Should().BeFalse();
    }

    [Fact]
    public void IsPalindrome_GivenSimplePalindrome_ReturnsTrue()
    {
        // Arrange
        const string input = "racecar";

        // Act
        var result = IsPalindrome(input);

        // Assert
        _ = result.Should().BeTrue();
    }

    [Fact]
    public void IsPalindrome_GivenAdvancedPalindrome_ReturnsTrue()
    {
        // Arrange
        const string input = "A man, a plan, a canal: Panama";

        // Act
        var result = IsPalindrome(input);

        // Assert
        _ = result.Should().BeTrue();
    }

    private static bool IsPalindrome(string palindrome)
    {
        if (string.IsNullOrWhiteSpace(palindrome))
        {
            return false;
        }

        var leftIndex = 0;
        var rightIndex = palindrome.Length - 1;

        while (leftIndex <= rightIndex)
        {
            if (!char.IsLetterOrDigit(palindrome[leftIndex]))
            {
                leftIndex += 1;
            }
            else if (!char.IsLetterOrDigit(palindrome[rightIndex]))
            {
                rightIndex -= 1;
            }
            else
            {
                var leftLower = char.ToLower(palindrome[leftIndex], CultureInfo.InvariantCulture);
                var rightLower = char.ToLower(palindrome[rightIndex], CultureInfo.InvariantCulture);

                if (leftLower != rightLower)
                {
                    return false;
                }

                leftIndex += 1;
                rightIndex -= 1;
            }
        }

        return true;
    }
}
