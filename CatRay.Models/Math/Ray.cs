﻿namespace CatRay.Models.Math
{
    public class Ray
    {
        public Ray()
        {
            Origin = new Vector3().Zero;

            Direction = new Vector3().Zero;
        }

        public Ray(Vector3 origin, Vector3 direction)
        {
            Origin = origin ?? throw new ArgumentNullException(nameof(origin), "is null!");
            Direction = direction ?? throw new ArgumentNullException(nameof(direction), "is null!");
        }

        public Vector3 Origin { get; private set; } = new Vector3().Zero;

        public Vector3 Direction { get; private set; } = new Vector3().Zero;

        public override string ToString() =>
            $"Origin: {Origin}, Direction: {Direction}";
    }
}