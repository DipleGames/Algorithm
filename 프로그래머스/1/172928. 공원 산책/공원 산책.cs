using System;

public class Solution 
{
    int[] pos = new int[2]; 
    public int[] solution(string[] park, string[] routes) 
    {
        int H = park.Length;
        int W = park[0].Length;
        
        for(int i=0; i<H; i++)
        {
            for(int j=0; j<W; j++)
            {
                if(park[i][j] == 'S')
                {
                    pos[0] = i;
                    pos[1] = j;
                }
            }
        }
    
        foreach(string route in routes)
        {
            string[] routeSplit = route.Split(" ");
            char op = routeSplit[0][0];
            int n = int.Parse(routeSplit[1]);
            
            if(Command(park,H,W,op,n))
            {
                switch(op)
                {
                    case 'N':
                        pos[0] -= n;
                        break;
                    case 'S':
                        pos[0] += n;
                        break;
                    case 'W':
                        pos[1] -= n;
                        break;
                    case 'E':
                        pos[1] += n;
                        break;
                }
                Console.WriteLine(pos[0] +"," + pos[1]);
            }
        }
        return pos;
    }
    
    bool Command(string[] park, int H, int W, char op, int n)
    {
        switch(op)
        {
            case 'N':
                if(pos[0] - n < 0) return false;
                for(int i=1; i<=n; i++)
                {
                    if(park[pos[0] - i][pos[1]] == 'X') 
                        return false; 
                }
                break;
            case 'S':
                if(pos[0] + n > H - 1) return false;
                for(int i=1; i<=n; i++)
                {
                    if(park[pos[0] + i][pos[1]] == 'X') 
                        return false; 
                }
                break;
            case 'W':
                if(pos[1] - n  < 0) return false;
                for(int i=1; i<=n; i++)
                {
                    if(park[pos[0]][pos[1] - i] == 'X') 
                        return false; 
                }
                break;
            case 'E':
                if(pos[1] + n > W - 1) return false;
                for(int i=1; i<=n; i++)
                {
                    if(park[pos[0]][pos[1] + i] == 'X') 
                        return false; 
                }
                break;
        }
        return true;
    }
}