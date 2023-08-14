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

public class GroupAnagramTests
{
    [Fact]
    public void GroupAnagrams_GivenEmptyList_ReturnsEmptyResult()
    {
        // Arrange
        // Act
        var result = GroupAnagrams(new List<string>());

        // Assert
        _ = result.Should().BeEmpty();
    }

    [Fact]
    public void GroupAnagrams_GivenSingleElementList_ReturnsSingleResult()
    {
        // Arrange
        var inputs = new List<string> { "single" };

        // Act
        var result = GroupAnagrams(inputs);

        // Assert
        _ = result.Should().NotBeEmpty();
    }

    [Fact]
    public void GroupAnagrams_GivenMultipleElementList_ReturnsGroupedResult()
    {
        // Arrange
        var inputs = new List<string> { "bat", "tab", "tar" };

        // Act
        var result = GroupAnagrams(inputs);

        // Assert
        _ = result.Should().NotBeEmpty();
        _ = result[0].Count.Should().Be(2);
        _ = result[0][0].Should().Be("bat");
        _ = result[0][1].Should().Be("tab");
        _ = result[1].Count.Should().Be(1);
        _ = result[1][0].Should().Be("tar");
    }

    private static List<List<string>> GroupAnagrams(List<string> anagrams)
    {
        var groups = new Dictionary<string, List<string>>();

        foreach (var str in anagrams)
        {
            var hash = new char[26];

            foreach (var c in str)
            {
                hash[c - 'a']++;
            }

            var key = new string(hash);
            if (!groups.ContainsKey(key))
            {
                groups.Add(key, new List<string>());
            }

            groups[key].Add(str);
        }

        return groups.Values.ToList();
    }
}
