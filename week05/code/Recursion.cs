using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public static class Recursion
{
    /// <summary>
    /// Problem 1: Sum of squares recursively.
    /// 1^2 + 2^2 + ... + n^2 without using loops.
    /// Base case: if n <= 0, return 0.
    /// Recursive case: n*n + SumSquaresRecursive(n-1).
    /// </summary>
    public static int SumSquaresRecursive(int n)
    {
        if (n <= 0) 
            return 0;
        return n * n + SumSquaresRecursive(n - 1);
    }

    /// <summary>
    /// Problem 2: Generate all permutations of a given length from unique letters.
    /// Uses recursion to build up ‘word’ until its length == size, then adds to results.
    /// </summary>
    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        // Base case: built a permutation of the desired size
        if (word.Length == size)
        {
            results.Add(word);
            return;
        }

        // Recursive step: for each letter, remove it from 'letters' and append to 'word'
        for (int i = 0; i < letters.Length; i++)
        {
            char c = letters[i];
            string remaining = letters.Remove(i, 1);
            PermutationsChoose(results, remaining, size, word + c);
        }
    }

    /// <summary>
    /// Problem 3: Count the ways to climb s stairs taking 1, 2, or 3 steps at a time.
    /// Uses memoization (dictionary 'remember') to avoid exponential blow-up.
    /// Base cases: s=0→0, s=1→1, s=2→2, s=3→4.
    /// Recursive case: sum of the three previous counts.
    /// </summary>
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        if (remember == null) 
            remember = new Dictionary<int, decimal>();

        if (remember.TryGetValue(s, out decimal cached)) 
            return cached;

        // Base cases
        if (s == 0) return 0;
        if (s == 1) return 1;
        if (s == 2) return 2;
        if (s == 3) return 4;

        // Recursive step with memoization
        decimal ways = CountWaysToClimb(s - 1, remember)
                     + CountWaysToClimb(s - 2, remember)
                     + CountWaysToClimb(s - 3, remember);

        remember[s] = ways;
        return ways;
    }

    /// <summary>
    /// Problem 4: Expand a binary pattern containing wildcards '*' into all possible strings.
    /// E.g., "1*0" → "100", "110".
    /// Finds the first '*', recurses replacing it with '0' and '1'.
    /// </summary>
    public static void WildcardBinary(string pattern, List<string> results)
    {
        int idx = pattern.IndexOf('*');
        if (idx == -1)
        {
            results.Add(pattern);
            return;
        }

        string before = pattern.Substring(0, idx);
        string after  = pattern.Substring(idx + 1);

        // Recurse on both replacements
        WildcardBinary(before + "0" + after, results);
        WildcardBinary(before + "1" + after, results);
    }

    /// <summary>
    /// Problem 5: Find all paths from (0,0) to the 'end' cell in the maze.
    /// Assumes Maze provides:
    ///   bool IsValidMove(x,y,visitedPath);
    ///   bool IsEnd(x,y);
    /// Use backtracking to explore four directions.
    /// </summary>
    public static void SolveMaze(
        List<string> results,
        Maze maze,
        int x = 0,
        int y = 0,
        List<(int, int)>? currPath = null)
    {
        if (currPath == null)
            currPath = new List<(int, int)>();

        // Skip invalid moves or revisits
        if (!maze.IsValidMove(x, y, currPath))
            return;

        // Add current position
        currPath.Add((x, y));

        // If at end, record the path string
        if (maze.IsEnd(x, y))
        {
            results.Add(currPath.AsString());
        }
        else
        {
            // Explore in each direction
            SolveMaze(results, maze, x + 1, y, currPath);
            SolveMaze(results, maze, x - 1, y, currPath);
            SolveMaze(results, maze, x, y + 1, currPath);
            SolveMaze(results, maze, x, y - 1, currPath);
        }

        // Backtrack: remove last step before returning
        currPath.RemoveAt(currPath.Count - 1);
    }
}
