using System;

namespace Atmosphere_nps
{
    public abstract class Layer
    {
        public string Type { get; protected set; }
        public double Thickness { get; protected set; }

        protected Layer(double thickness)
        {
            Thickness = thickness;
        }

        public abstract void Transform(char atmosphericVariable, ref List<(int, Layer)> newLayers, int position);
        public abstract void Merge(Layer other);

        public static Layer CreateLayer(char type, double thickness)
        {
            return type switch
            {
                'Z' => new Ozone(thickness),
                'X' => new Oxygen(thickness),
                'C' => new CarbonDioxide(thickness),
                _ => throw new ArgumentException("Invalid layer type")
            };
        }
    }

    public class Ozone : Layer
    {
        public Ozone(double thickness) : base(thickness) { Type = "Ozone"; }

        public override void Transform(char atmosphericVariable, ref List<(int, Layer)> newLayers, int position)
        {
            if (atmosphericVariable == 'O')
            {
                double newThickness = Thickness * 0.05;
                newLayers.Add((position, new Oxygen(newThickness)));

                Thickness *= 0.95;

            }
        }

        public override void Merge(Layer other)
        {
            if (other.Type == Type)
                Thickness += other.Thickness;
        }
    }

    public class Oxygen : Layer
    {
        public Oxygen(double thickness) : base(thickness) { Type = "Oxygen"; }

        public override void Transform(char atmosphericVariable, ref List<(int, Layer)> newLayers, int position)
        {
            switch (atmosphericVariable)
            {
                case 'T':
                    double newOzoneThickness = Thickness * .5;
                    newLayers.Add((position, new Ozone(newOzoneThickness)));
                    Thickness *= 0.5;
                    break;
                case 'S':
                    double newOzoneThickness2 = Thickness * 0.05;
                    newLayers.Add((position, new Ozone(newOzoneThickness2)));
                    Thickness *= 0.95;
                    break;
                case 'O':
                    double newCo2Thickness = Thickness * 0.1;
                    newLayers.Add((position, new CarbonDioxide(newCo2Thickness)));
                    Thickness *= 0.9;
                    break;
            }
        }

        public override void Merge(Layer other)
        {
            if (other.Type == Type)
                Thickness += other.Thickness;
        }
    }

    public class CarbonDioxide : Layer
    {
        public CarbonDioxide(double thickness) : base(thickness) { Type = "CarbonDioxide"; }
        public override void Transform(char atmosphericVariable, ref List<(int, Layer)> newLayers, int position)
        {
            if (atmosphericVariable == 'S')
            {
                double newOxygenThickness = Thickness * 0.05;
                newLayers.Add((position, new Oxygen(newOxygenThickness)));

                Thickness *= 0.95;
            }
        }

        public override void Merge(Layer other)
        {
            if (other.Type == Type)
                Thickness += other.Thickness;
        }
    }
}