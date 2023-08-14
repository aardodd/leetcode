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

public class ProductExceptSelfTests
{
    [Fact]
    public void ProductExceptSelf_GivenEmptyList_ReturnsEmpty()
    {
        // Arrange
        // Act
        var result = ProductExceptSelf(Array.Empty<int>());

        // Assert
        _ = result.Should().BeEmpty();
    }

    [Fact]
    public void ProductExceptSelf_GivenSingleElementList_ReturnsSingleElement()
    {
        // Arrange
        var input = new[] { 1 };

        // Act
        var result = ProductExceptSelf(input);

        // Assert
        _ = result.Should().NotBeEmpty();
        _ = result[0].Should().Be(1);
    }

    [Fact]
    public void ProductExceptSelf_GivenMultipleElementList_ReturnsSingleElement()
    {
        // Arrange
        var input = new[] { 1, 2, 3, 4 };
        var expected = new[] { 24, 12, 8, 6 };

        // Act
        var result = ProductExceptSelf(input);

        // Assert
        _ = result.Should().NotBeEmpty();
        _ = result.Should().Equal(expected);
    }

    private static int[] ProductExceptSelf(int[] nums)
    {
        var prefix = 1;
        var postfix = 1;
        var result = new int[nums.Length];

        for (var i = 0; i < nums.Length; i++)
        {
            result[i] = prefix;
            prefix *= nums[i];
        }

        for (var i = nums.Length - 1; i >= 0; i--)
        {
            result[i] *= postfix;
            postfix *= nums[i];
        }

        return result;
    }
}
