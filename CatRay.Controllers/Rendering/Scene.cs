using CatRay.Models.Solids.Abstract;

namespace CatRay.Controllers.Rendering
{
    public class Scene
    {
        public Camera Camera { get; private set; }

        public List<Light> Lights { get; private set; }

        public List<ISolid> Solids { get; private set; }

        //public SkyBox SkyBox { get; private set; }
    }
}