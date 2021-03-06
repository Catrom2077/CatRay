using CatRay.Models.CatRayMath;

namespace CatRay.Models.Solids.Abstract
{
    public interface ISolid
    {
        public Vector3 Position { get; set; }

        public Vector3 Scale { get; set; }

        public float Reflectivity { get; set; }

        public float Emission { get; set; }

        public Vector3 GetNormal(Vector3 point);

        public Vector3 CalculateIntersection(Ray ray);
    }
}