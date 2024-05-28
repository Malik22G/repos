using TextFile;


namespace Atmosphere_nps
{
    public class Atmosphere
    {
        public List<Layer> layers = new();
        private TextFileReader x;


        public Atmosphere(string filename)
        {
            x = new TextFileReader(filename);
        }

        public void LoadDataSimulate()
        {

            x.ReadInt(out int numLayers);

            for (int i = 0; i < numLayers; i++)
            {
                x.ReadChar(out char type);
                x.ReadDouble(out double thickness);

                layers.Add(Layer.CreateLayer(type, thickness));
                Console.Write($"{type} - {thickness}kms\n");
            }

            x.ReadString(out string conditions);

            Simulate(conditions);

        }

        private bool layerPerished(List<Layer> lst)
        {
            return lst.GroupBy(l => l.Type).Count() < 3;
        }
        public void Simulate(string conditions)
        {
            int iterationNum = 0;
            while (!layerPerished(layers))
            {
                for (int j = 0; j < conditions.Length && !layerPerished(layers); j++)
                {
                    iterationNum++;
                    List<(int, Layer)> newLayers = new List<(int, Layer)>();
                    char condition = conditions[j];
                    for (int i = 0; i < layers.Count; i++)
                    {
                        layers[i].Transform(condition, ref newLayers, i);

                    }
                    MergeLayers(layers, newLayers);

                    Console.WriteLine($"---------Iteration-Number:{iterationNum} ({condition}) ----------");
                    foreach (var layer in layers)
                    {
                        Console.WriteLine($"{layer.Type} - {layer.Thickness:F2} km");
                    }

                }


            }
        }

        private void MergeLayers(List<Layer> layers, List<(int, Layer)> newLayers)
        {


            foreach (var newlayer in newLayers)
            {
                foreach (var layer in layers.Take(newlayer.Item1))
                {
                    if (layer.Type == newlayer.Item2.Type)
                    {
                        layer.Merge(newlayer.Item2);
                        break;
                    }
                }
            }

            List<int> removeIndexes = new List<int>();

            for (int i = 0; i < layers.Count(); i++)
            {
                if (layers[i].Thickness < 0.5)
                {
                    removeIndexes.Add(i);
                }
            }
            foreach (int index in removeIndexes)
            {
                layers.RemoveAt(index);
            }





        }
    }
}