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

using System.Diagnostics;
using FluentAssertions;

public class TwoSumTests
{
    [Fact]
    public void TwoSum_GivenEmptyList_ReturnsEmpty()
    {
        // Arrange
        var inputs = Array.Empty<int>();
        const int target = 0;

        // Act
        var result = TwoSum(inputs, target);

        // Assert
        _ = result.Should().BeEmpty();
    }

    [Fact]
    public void TwoSum_GivenInvalidTarget_ReturnsEmpty()
    {
        // Arrange
        var inputs = new[] { 1, 2 };
        const int target = 5;

        // Act
        var result = TwoSum(inputs, target);

        // Assert
        _ = result.Should().BeEmpty();
    }

    [Fact]
    public void TwoSum_GivenNegativeTarget_ReturnsCorrectResult()
    {
        // Arrange
        var inputs = new[] { 1, 2, -5, -5 };
        const int target = -10;

        // Act
        var result = TwoSum(inputs, target);

        // Assert
        _ = result.Should().NotBeEmpty();
    }

    [Fact]
    public void TwoSum_GivenValidArguments_ReturnsExpected()
    {
        // Arrange
        var inputs = new[] { 1, 2, 3 };
        const int target = 5;

        // Act
        var result = TwoSum(inputs, target);

        // Assert
        _ = result.Should().NotBeEmpty();
        _ = result[0].Should().Be(1);
        _ = result[1].Should().Be(2);
        _ = result.Length.Should().Be(2);
    }

    [Theory]
    [ClassData(typeof(TwoSumTestData))]
    public void TwoSum_Tests(int[] numbers, int target)
    {
        // Arrange
        Debug.Assert(numbers != null, nameof(numbers) + " != null");

        // Act
        var result = TwoSum(numbers, target);

        // Assert
        _ = result.Length.Should().Be(2);
    }

    private static int[] TwoSum(IReadOnlyList<int> numbers, int target)
    {
        var seenComplements = new Dictionary<int, int>();

        for (var i = 0; i < numbers.Count; i++)
        {
            var n = numbers[i];
            var complement = target - n;

            if (seenComplements.TryGetValue(complement, out var value))
            {
                return new[] { value, i };
            }

            _ = seenComplements.TryAdd(n, i);
        }

        return Array.Empty<int>();
    }
}

#pragma warning disable CA5394

public class TwoSumTestData : TheoryData<int[], int>
{
    public TwoSumTestData()
    {
        var testCaseCount = Random.Shared.Next(0, 100);

        for (var i = 0; i < testCaseCount; i++)
        {
            var factorOne = Random.Shared.Next(10_000, 100_000);
            var factorTwo = Random.Shared.Next(10_000, 100_000);
            var target = factorOne + factorTwo;

            var inputs = GetRandomLengthIntegerList().ToArray();

            var indexOne = Random.Shared.Next(0, inputs.Length);
            var indexTwo = Random.Shared.Next(0, inputs.Length);

            // Make sure we don't get identical indexes.
            while (indexOne == indexTwo)
            {
                indexTwo = Random.Shared.Next(0, inputs.Length);
            }

            inputs[indexOne] = factorOne;
            inputs[indexTwo] = factorTwo;

            this.Add(inputs, target);
        }
    }

    private static List<int> GetRandomLengthIntegerList()
    {
        var result = new List<int>();
        var length = Random.Shared.Next(0, 1000);

        for (var i = 0; i < length - 1; i++)
        {
            var number = Random.Shared.Next(0, 1000);
            result.Add(number);
        }

        return result;
    }
}

#pragma warning restore CA5394
