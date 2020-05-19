using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace LeetCode
{
    public partial class UnitTests
    {
        private string ReadTestDataFromFile(string fileName)
        {
            var basePath = @"C:\Projects\Portfolio-dotNet\LeetCode\TestData";

            var path = Path.Combine(basePath, fileName);
            using (var sr = new StreamReader(path))
            {
                return sr.ReadToEnd();
            }
        }

        [Fact]
        public void FindJudgeTest()
        {
            var s = new Solution();
            int[][] trust;

            trust = new int[][] {
                new int[] {1, 2}
            };
            Assert.Equal(2, s.FindJudge(2, trust));

            trust = new int[][] {
                new int[] {1, 3},
                new int[] {2, 3},
            };
            Assert.Equal(3, s.FindJudge(3, trust));

            trust = new int[][] {
                new int[] {1, 3},
                new int[] {2, 3},
                new int[] {3, 1},
            };
            Assert.Equal(-1, s.FindJudge(3, trust));

            trust = new int[][] {
                new int[] {1, 2},
                new int[] {2, 3},
            };
            Assert.Equal(-1, s.FindJudge(3, trust));

            trust = new int[][] {
                new int[] {1, 3},
                new int[] {1, 4},
                new int[] {2, 3},
                new int[] {2, 4},
                new int[] {4, 3}
            };
            Assert.Equal(3, s.FindJudge(4, trust));

            trust = new int[][] { };
            Assert.Equal(1, s.FindJudge(1, trust));

            trust = new int[][] {
                new int[] {1, 2},
                new int[] {3, 2},
                new int[] {1, 3},
                new int[] {4, 1},
                new int[] {3, 1},
                new int[] {2, 1},
                new int[] {2, 3},
                new int[] {4, 3},
                new int[] {4, 2},
                new int[] {3, 4},
                new int[] {2, 4}
            };
            Assert.Equal(-1, s.FindJudge(4, trust));
        }

        [Fact]
        public void FloodFillTest()
        {
            var s = new Solution();
            int[][] image, retVal;
            int sr, sc, newColor;

            image = new int[][] {
                new int[] {1,1,1},
                new int[] {1,1,0},
                new int[] {1,0,1}
            };
            sr = 1;
            sc = 1;
            newColor = 2;

            retVal = new int[][] {
                new int[] {2,2,2},
                new int[] {2,2,0},
                new int[] {2,0,1}
            };

            Assert.Equal(retVal, s.FloodFill(image, sr, sc, newColor));

            image = new int[][] {
                new int[] {0,0,0},
                new int[] {0,1,1},
            };
            sr = 1;
            sc = 1;
            newColor = 1;
            Assert.Equal(image, s.FloodFill(image, sr, sc, newColor));
        }



        [Fact]
        public void SingleNonDuplicateTest()
        {
            var s = new Solution();
            int[] nums;

            nums = new int[] { 1, 1, 2, 3, 3, 4, 4, 8, 8 };
            Assert.Equal(2, s.SingleNonDuplicate(nums));

            nums = new int[] { 3, 3, 7, 7, 10, 11, 11 };
            Assert.Equal(10, s.SingleNonDuplicate(nums));
        }

        [Fact]
        public void RemoveKdigitsTest()
        {
            var s = new Solution();
            int k;
            string num, output;

            num = "1432219";
            k = 3;
            output = "1219";
            Assert.Equal(output, s.RemoveKdigits(num, k));

            num = "10200";
            k = 1;
            output = "200";
            Assert.Equal(output, s.RemoveKdigits(num, k));

            num = "10";
            k = 2;
            output = "0";
            Assert.Equal(output, s.RemoveKdigits(num, k));

            num = "0";
            k = 0;
            output = "0";
            Assert.Equal(output, s.RemoveKdigits(num, k));

            num = "12345";
            k = 0;
            output = num;
            Assert.Equal(output, s.RemoveKdigits(num, k));

            // 10,001 > 8899
            num = ReadTestDataFromFile("RemoveKdigits_input.txt");
            k = 1000;
            output = ReadTestDataFromFile("RemoveKdigits_output.txt");
            Assert.Equal(output, s.RemoveKdigits(num, k));
        }

        [Fact]
        public void TrieTest()
        {
            var trie = new Trie();

            string word1 = "apple", word2 = "app";

            trie.Insert(word1);

            Assert.True(trie.Search(word1));
            Assert.False(trie.Search(word2));
            Assert.True(trie.StartsWith(word2));

            trie.Insert(word2);

            Assert.True(trie.Search(word2));
        }

        [Fact]
        public void MaxSubarraySumCircularTest()
        {
            var s = new Solution();
            int[] A;

            A = new int[] { 1, -2, 3, -2 };
            Assert.Equal(3, s.MaxSubarraySumCircular(A));

            A = new int[] { 5, -3, 5 };
            Assert.Equal(10, s.MaxSubarraySumCircular(A));

            A = new int[] { 3, -1, 2, -1 };
            Assert.Equal(4, s.MaxSubarraySumCircular(A));

            A = new int[] { 3, -2, 2, -3 };
            Assert.Equal(3, s.MaxSubarraySumCircular(A));

            A = new int[] { -2, -3, -1 };
            Assert.Equal(-1, s.MaxSubarraySumCircular(A));
        }

        [Fact]
        public void OddEvenListTest()
        {
            var s = new Solution();
            ListNode input, expected;

            input = ListNode.Build(new int[] { 1, 2, 3, 4, 5 });
            expected = ListNode.Build(new int[] { 1, 3, 5, 2, 4 });
            Assert.Equal(expected, s.OddEvenList(input));

            input = ListNode.Build(new int[] { 2, 1, 3, 5, 6, 4, 7 });
            expected = ListNode.Build(new int[] { 2, 3, 6, 7, 1, 5, 4 });
            Assert.Equal(expected, s.OddEvenList(input));

            input = ListNode.Build(new int[] { 1, 2, 3, 4 });
            expected = ListNode.Build(new int[] { 1, 3, 2, 4 });
            Assert.Equal(expected, s.OddEvenList(input));

            input = ListNode.Build(new int[] { 1, 2, 3, 4, 5, 6 });
            expected = ListNode.Build(new int[] { 1, 3, 5, 2, 4, 6 });
            Assert.Equal(expected, s.OddEvenList(input));

            // Test Case 70/71
            var convertedArray = ReadTestDataFromFile("OddEvenList_input.txt")
                .Split(',')
                .Select(n => Convert.ToInt32(n))
                .ToArray();
            input = ListNode.Build(convertedArray);

            convertedArray = ReadTestDataFromFile("OddEvenList_output.txt")
                .Split(',')
                .Select(n => Convert.ToInt32(n))
                .ToArray();
            expected = ListNode.Build(convertedArray);
            Assert.Equal(expected, s.OddEvenList(input));
        }
        
        [Fact]
        public void CheckInclusionTest()
        {
            var s = new Solution();
            string s1, s2;

            s1 = "ab";
            s2 = "eidbaooo";
            Assert.True(s.CheckInclusion(s1, s2));

            s1 = "ab";
            s2 = "eidboaoo";
            Assert.False(s.CheckInclusion(s1, s2));

            s1 = "adc";
            s2 = "dcda";
            Assert.True(s.CheckInclusion(s1, s2));

            s1 = "hello";
            s2 = "ooolleoooleh";
            Assert.False(s.CheckInclusion(s1, s2));
        }

        [Fact]
        public void FindAnagramsTest()
        {
            var s = new Solution();
            string str, p;
            IList<int> expected;

            str = "cbaebabacd";
            p = "abc";
            expected = new List<int>() { 0, 6 };
            Assert.Equal(expected, s.FindAnagrams(str,p));

            str = "abab";
            p = "ab";
            expected = new List<int>() { 0, 1, 2 };
            Assert.Equal(expected, s.FindAnagrams(str,p));
        }
    }
}