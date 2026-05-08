using System;

public class Solution
{
    public int solution(string[] board)
    {
        int countO = 0;
        int countX = 0;

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (board[i][j] == 'O') countO++;
                else if (board[i][j] == 'X') countX++;
            }
        }

        // O는 선공이므로 개수 차이 검사
        if (countX > countO) return 0;
        if (countO > countX + 1) return 0;

        bool oWin = IsWin(board, 'O');
        bool xWin = IsWin(board, 'X');

        // 둘 다 이긴 상태는 불가능
        if (oWin && xWin) return 0;

        // O가 이겼다면 O가 X보다 정확히 1개 많아야 함
        if (oWin && countO != countX + 1) return 0;

        // X가 이겼다면 O와 X 개수가 같아야 함
        if (xWin && countO != countX) return 0;

        return 1;
    }

    private bool IsWin(string[] board, char target)
    {
        // 가로
        for (int i = 0; i < 3; i++)
        {
            if (board[i][0] == target &&
                board[i][1] == target &&
                board[i][2] == target)
                return true;
        }

        // 세로
        for (int j = 0; j < 3; j++)
        {
            if (board[0][j] == target &&
                board[1][j] == target &&
                board[2][j] == target)
                return true;
        }

        // 대각선
        if (board[0][0] == target &&
            board[1][1] == target &&
            board[2][2] == target)
            return true;

        if (board[0][2] == target &&
            board[1][1] == target &&
            board[2][0] == target)
            return true;

        return false;
    }
}