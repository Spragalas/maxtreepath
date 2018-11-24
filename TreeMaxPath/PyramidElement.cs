using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeMaxPath
    {
    public struct PyramidElement
        {
        public PyramidElement (int value, bool valueOdd)
            {
            Value = value;
            OriganlOdd = valueOdd;
            }
        public int? Value
            {
            get; set;
            }
        public bool OriganlOdd
            {
            get; private set;
            }
        }
    }
