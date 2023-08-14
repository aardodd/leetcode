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

public class TopFrequentElementTests
{
    [Fact]
    public void TopFrequentElements_GivenAnArray_ReturnsResults()
    {
        // Arrange
        var inputs = new List<int> { 1, 1, 1, 2, 2, 3 };
        const int target = 2;

        // Act
        var result = TopFrequentElements(inputs, target);

        // Assert
        _ = result.Should().NotBeEmpty();
        _ = result.Count.Should().Be(target);
    }

    private static IList<int> TopFrequentElements(List<int> nums, int k)
    {
        var frequency = new Dictionary<int, int>();

        foreach (var n in nums)
        {
            if (frequency.ContainsKey(n))
            {
                frequency[n] += 1;
            }
            else
            {
                frequency.Add(n, 1);
            }
        }

        var queue = new PriorityQueue<int, int>();
        foreach (var key in frequency.Keys)
        {
            queue.Enqueue(key, frequency[key]);

            if (queue.Count > k)
            {
                _ = queue.Dequeue();
            }
        }

        var result = new int[k];
        var i = k;

        while (queue.Count > 0)
        {
            result[--i] = queue.Dequeue();
        }

        return result;
    }
}
