//      https://leetcode.com/problems/sudoku-solver/

using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

char[][] board = [
    ['.','.','9','7','4','8','.','.','.'],
    ['7','.','.','.','.','.','.','.','.'],
    ['.','2','.','1','.','9','.','.','.'],
    ['.','.','7','.','.','.','2','4','.'],
    ['.','6','4','.','1','.','5','9','.'],
    ['.','9','8','.','.','.','3','.','.'],
    ['.','.','.','8','.','3','.','2','.'],
    ['.','.','.','.','.','.','.','.','6'],
    ['.','.','.','2','7','5','9','.','.']];

SolveSudoku(board);
for (var i = 0; i < 9; i++)
{
    NineToString(board[i]);
}



void SolveSudoku(char[][] board)
{
    _ = IsSolvable(board, 0, 0);
}

bool IsSolvable(char[][] board, int row, int col)
{
    if (row >= 9 || col >= 9) return true;

    while (board[row][col] != '.')
    {
        col++;
        if (col >= 9)
        {
            row++;
            col = 0;
            if (row == 9) return true;
        }
    }

    for (char digit = '1'; digit <= '9'; digit++)
    {
        if (IsValidEntry(board, row, col, digit))
        {
            board[row][col] = digit;
            if (IsSolvable(board, row + (col + 1) / 9, (col + 1) % 9))
            {
                return true;
            }
        }
    }

    board[row][col] = '.';
    return false;
}

bool IsValidEntry(char[][] board, int row, int col, char digit) =>
       IsRowOk(board, row, col, digit)
    && IsColumnOk(board, row, col, digit)
    && IsSquareOk(board, row, col, digit);

bool IsRowOk(char[][] board, int row, int col, char digit)
{
    for (var i = 0; i < 9; i++)
    {
        if (board[row][i] == digit)
        {
            return false;
        }
    }

    return true;
}


bool IsColumnOk(char[][] board, int row, int col, char digit)
{
    for (var i = 0; i < 9; i++)
    {
        if (board[i][col] == digit)
        {
            return false;
        }
    }

    return true;
}

bool IsSquareOk(char[][] board, int row, int col, char digit)
{
    var m = row / 3;
    var n = col / 3;
    for (var i = 0; i < 3; i++)
    {
        for (var j = 0; j < 3; j++)
        {
            if (board[m * 3 + i][n * 3 + j] == digit)
            {
                return false;
            }
        }
    }
    return true;
}

void NineToString(char[] chars)
{
    var builder = new StringBuilder("[ ");
    foreach (var c in chars)
    {
        builder.Append(c + ", ");
    }

    System.Console.WriteLine(builder.ToString()[..^2] + " ]");
}