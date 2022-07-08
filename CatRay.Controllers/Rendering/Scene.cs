using CatRay.Models.CatRayMath;
using CatRay.Models.Solids.Abstract;

namespace CatRay.Controllers.Rendering
{
    public class Scene
    {
        public Scene()
        {
            Camera = new();
            Lights = new();
            Solids = new();
            Skybox = new("Skybox.png");

        }

        public Camera Camera { get; private set; }

        public List<Light> Lights { get; private set; }

        public List<ISolid> Solids { get; private set; }

        public Skybox Skybox { get; private set; }

        public void AddSolid(ISolid solid)
        {
            if(solid == null)
                throw new ArgumentNullException(nameof(solid), "is null!");

            Solids.Add(solid);
        }

        public void ClearSolids() =>
            Solids.Clear();

        public void AddLight(Light light)
        {
            if (light == null)
                throw new ArgumentNullException(nameof(light), "is null!");

            Lights.Add(light);
        }

        public void ClearLights() =>
            Lights.Clear();

        public RayHit Raycast(Ray ray)
        {
            RayHit closestHit = new RayHit().Empty;

            foreach(ISolid solid in Solids)
            {
                if (solid == null) continue;

                Vector3 hitPosition = solid.CalculateIntersection(ray);

                if (hitPosition != new Vector3().Zero && Vector3.Distance(new Vector3().Zero, ray.Origin) > Vector3.Distance(hitPosition, ray.Origin))
                    closestHit = new RayHit(ray, solid, hitPosition);
            }

            return closestHit;
        }
    }
}