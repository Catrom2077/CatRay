using System.Drawing;
using CatRay.Models.CatRayMath;
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

        public Vector3 GetNormal(Vector3 point)
        {
            float[] directions = point.Substruct(Position).ToArray();
            float value = 0f;

            for(int i = 0; i < directions.Length; i++)
                if(value == 0f || value < Math.Abs(directions[i]))
                    value = Math.Abs(directions[i]);

            if (value == 0f)
                return new Vector3().Zero;
            else
            {
                for(int i = 0; i < directions.Length; i++)
                {
                    if (Math.Abs(directions[i]) == value)
                    {
                        float[] normals = new float[] { 0f, 0f, 0f };
                        normals[i] = directions[i] > 0f ? 1f : -1f;

                        return new Vector3(normals[0], normals[1], normals[2]);
                    }
                }
            }

            return new Vector3().Zero;
        }
    }
}