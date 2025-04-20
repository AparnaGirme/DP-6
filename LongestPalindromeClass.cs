public class Solution {
    // TC => O(n^2)
    // SC => O(n^2)
    int start1 = 0, end1 = 0, max1 = 0;
    public string LongestPalindrome(string s) {
        if(string.IsNullOrEmpty(s)){
            return s;
        }

        int n = s.Length;
        for(int i = 0; i < n; i++){
            ExpandAroundCenter(s, i, i);
            if(i < n - 1){
                ExpandAroundCenter(s, i, i+1);
            }
        }
        return s.Substring(start1, max1);
    }

    public void ExpandAroundCenter(string s, int left, int right){
        while((left >= 0 && right < s.Length) && (s[left] == s[right])){
            left--;
            right++;
        }
        left++;
        right--;

        if(max1 < right - left + 1){
            max1 = right - left + 1;
            start1 = left;
            end1 = right;
        }
    }
    // TC => O(n^2)
    // SC => O(n^2)
    public string LongestPalindrome1(string s) {
        if(string.IsNullOrEmpty(s)){
            return s;
        }

        int n = s.Length;

        bool[][] dp = new bool[n][];

        int start = 0, end = 0, max = 0;
        for(int i = 0; i < n; i++){
            dp[i] = new bool[n];
            for(int j = 0; j <= i; j++){
                if((s[i] == s[j]) && ((i - j - 1 < 2 )|| dp[i-1][j+1])){
                    dp[i][j] = true;
                }
                if(dp[i][j] && i - j + 1 > max){
                    max = i - j + 1;
                    start = j;
                    end = i;
                }
            }
        }
        return s.Substring(start, max);
    }
}