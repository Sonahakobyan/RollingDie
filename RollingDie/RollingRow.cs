using System.Collections.Generic;

namespace RollingDie
{
    /// <summary>
    /// Rolling die simulator
    /// </summary>
    class RollingRow
    {
        /// <summary>
        /// Start index of the row subsequence while checking it
        /// </summary>
        private int startIndex;

        /// <summary>
        /// End index of the row subsequence while checking it
        /// </summary>
        private int endIndex;

        /// <summary>
        /// Sum of 5 consecutive die nums in the row
        /// </summary>
        private int sumOfDieNums;

        /// <summary>
        /// Count of double consecutive six
        /// </summary>
        private int countOfDoubleSix;

        /// <summary>
        /// Appropriate message when six happens two times in the row 
        /// </summary>
        private const string MsgForSix = "Two sixes in a row!";

        /// <summary>
        /// Appropriate message when the sum of 5 consecutive die nums is greater than or equal to 20
        /// </summary>
        private const string MsgForSum = "I get 20!!!";

        /// <summary>
        /// Collector for rolling dies
        /// </summary>
        private readonly List<Die> row;

        /// <summary>
        /// vent which is triggered if die shows two sixes in a row
        /// </summary>
        private TwoSixes DoubleSix;

        /// <summary>
        /// Event which is triggered if 5 consecutive die nums is greater than or equal to 20
        /// </summary>
        private TwoSixes Get20;

        /// <summary>
        /// Create object with given functions and init the row
        /// </summary>
        /// <param name="doubleSix"> Function for double six event</param>
        /// <param name="get20"> Function for 5 consecutive dies numbers' event </param>
        public RollingRow(TwoSixes doubleSix, TwoSixes get20)
        {
            DoubleSix = doubleSix;
            Get20 = get20;
            row = new List<Die>();
        }

        /// <summary>
        /// Check the row and raise an event if 5 consecutive die nums is greater than or equal to 20.
        /// </summary>
        private void CheckRow()
        {
            endIndex = row.Count - 1;
            sumOfDieNums += row[endIndex].Num;

            if (endIndex < 4)
            {
                return;
            }

            if (sumOfDieNums >= 20)
            {
                Get20(MsgForSum);
            }
            sumOfDieNums -= row[startIndex].Num;
            startIndex++;
        }

        /// <summary>
        /// Rolling die n times. Raising Print event if die shows two sixes in a row.
        ///  And another Print event if 5 consecutive die nums is greater than or equal to 20
        /// </summary>
        /// <param name="n">Represents die roles count</param>
        public void Roll(int n)
        {
            Die previous = new Die();
            row.Add(previous);
            CheckRow();
            n--;

            while (n > 0)
            {
                if (previous.Num == 6)
                {
                    Die current = new Die();
                    row.Add(current);
                    CheckRow();

                    if (current.Num == 6)
                    {
                        DoubleSix(MsgForSix);
                        countOfDoubleSix++;
                    }
                    previous = current;
                }
                else
                {
                    previous = new Die();
                    row.Add(previous);
                    CheckRow();
                }

                n--;
            }

            if (n == 0)
            {
                DoubleSix(countOfDoubleSix.ToString() + " times");
            }
        }
    }
}
