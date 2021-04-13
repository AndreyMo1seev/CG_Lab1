using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    class Sharpness2: MatrixFilter
    {
        public Sharpness2()
        {
            kernel = new float[,]
                   {{-1, -1, -1 },
                        {-1, 9, -1 },
                        {-1, -1, -1 }};

        }
    }
}
