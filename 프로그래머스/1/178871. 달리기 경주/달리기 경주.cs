using System;
using System.Collections.Generic;

public class Solution 
{
    public string[] solution(string[] players, string[] callings) 
    {
        Dictionary<string, int> rank = new Dictionary<string, int>();

        for (int i = 0; i < players.Length; i++)
        {
            rank[players[i]] = i;
        }

        foreach (string call in callings)
        {
            int curIndex = rank[call];
            int prevIndex = curIndex - 1;

            string prevPlayer = players[prevIndex];

            // 배열에서 위치 교환
            players[prevIndex] = call;
            players[curIndex] = prevPlayer;

            // Dictionary 인덱스 갱신
            rank[call] = prevIndex;
            rank[prevPlayer] = curIndex;
        }

        return players;
    }
}