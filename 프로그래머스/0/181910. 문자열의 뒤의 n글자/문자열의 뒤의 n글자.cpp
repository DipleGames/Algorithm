#include <string>
#include <vector>

using namespace std;

string solution(string my_string, int n) 
{
    string str = "";
    int s = my_string.size() - n;
    str = my_string.substr(s,n);
    return str;
}