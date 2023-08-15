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

using FluentAssertions;

public class ValidAnagramTests
{
    [Fact]
    public void IsAnagram_GivenEmptyStrings_ReturnsFalse()
    {
        // Arrange
        var left = string.Empty;
        var right = string.Empty;

        // Act
        var result = IsAnagram(left, right);

        // Assert
        _ = result.Should().BeFalse();
    }

    [Fact]
    public void IsAnagram_GivenStringsWithDifferentLengths_ReturnsFalse()
    {
        // Arrange
        const string left = "123";
        const string right = "12345";

        // Act
        var result = IsAnagram(left, right);

        // Assert
        _ = result.Should().BeFalse();
    }

    [Fact]
    public void IsAnagram_GivenIdenticalStrings_ReturnsTrue()
    {
        // Arrange
        const string left = "12345";
        const string right = "12345";

        // Act
        var result = IsAnagram(left, right);

        // Assert
        _ = result.Should().BeTrue();
    }

    [Fact]
    public void IsAnagram_GivenAnagramStrings_ReturnsTrue()
    {
        // Arrange
        const string left = "tar";
        const string right = "rat";

        // Act
        var result = IsAnagram(left, right);

        // Assert
        _ = result.Should().BeTrue();
    }

    [Fact]
    public void IsAnagram_GivenBasicUnicodeAnagramStrings_ReturnsTrue()
    {
        // Arrange
        const string left = "tar❤❤";
        const string right = "❤❤rat";

        // Act
        var result = IsAnagram(left, right);

        // Assert
        _ = result.Should().BeTrue();
    }

    private static bool IsAnagram(string left, string right)
    {
        if (string.IsNullOrWhiteSpace(left) || string.IsNullOrWhiteSpace(right))
        {
            return false;
        }

        if (left.Length != right.Length)
        {
            return false;
        }

        var leftChars = CountCharacters(left);
        var rightChars = CountCharacters(right);

        foreach (var (key, count) in leftChars)
        {
            if (!rightChars.TryGetValue(key, out var value) || value != count)
            {
                return false;
            }
        }

        return true;
    }

    private static Dictionary<char, int> CountCharacters(string str)
    {
        var result = new Dictionary<char, int>();
        foreach (var c in str)
        {
            if (result.TryGetValue(c, out var value))
            {
                result[c] = value + 1;
            }
            else
            {
                result.Add(c, 0);
            }
        }

        return result;
    }
}
