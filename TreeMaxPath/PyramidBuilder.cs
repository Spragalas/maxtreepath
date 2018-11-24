using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeMaxPath
    {
    public static class PyramidBuilder
        {
        private class PyramidWrapper : Pyramid
            {
            public PyramidWrapper (List<int[]> rawPyramid) : base(rawPyramid)
                {
                }
            }

        public static Pyramid BuildFromRaw (List<int[]> rawPyramid)
            {
            int lineNumber = 0;
            foreach ( int[] elements in rawPyramid )
                {
                if ( elements.Length != lineNumber + 1 )
                    throw new PyramidFormatException($"Expected '{lineNumber + 1}' element{((lineNumber + 1) > 1 ? "s" : "")} at line '{lineNumber + 1}'");
                lineNumber++;
                }
            return new PyramidWrapper(rawPyramid);
            }

        public static Pyramid BuildFromFile (string filePath)
            {
            List<int[]> rawPyramid = new List<int[]>();

            int lineNumber = 0;
            using ( TextReader reader = File.OpenText(filePath) )
                {
                string line;
                while ( (line = reader.ReadLine()) != null )
                    {
                    int[] pyramidRow = new int[lineNumber + 1];
                    string[] blobs = line.Split(' ');

                    if ( blobs.Length != lineNumber + 1 )
                        throw new PyramidFormatException($"Expected '{lineNumber + 1}' element{((lineNumber + 1) > 1 ? "s" : "")} at line '{lineNumber + 1}'");

                    int blobNumber = 0;
                    foreach ( string blob in blobs )
                        {
                        if ( !int.TryParse(blob, out int parsedBlob) )
                            throw new PyramidFormatException($"Pyramid element at line '{lineNumber + 1}' at index '{blobNumber + 1}' is not int. All numbers in pyramid must be ints.");
                        else
                            pyramidRow[blobNumber] = parsedBlob;
                        blobNumber++;
                        }
                    rawPyramid.Add(pyramidRow);
                    lineNumber++;
                    }
                }

            return new PyramidWrapper(rawPyramid);
            }
        }
    }
