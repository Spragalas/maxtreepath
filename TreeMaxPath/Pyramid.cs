using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeMaxPath
    {
    public abstract class Pyramid
        {
        private readonly List<int[]> m_rawPyramid;
        private List<PyramidElement[]> m_pyramid = new List<PyramidElement[]>();

        public Pyramid (List<int[]> rawPyramid)
            {
            m_rawPyramid = rawPyramid;
            PreparePyramid();
            }

        private void PreparePyramid ()
            {
            foreach ( int[] pyramidRow in m_rawPyramid )
                {
                m_pyramid.Add(pyramidRow.Select(x => new PyramidElement(x, IsOdd(x))).ToArray());
                }
            }

        private bool IsOdd (int number) => number % 2 != 0;

        public int Dimension => m_pyramid.Count;

        public PyramidElement[] GetLastRow () => m_pyramid.Last();

        public PyramidElement[] GetPenultimateRow () => m_pyramid.ElementAt(m_pyramid.Count - 2);

        public void LowerDimension (PyramidElement[] row)
            {
            m_pyramid.RemoveAt(m_pyramid.Count - 1);
            m_pyramid.RemoveAt(m_pyramid.Count - 1);
            m_pyramid.Add(row);
            }
        }
    }
