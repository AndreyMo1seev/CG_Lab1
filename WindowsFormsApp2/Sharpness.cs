using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    class Sharpness : MatrixFilter
    {
        public Sharpness()
        {
            kernel = new float[,]
                   {{0, -1, 0 },
                        {-1, 5, -1 },
                        {0, -1, 0 }};

        }
    }
}
