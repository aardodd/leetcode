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

public class ContainsDuplicateTests
{
    [Theory]
    [ClassData(typeof(ContainsDuplicateTestData))]
    public void ContainsDuplicate_Tests(IList<int> inputs, bool containsDuplicate)
    {
        var result = ContainsDuplicate(inputs);
        _ = result.Should().Be(containsDuplicate);
    }

    private static bool ContainsDuplicate(IEnumerable<int> numbers)
    {
        var seenNumbers = new HashSet<int>();

        Debug.Assert(numbers != null, nameof(numbers) + " != null");

        foreach (var n in numbers)
        {
            if (seenNumbers.Contains(n))
            {
                return true;
            }

            _ = seenNumbers.Add(n);
        }

        return false;
    }
}

#pragma warning disable CA5394

public class ContainsDuplicateTestData : TheoryData<List<int>, bool>
{
    public ContainsDuplicateTestData()
    {
        var testCaseCount = Random.Shared.Next(0, 100);

        for (var i = 0; i < testCaseCount; i++)
        {
            var containsDuplicates = Random.Shared.Next(0, 2) == 1;
            var inputs = GetRandomLengthIntegerList(containsDuplicates);
            this.Add(inputs, containsDuplicates);
        }
    }

    private static List<int> GetRandomLengthIntegerList(bool containsDuplicates)
    {
        var result = new List<int>();
        var length = Random.Shared.Next(0, 1000);
        var seenNumbers = new HashSet<int>();

        if (!containsDuplicates)
        {
            for (var i = 0; i < length; i++)
            {
                var number = Random.Shared.Next(0, 1000);
                if (seenNumbers.Contains(number))
                {
                    continue;
                }

                result.Add(number);
                _ = seenNumbers.Add(number);
            }

            return result;
        }

        for (var i = 0; i < length - 1; i++)
        {
            var number = Random.Shared.Next(0, 1000);
            result.Add(number);
            _ = seenNumbers.Add(number);
        }

        result.Add(result[0]);

        return result;
    }
}

#pragma warning restore CA5394
