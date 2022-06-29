using CatRay.Models.Solids.Abstract;

namespace CatRay.Models.Math
{
    public class RayHit
    {
        public RayHit(Ray ray, ISolid solid, Vector3 hitPosition)
        {
            Ray = ray;
            Solid = solid;
            HitPosition = hitPosition;
            //Normal = solid.GetNormal(HitPosition);
        }

        public ISolid Solid { get; private set; }

        public Ray Ray { get; private set; } = new();

        public Vector3 HitPosition { get; private set; } = new();

        public Vector3 Normal { get; private set; } = new();
    }
}