using CatRay.Models.CatRayMath;
using CatRay.Models.RenderData;
using CatRay.Models.Solids.Abstract;

namespace CatRay.Models.Solids
{
    public class Box : ISolid
    {
        public Box(Vector3 position, Vector3 scale, CatRayColor color, float reflectivity, float emission)
        {
            Position = position;
            Scale = scale;
            Color = color;
            Reflectivity = reflectivity;
            Emission = emission;

            Max = Position.Add(Scale.Multiply(0.5f));
            Min = Position.Substract(scale.Multiply(0.5f));

        }

        public Vector3 Position { get; set; } = new();

        public Vector3 Scale { get; set; } = new();

        public CatRayColor Color { get; set; } = new(1f, 1f, 1f);

        public float Reflectivity { get; set; } = 0f;

        public float Emission { get; set; } = 0f;

        public Vector3 Min { get; private set; } = new();
        public Vector3 Max { get; private set; } = new();

        public Vector3 GetNormal(Vector3 point)
        {
            float[] directions = point.Substract(Position).ToArray();
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

        public Vector3 CalculateIntersection(Ray ray)
        {
            float t1, t2, tnear = float.NegativeInfinity, tfar = float.PositiveInfinity, temp;

            bool intersectFlag = true;
            
            float[] rayDirection = ray.Direction.ToArray();
            float[] rayOrigin = ray.Origin.ToArray();
            float[] b1 = Min.ToArray();
            float[] b2 = Max.ToArray();

            for (int i = 0; i < 3; i++)
            {
                if (rayDirection[i] == 0)
                {
                    if (rayOrigin[i] < b1[i] || rayOrigin[i] > b2[i])
                        intersectFlag = false;
                }
                else
                {
                    t1 = (b1[i] - rayOrigin[i]) / rayDirection[i];
                    t2 = (b2[i] - rayOrigin[i]) / rayDirection[i];
                    if (t1 > t2)
                    {
                        temp = t1;
                        t1 = t2;
                        t2 = temp;
                    }
                    if (t1 > tnear)
                        tnear = t1;
                    if (t2 < tfar)
                        tfar = t2;
                    if (tnear > tfar)
                        intersectFlag = false;
                    if (tfar < 0)
                        intersectFlag = false;
                }
            }
            if (intersectFlag)
                return ray.Origin.Add(ray.Direction.Multiply(tnear));
            else
                return new Vector3().Zero;
        }
    }
}