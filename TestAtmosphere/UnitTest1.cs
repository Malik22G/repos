using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;

namespace Atmosphere_nps
{
    [TestClass]
    public class AtmosphereTests
    {
        private string CreateTempInputFile(int numLayers, List<(char, double)> layerData, string conditions)
        {
            string tempFilePath = Path.GetTempFileName();
            using (StreamWriter writer = new StreamWriter(tempFilePath))
            {
                writer.WriteLine(numLayers);

                foreach (var layer in layerData)
                {
                    writer.WriteLine($"{layer.Item1} {layer.Item2}");
                }

                writer.WriteLine(conditions);
            }
            return tempFilePath;
        }

        [TestMethod]
        public void Test_ZeroLayer()
        {
            string tempFile = CreateTempInputFile(0, new List<(char, double)>(), "OS");
            var atmosphere = new Atmosphere(tempFile);

            atmosphere.LoadDataSimulate();

            Assert.AreEqual(0, atmosphere.layers.Count);

        }

        [TestMethod]
        public void Test_OneLayer()
        {
            string tempFile = CreateTempInputFile(1, new List<(char, double)> { ('X', 1.0) }, "T");
            var atmosphere = new Atmosphere(tempFile);

            atmosphere.LoadDataSimulate();

            Assert.AreEqual(1, atmosphere.layers.Count);
            Assert.AreEqual("Oxygen", atmosphere.layers[0].Type);

        }

        [TestMethod]
        public void Test_MoreLayers()
        {
            string tempFile = CreateTempInputFile(3, new List<(char, double)> {
                ('X', 1.0), 
                ('Z', 1.0), 
                ('C', 1.0)  
            }, "OST");

            var atmosphere = new Atmosphere(tempFile);

            atmosphere.LoadDataSimulate();

            Assert.AreEqual(2, atmosphere.layers.Count);
            Assert.AreEqual("Ozone", atmosphere.layers[0].Type);
            Assert.AreEqual(0.95, atmosphere.layers[0].Thickness);
            Assert.AreEqual("CarbonDioxide", atmosphere.layers[1].Type);
            Assert.AreEqual(0.95, atmosphere.layers[1].Thickness);

        }

        [TestMethod]
        public void Test_FirstLayerPerishes()
        {
            string tempFile = CreateTempInputFile(3, new List<(char, double)> {
                ('Z', 0.4), 
                ('X', 1.0), 
                ('C', 1.0)  
            }, "O");

            var atmosphere = new Atmosphere(tempFile);

            atmosphere.LoadDataSimulate();

            Assert.AreEqual(2, atmosphere.layers.Count);
            Assert.AreEqual("Oxygen", atmosphere.layers[0].Type);

        }

        [TestMethod]
        public void Test_LastLayerPerishes()
        {
            string tempFile = CreateTempInputFile(3, new List<(char, double)> {
                ('X', 1.0), 
                ('Z', 1.0), 
                ('C', 0.4) 
            }, "S");

            var atmosphere = new Atmosphere(tempFile);

            atmosphere.LoadDataSimulate();

            Assert.AreEqual(2, atmosphere.layers.Count);
            Assert.AreEqual("Ozone", atmosphere.layers[1].Type);

        }
        [TestMethod]
        public void Test_MultipleTransformations()
        {
            string tempFile = CreateTempInputFile(3, new List<(char, double)> {
        ('X', 2.0), 
        ('Z', 3.0), 
        ('C', 1.0)  
    }, "TOS");

            var atmosphere = new Atmosphere(tempFile);
            atmosphere.LoadDataSimulate();

            Assert.AreEqual(2, atmosphere.layers.Count);
            Assert.AreEqual("Ozone", atmosphere.layers[0].Type);
            Assert.AreEqual("CarbonDioxide", atmosphere.layers[1].Type);
        }
        [TestMethod]
        public void Test_NewLayerAddition()
        {
            string tempFile = CreateTempInputFile(3, new List<(char, double)> {
        ('X', 2.0),
        ('Z', 3.0),
        ('C', 1.0)
    }, "TOS");
            var atmosphere = new Atmosphere(tempFile);

            atmosphere.LoadDataSimulate();

            Assert.AreEqual(2, atmosphere.layers.Count);
            Assert.AreEqual("Ozone", atmosphere.layers[0].Type);
        }

     

    }
}
