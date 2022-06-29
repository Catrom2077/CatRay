namespace CatRay.Models.Math
{
    public class Vector3
    {
        public Vector3()
        {
            X = Zero.X;
            Y = Zero.Y;
            Z = Zero.Z;
        }

        public Vector3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public float X { get; private set; } = 0f;

        public float Y { get; private set; } = 0f;

        public float Z { get; private set; } = 0f;

        public Vector3 Zero { get; } = new Vector3(0f, 0f, 0f);

        public Vector3 Add(Vector3 vector) =>
            new(X + vector.X, Y + vector.Y, Z + vector.Z);

        public Vector3 Multiply(float scale) =>
            new(X * scale, Y * scale, Z * scale);

        public Vector3 Muliply(Vector3 vector) =>
            new(X * vector.X, Y * vector.Y, Z * vector.Z);

        public float Lenght() =>
            (float)System.Math.Sqrt(X * X + Y * Y + Z * Z);

        public Vector3 Substruct(Vector3 vector) =>
            new(X - vector.X, Y - vector.Y, Z - vector.Z);

        public float[] ToArray() =>
            new float[] { X, Y, Z };

        public Vector3 Normalize()
        {
            float length = Lenght();
            return new(X / length, Y / length, Z / length);
        }

        public override string ToString() =>
            $"X:{X}, Y:{Y}, Z:{Z}";
    }
}