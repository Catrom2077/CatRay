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

        public override string ToString() =>
            $"X:{X}, Y:{Y}, Z:{Z}";
    }
}