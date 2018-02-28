using System.Collections.Generic;

namespace RollingDie
{
    /// <summary>
    /// Rolling die simulator
    /// </summary>
    class RollingRow
    {
        private int startIndex;
        private int endIndex;
        private int sumOfDieNums;
        private int countOfDoubleSix;
        private const string MsgForSix = "Two sixes in a row!";
        private const string MsgForSum = "I get 20!!!";
        private readonly List<Die> row;
        private TwoSixes DoubleSix;
        private TwoSixes Get20;

        public RollingRow(TwoSixes doubleSix, TwoSixes get20)
        {
            DoubleSix = doubleSix;
            Get20 = get20;
            row = new List<Die>();
        }

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
