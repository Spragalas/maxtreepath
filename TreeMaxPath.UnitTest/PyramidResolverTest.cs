using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TreeMaxPath.UnitTest
    {
    [TestClass]
    public class PyramidResolverTest
        {
        [TestMethod]
        public void SampleData ()
            {
            Pyramid pyramid = PyramidBuilder.BuildFromRaw(new List<int[]> {
                new int[] { 1 },
                new int[] { 8, 9 },
                new int[] { 1, 5, 9 },
                new int[] { 4, 5, 2, 3 }});
            Assert.AreEqual(16, new PyramidResolver(pyramid).ResolveMax());
            }

        [TestMethod]
        public void OneDimension ()
            {
            Pyramid pyramid = PyramidBuilder.BuildFromRaw(new List<int[]> {
                new int[] { 1 }
                });
            Assert.AreEqual(1, new PyramidResolver(pyramid).ResolveMax());
            }

        [TestMethod]
        public void TwoDimension ()
            {
            Pyramid pyramid = PyramidBuilder.BuildFromRaw(new List<int[]> {
                new int[] { 1 },
                new int[] { 220, 221 }
                });
            Assert.AreEqual(221, new PyramidResolver(pyramid).ResolveMax());
            }

        [TestMethod]
        public void AllOds ()
            {
            Pyramid pyramid = PyramidBuilder.BuildFromRaw(new List<int[]> {
                new int[] { 9 },
                new int[] { 15, 11 },
                new int[] { 151, 113, 129 }
                });
            Assert.AreEqual(9, new PyramidResolver(pyramid).ResolveMax());
            }

        [TestMethod]
        public void AllEvens ()
            {
            Pyramid pyramid = PyramidBuilder.BuildFromRaw(new List<int[]> {
                new int[] { 8 },
                new int[] { 12, 16 },
                new int[] { 152, 112, 110 }
                });
            Assert.AreEqual(8, new PyramidResolver(pyramid).ResolveMax());
            }
        }
    }
