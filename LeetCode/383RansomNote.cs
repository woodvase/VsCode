namespace LeetCode
{
    using System;
    using System.Collections.Generic;
    

   public partial class Solution {
    public bool CanConstruct(string ransomNote, string magazine) {
        if(string.IsNullOrEmpty(ransomNote))
            {
                return true;
            }

            if (string.IsNullOrEmpty(magazine))
            {
                return false;
            }

            int[] dict1 = new int[26];
            int[] dict2 = new int[26];
            for (int i = 0; i < ransomNote.Length; i++)
            {
                dict1[ransomNote[i]-'a'] ++;
            }

            for(int j = 0; j < magazine.Length; j ++)
            {
                dict2[magazine[j] - 'a'] ++;
            }

            for(int i = 0; i < 26; i ++)
            {
                if(dict2[i] < dict1[i])
                {
                    return false;
                }
            }

            return true;
    }
}
}