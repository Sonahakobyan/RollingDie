using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RollingDie
{
    class Die
    {
        public readonly int Num;
        private static Random random;

        static Die()
        {
            random = new Random(DateTime.Now.Millisecond);
        }

        public Die()
        {
            this.Num = random.Next(1, 7);
        }
    }
}
