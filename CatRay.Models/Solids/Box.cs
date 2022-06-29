using System.Drawing;
using CatRay.Models.Math;
using CatRay.Models.Solids.Abstract;

namespace CatRay.Models.Solids
{
    public class Box : ISolid
    {
        public Box(Vector3 position, Vector3 scale, Color color, float reflectivity, float emission)
        {
            Position = position;
            Scale = scale;
            Color = color;
            Reflectivity = reflectivity;
            Emission = emission;
        }

        public Vector3 Position { get; set; } = new();

        public Vector3 Scale { get; set; } = new();

        public Color Color { get; set; } = Color.White;

        public float Reflectivity { get; set; } = 0f;

        public float Emission { get; set; } = 0f;
    }
}