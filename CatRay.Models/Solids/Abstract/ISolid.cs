using CatRay.Models.Math;

namespace CatRay.Models.Solids.Abstract
{
    public interface ISolid
    {
        public Vector3 Position { get; set; }

        public Vector3 Scale { get; set; }

        public float Reflectivity { get; set; }

        public float Emission { get; set; }
    }
}