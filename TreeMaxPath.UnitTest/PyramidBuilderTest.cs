using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TreeMaxPath.UnitTest
    {
    [TestClass]
    public class PyramidBuilderTest
        {
        [TestInitialize]
        public void Setup ()
            {
            if ( File.Exists(nameof(BuildFromFile_BadFormat) + ".txt") )
                File.Delete(nameof(BuildFromFile_BadFormat) + ".txt");
            if ( File.Exists(nameof(BuildFromFile) + ".txt") )
                File.Delete(nameof(BuildFromFile) + ".txt");
            }

        [TestCleanup]
        public void CleanUp ()
            {
            if ( File.Exists(nameof(BuildFromFile_BadFormat) + ".txt") )
                File.Delete(nameof(BuildFromFile_BadFormat) + ".txt");
            if ( File.Exists(nameof(BuildFromFile) + ".txt") )
                File.Delete(nameof(BuildFromFile) + ".txt");
            }

        [TestMethod]
        public void BuildRaw_BadFormat ()
            {
            Assert.ThrowsException<PyramidFormatException>(() =>
            {
                TreeMaxPath.PyramidBuilder.BuildFromRaw(new List<int[]>
                {
                new int[] { 1 },
                new int[] { 1 }
                });
            });
            }

        [TestMethod]
        public void BuildRaw ()
            {
            TreeMaxPath.Pyramid pyramid = TreeMaxPath.PyramidBuilder.BuildFromRaw(new List<int[]>
                {
                new int[] { 1 },
                new int[] { 1, 2 }
                });

            Assert.AreEqual(1, pyramid.GetLastRow()[0].Value);
            Assert.AreEqual(2, pyramid.GetLastRow()[1].Value);
            Assert.AreEqual(1, pyramid.GetPenultimateRow()[0].Value);
            }

        [TestMethod]
        public void BuildFromFile_BadFormat ()
            {
            using ( StreamWriter writer = new StreamWriter(nameof(BuildFromFile_BadFormat) + ".txt") )
                {
                writer.WriteLine("1");
                writer.WriteLine("4 2");
                writer.WriteLine("9");
                }
            Assert.ThrowsException<PyramidFormatException>(() =>
            {
                TreeMaxPath.PyramidBuilder.BuildFromFile(nameof(BuildFromFile_BadFormat) + ".txt");
            });
            }

        [TestMethod]
        public void BuildFromFile ()
            {
            using ( StreamWriter writer = new StreamWriter(nameof(BuildFromFile) + ".txt") )
                {
                writer.WriteLine("1");
                writer.WriteLine("4 2");
                }
            TreeMaxPath.Pyramid pyramid = TreeMaxPath.PyramidBuilder.BuildFromFile(nameof(BuildFromFile) + ".txt");

            Assert.AreEqual(1, pyramid.GetLastRow()[0].Value);
            Assert.AreEqual(4, pyramid.GetLastRow()[1].Value);
            Assert.AreEqual(2, pyramid.GetPenultimateRow()[0].Value);
            }
        }
    }
