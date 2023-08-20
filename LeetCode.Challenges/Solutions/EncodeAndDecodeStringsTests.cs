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

public class EncodeAndDecodeStringsTests
{
    [Fact]
    public void EncodeString_GivenEmptyList_ReturnsEmptyString()
    {
        // Arrange
        // Act
        var result = Encode(Array.Empty<string>());

        // Assert
        _ = result.Should().BeEmpty();
    }

    [Fact]
    public void EncodeString_GivenSingleElementList_ReturnsEncodedString()
    {
        // Arrange
        var input = new[] { "hello" };

        // Act
        var result = Encode(input);

        // Assert
        _ = result.Should().NotBeEmpty();
        _ = result.Should().Be("5#hello");
    }

    [Fact]
    public void EncodeString_GivenMultiElementList_ReturnsEncodedString()
    {
        // Arrange
        var input = new[] { "hello", "world" };

        // Act
        var result = Encode(input);

        // Assert
        _ = result.Should().NotBeEmpty();
        _ = result.Should().Be("5#hello5#world");
    }

    [Fact]
    public void Decode_GivenEmptyString_ReturnsEmptyList()
    {
        // Arrange
        // Act
        var result = Decode(string.Empty);

        // Assert
        _ = result.Length.Should().Be(0);
    }

    [Fact]
    public void Decode_GivenSingleValidString_ReturnsList()
    {
        // Arrange
        // Act
        var result = Decode("5#hello");

        // Assert
        _ = result.Should().NotBeEmpty();
        _ = result[0].Should().Be("hello");
    }

    [Fact]
    public void Decode_GivenMultipleEncodedStrings_ReturnsList()
    {
        // Arrange
        // Act
        var result = Decode("5#hello6#cheese");

        // Assert
        _ = result.Should().NotBeEmpty();
        _ = result[0].Should().Be("hello");
        _ = result[1].Should().Be("cheese");
    }

    private static string Encode(IEnumerable<string> inputs) => inputs.Aggregate(string.Empty, (current, s) => current + s.Length + "#" + s);

    private static string[] Decode(string input)
    {
        var result = new List<string>();

        var i = 0;
        while (i < input.Length)
        {
            var j = i;

            while (input[j] != '#')
            {
                j += 1;
            }

            _ = int.TryParse(input[i..j], out var length);

            var startIndex = j + 1;
            var endIndex = j + length + 1;

            result.Add(input[startIndex..endIndex]);

            i = endIndex;
        }

        return result.ToArray();
    }
}
