public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // Step 1: Create a double array with the given length
        double[] multiples = new double[length];

        // Step 2: Use a loop to fill the array with multiples of the number
        // Each element at position i should be: number * (i + 1)
        for (int i = 0; i < length; i++)
        {
            multiples[i] = number * (i + 1);
        }

        // Step 3: Return the resulting array
        return multiples;
         // replace this return statement with your own
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        int index = data.Count - amount;

        // Step 2: Use GetRange to split the list into two parts
        List<int> endPart = data.GetRange(index, amount);     // The last 'amount' elements
        List<int> startPart = data.GetRange(0, index);        // The first elements up to the split point

        // Step 3: Clear the original list
        data.Clear();

        // Step 4: Add the two parts in rotated order
        data.AddRange(endPart);   // First, add the last part
        data.AddRange(startPart); // Then, add the first part
    }
}
