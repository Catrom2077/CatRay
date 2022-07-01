using CatRay.Models.CatRayMath;

namespace CatRay.Controllers.Rendering
{
    public class Light
    {
        public Light()
        {
            Position = new Vector3().Zero;
        }

        public Vector3 Position { get; private set; }

        public void SetPosition(Vector3 position) =>
            Position = position;
    }
}