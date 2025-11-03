#include <string>
#include <vector>
#include <string>

using namespace std;

vector<int> solution(vector<string> intStrs, int k, int s, int l) 
{
    vector<int> ret;
    
    for(string str : intStrs)
    {
        string tmp = "";
        tmp = str.substr(s,l);
        
        if(k < stoi(tmp)) ret.push_back(stoi(tmp));
        
        tmp = "";
    }
    return ret;
}