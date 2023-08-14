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

public class ValidSudokuTests
{
    [Fact]
    public void IsValidSudoku_GivenAnEmptyBoard_ReturnsTrue()
    {
        // Arrange
        var board = new[]
        {
            new[] { '.', '.', '.', '.', '.', '.', '.', '.', '.', },
            new[] { '.', '.', '.', '.', '.', '.', '.', '.', '.', },
            new[] { '.', '.', '.', '.', '.', '.', '.', '.', '.', },
            new[] { '.', '.', '.', '.', '.', '.', '.', '.', '.', },
            new[] { '.', '.', '.', '.', '.', '.', '.', '.', '.', },
            new[] { '.', '.', '.', '.', '.', '.', '.', '.', '.', },
            new[] { '.', '.', '.', '.', '.', '.', '.', '.', '.', },
            new[] { '.', '.', '.', '.', '.', '.', '.', '.', '.', },
            new[] { '.', '.', '.', '.', '.', '.', '.', '.', '.', },
        };

        // Act
        var result = IsValidSudoku(board);

        // Assert
        _ = result.Should().BeTrue();
    }

    [Fact]
    public void IsValidSudoku_GivenAValidRow_ReturnsTrue()
    {
        // Arrange
        var board = new[]
        {
            new[] { '1', '2', '3', '4', '5', '6', '7', '8', '9', },
            new[] { '.', '.', '.', '.', '.', '.', '.', '.', '.', },
            new[] { '.', '.', '.', '.', '.', '.', '.', '.', '.', },
            new[] { '.', '.', '.', '.', '.', '.', '.', '.', '.', },
            new[] { '.', '.', '.', '.', '.', '.', '.', '.', '.', },
            new[] { '.', '.', '.', '.', '.', '.', '.', '.', '.', },
            new[] { '.', '.', '.', '.', '.', '.', '.', '.', '.', },
            new[] { '.', '.', '.', '.', '.', '.', '.', '.', '.', },
            new[] { '.', '.', '.', '.', '.', '.', '.', '.', '.', },
        };

        // Act
        var result = IsValidSudoku(board);

        // Assert
        _ = result.Should().BeTrue();
    }

    [Fact]
    public void IsValidSudoku_GivenAValidColumn_ReturnsTrue()
    {
        // Arrange
        var board = new[]
        {
            new[] { '1', '.', '.', '.', '.', '.', '.', '.', '.', },
            new[] { '2', '.', '.', '.', '.', '.', '.', '.', '.', },
            new[] { '3', '.', '.', '.', '.', '.', '.', '.', '.', },
            new[] { '4', '.', '.', '.', '.', '.', '.', '.', '.', },
            new[] { '5', '.', '.', '.', '.', '.', '.', '.', '.', },
            new[] { '6', '.', '.', '.', '.', '.', '.', '.', '.', },
            new[] { '7', '.', '.', '.', '.', '.', '.', '.', '.', },
            new[] { '8', '.', '.', '.', '.', '.', '.', '.', '.', },
            new[] { '9', '.', '.', '.', '.', '.', '.', '.', '.', },
        };

        // Act
        var result = IsValidSudoku(board);

        // Assert
        _ = result.Should().BeTrue();
    }

    [Fact]
    public void IsValidSudoku_GivenAValidSquare_ReturnsTrue()
    {
        // Arrange
        var board = new[]
        {
            new[] { '1', '2', '3', '.', '.', '.', '.', '.', '.', },
            new[] { '4', '5', '6', '.', '.', '.', '.', '.', '.', },
            new[] { '7', '8', '9', '.', '.', '.', '.', '.', '.', },
            new[] { '.', '.', '.', '.', '.', '.', '.', '.', '.', },
            new[] { '.', '.', '.', '.', '.', '.', '.', '.', '.', },
            new[] { '.', '.', '.', '.', '.', '.', '.', '.', '.', },
            new[] { '.', '.', '.', '.', '.', '.', '.', '.', '.', },
            new[] { '.', '.', '.', '.', '.', '.', '.', '.', '.', },
            new[] { '.', '.', '.', '.', '.', '.', '.', '.', '.', },
        };

        // Act
        var result = IsValidSudoku(board);

        // Assert
        _ = result.Should().BeTrue();
    }

