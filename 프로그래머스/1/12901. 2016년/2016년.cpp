#include <string>
#include <vector>
#include <iostream>

using namespace std;

string solution(int a, int b) 
{
    vector<int> arr = {31,29,31,30,31,30,31,31,30,31,30,31};
    
    int ans = 0;
    if(a == 1)
    { 
        ans += b;
    }
    else
    {
        for(int i=0; i<a-1; i++)
        {
            ans += arr[i];
        }
        ans += b;
    }
    string answer;
    cout << ans;
    switch((ans - 1)%7)
    {
        case 0:
            answer = "FRI";
            break;
        case 1:
            answer = "SAT";
            break;
        case 2:
            answer = "SUN";
            break;
        case 3:
            answer = "MON";
            break;
        case 4:
            answer = "TUE";
            break;
        case 5:
            answer = "WED";
            break;
        case 6:
            answer = "THU";
            break;
    }
    return answer;
}