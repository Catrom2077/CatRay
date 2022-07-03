namespace CatRay.Models.CatRayMath
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

        #region Methods

        public Vector3 Add(Vector3 vector) =>
            new(X + vector.X, Y + vector.Y, Z + vector.Z);

        public Vector3 Substruct(Vector3 vector) =>
            new(X - vector.X, Y - vector.Y, Z - vector.Z);

        public Vector3 Multiply(float scale) =>
            new(X * scale, Y * scale, Z * scale);

        public Vector3 Muliply(Vector3 vector) =>
            new(X * vector.X, Y * vector.Y, Z * vector.Z);

        public Vector3 Divide(Vector3 vector) =>
            new(X / vector.X, Y / vector.Y, Z / vector.Z);

        public float Lenght() =>
            (float)Math.Sqrt(X * X + Y * Y + Z * Z);

        public float[] ToArray() =>
            new float[] { X, Y, Z };

        public Vector3 Clone() =>
            new(X, Y, Z);

        public static float Point(Vector3 a, Vector3 b) =>
            a.X * b.X + a.Y * b.Y + a.Z * b.Z;

        public static float Distance(Vector3 a, Vector3 b) =>
            (float)Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2) + Math.Pow(a.Z - b.Z, 2));

        public static Vector3 Lerp(Vector3 a, Vector3 b, float time) =>
            a.Add(b.Substruct(a).Multiply(time));

        public Vector3 Rotate(float yaw, float pitch)
        {
            double yawRadians = Math.PI / 180f * yaw;
            double pitchRadians = Math.PI / 180f * pitch;

            float y = (float)(Y * Math.Cos(pitchRadians) - Z * Math.Sin(pitchRadians));
            float z = (float)(Y * Math.Sin(pitchRadians) + Z * Math.Cos(pitchRadians));
            float x = (float)(X * Math.Cos(yawRadians) + z * Math.Sin(yawRadians));
            
            z = (float)(-X * Math.Sin(yawRadians) + z * Math.Cos(yawRadians));

            return new(x, y, z);
        }

        public void Translate(Vector3 direction)
        {
            X += direction.X;
            Y += direction.Y;
            Z += direction.Z;
        }

        public Vector3 Normalize()
        {
            float length = Lenght();
            return new(X / length, Y / length, Z / length);
        }

        #endregion

        public override string ToString() =>
            $"X:{X}, Y:{Y}, Z:{Z}";
    }
}