    [Fact]
    public void IsValidSudoku_GivenAnInvalidRow_ReturnsFalse()
    {
        // Arrange
        var board = new[]
        {
            new[] { '1', '.', '.', '.', '.', '.', '.', '.', '1', },
            new[] { '.', '.', '.', '.', '.', '.', '.', '.', '.', },
            new[] { '.', '.', '.', '.', '.', '.', '.', '.', '.', },
            new[] { '.', '.', '.', '.', '.', '.', '.', '.', '.', },
            new[] { '.', '.', '.', '.', '.', '.', '.', '.', '.', },
            new[] { '.', '.', '.', '.', '.', '.', '.', '.', '.', },
            new[] { '.', '.', '.', '.', '.', '.', '.', '.', '.', },
            new[] { '.', '.', '.', '.', '.', '.', '.', '.', '.', },
            new[] { '.', '.', '.', '.', '.', '.', '.', '.', '.', },
        };

        // Act
        var result = IsValidSudoku(board);

        // Assert
        _ = result.Should().BeFalse();
    }

    [Fact]
    public void IsValidSudoku_GivenAnInvalidColumn_ReturnsFalse()
    {
        // Arrange
        var board = new[]
        {
            new[] { '1', '.', '.', '.', '.', '.', '.', '.', '.', },
            new[] { '.', '.', '.', '.', '.', '.', '.', '.', '.', },
            new[] { '.', '.', '.', '.', '.', '.', '.', '.', '.', },
            new[] { '.', '.', '.', '.', '.', '.', '.', '.', '.', },
            new[] { '.', '.', '.', '.', '.', '.', '.', '.', '.', },
            new[] { '.', '.', '.', '.', '.', '.', '.', '.', '.', },
            new[] { '.', '.', '.', '.', '.', '.', '.', '.', '.', },
            new[] { '.', '.', '.', '.', '.', '.', '.', '.', '.', },
            new[] { '1', '.', '.', '.', '.', '.', '.', '.', '.', },
        };

        // Act
        var result = IsValidSudoku(board);

        // Assert
        _ = result.Should().BeFalse();
    }

    [Fact]
    public void IsValidSudoku_GivenAnInvalidSquare_ReturnsFalse()
    {
        // Arrange
        var board = new[]
        {
            new[] { '1', '.', '.', '.', '.', '.', '.', '.', '.', },
            new[] { '.', '.', '.', '.', '.', '.', '.', '.', '.', },
            new[] { '.', '.', '1', '.', '.', '.', '.', '.', '.', },
            new[] { '.', '.', '.', '.', '.', '.', '.', '.', '.', },
            new[] { '.', '.', '.', '.', '.', '.', '.', '.', '.', },
            new[] { '.', '.', '.', '.', '.', '.', '.', '.', '.', },
            new[] { '.', '.', '.', '.', '.', '.', '.', '.', '.', },
            new[] { '.', '.', '.', '.', '.', '.', '.', '.', '.', },
            new[] { '.', '.', '.', '.', '.', '.', '.', '.', '.', },
        };

        // Act
        var result = IsValidSudoku(board);

        // Assert
        _ = result.Should().BeFalse();
    }

    private static bool IsValidSudoku(char[][] board)
    {
        var rows = new Dictionary<int, HashSet<char>>();
        var columns = new Dictionary<int, HashSet<char>>();
        var squares = new Dictionary<(int, int), HashSet<char>>();

        for (var rowIndex = 0; rowIndex < 9; rowIndex++)
        {
            _ = rows.TryAdd(rowIndex, new HashSet<char>());

            for (var columnIndex = 0; columnIndex < 9; columnIndex++)
            {
                _ = columns.TryAdd(columnIndex, new HashSet<char>());
                _ = squares.TryAdd((rowIndex / 3, columnIndex / 3), new HashSet<char>());

                var cell = board[rowIndex][columnIndex];

                if (cell == '.')
                {
                    continue;
                }

                var currentRow = rows[rowIndex];
                var currentColumn = columns[columnIndex];
                var currentSquare = squares[(rowIndex / 3, columnIndex / 3)];

                if (currentRow.Contains(cell) ||
                    currentColumn.Contains(cell) ||
                    currentSquare.Contains(cell))
                {
                    return false;
                }

                _ = currentRow.Add(cell);
                _ = currentColumn.Add(cell);
                _ = currentSquare.Add(cell);
            }
        }

        return true;
    }
}
