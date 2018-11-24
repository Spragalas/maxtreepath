using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeMaxPath
    {
    public class PyramidResolver
        {
        private Pyramid m_pyramid;
        public PyramidResolver (Pyramid pyramid)
            {
            m_pyramid = pyramid;
            }

        public int ResolveMax ()
            {
            while ( m_pyramid.Dimension != 1 )
                {
                LowerDimension();
                }
            return (int) m_pyramid.GetLastRow()[0].Value;
            }

        private void LowerDimension ()
            {
            PyramidElement[] penultimateRow = m_pyramid.GetPenultimateRow();
            PyramidElement[] lastRow = m_pyramid.GetLastRow();
            PyramidElement[] resultRow = new PyramidElement[penultimateRow.Length];

            for ( int i = 0; i < penultimateRow.Length; i++ )
                {
                PyramidElement parent = penultimateRow[i];
                PyramidElement leftChild = lastRow[i];
                PyramidElement rightChild = lastRow[i + 1];

                int? max = null;
                if ( parent.OriganlOdd )
                    {
                    if ( !leftChild.OriganlOdd && !rightChild.OriganlOdd )
                        max = Math.Max((int) leftChild.Value, (int) rightChild.Value);
                    else if ( !leftChild.OriganlOdd && rightChild.OriganlOdd )
                        max = leftChild.Value;
                    else if ( leftChild.OriganlOdd && !rightChild.OriganlOdd )
                        max = rightChild.Value;
                    }
                else
                    {
                    if ( leftChild.OriganlOdd && rightChild.OriganlOdd )
                        max = Math.Max((int) leftChild.Value, (int) rightChild.Value);
                    else if ( leftChild.OriganlOdd && !rightChild.OriganlOdd )
                        max = leftChild.Value;
                    else if ( !leftChild.OriganlOdd && rightChild.OriganlOdd )
                        max = rightChild.Value;
                    }
                // if max is null it means that parent, left child and right child are all even or odd
                // rules don't describe how to handle this situation so i chooce to set max value as parent value 
                // this way i assume that path pyramid is lower dimension 
                int result = max.HasValue ? (int) max + (int) parent.Value : (int) parent.Value;
                resultRow[i] = new PyramidElement(result, parent.OriganlOdd);
                }
            m_pyramid.LowerDimension(resultRow);
            }
        }
    }
