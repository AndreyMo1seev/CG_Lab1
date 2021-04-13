using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    class MotionBlur : MatrixFilter
    {
        public MotionBlur()
        {
            kernel = new float[,]
                   {{1/3, 0, 0},
                        {0, 1/3, 0},
                        {0, 0, 1/3}};

        }
    }
}
