using CatRay.Models.CatRayMath;
using CatRay.Models.RenderData;
using System.Drawing;

namespace CatRay.Controllers.Rendering
{
    public class Skybox
    {
        public Skybox(string resourceName)
        {
            _resourceName = resourceName ?? throw new ArgumentNullException(nameof(resourceName), "is null!");
            _skybox = null;
        }

        public Skybox(Bitmap skybox)
        {
            _skybox = skybox ?? throw new ArgumentNullException(nameof(skybox), "is null!");
        }

        private Bitmap? _skybox;
        private readonly string _resourceName = string.Empty;
        private bool _isLoaded = false;

        public void LoadSkybox()
        {
            if (_skybox == null) return;

            new Thread(() =>
            {
                try
                {
                    using FileStream stream = new(_resourceName, FileMode.Open);
                        _skybox = new Bitmap(stream);

                    _isLoaded = true;
                }
                catch(Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }

            }).Start();
        }

        public CatRayColor GetColor(Vector3 distance)
        {
            float u = (float)(0.5f + Math.Atan2(distance.Z, distance.X) / (2 * Math.PI));
            float v = (float)(0.5f - Math.Asin(distance.Y) / Math.PI);

            try
            {
                //GetRGB():
                return CatRayColor.RED;
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Exception: {exception.Message}\nU: {u} V: {v}");
                return CatRayColor.MAGENTA;
            }
        }

        //TODO: замінить на алгоритм пошуку пікселя через оперативку
        private int GetRGB(Bitmap skybox)
        {
            throw new NotImplementedException();
        }

        public bool IsLoaded() => _isLoaded;
    }
}