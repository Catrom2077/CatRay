using CatRay.Models.Solids.Abstract;

namespace CatRay.Models.CatRayMath
{
    public class RayHit
    {
        public RayHit()
        {
            Empty = new RayHit();
        }

        public RayHit(Ray ray, ISolid solid, Vector3 hitPosition)
        {
            Ray = ray;
            Solid = solid;
            HitPosition = hitPosition;
            Normal = solid.GetNormal(HitPosition);
        }

        public ISolid Solid { get; private set; }

        public Ray Ray { get; private set; } = new();

        public Vector3 HitPosition { get; private set; } = new();

        public Vector3 Normal { get; private set; } = new();

        public RayHit Empty { get; private set; } = new();
    }
}