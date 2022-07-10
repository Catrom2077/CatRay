using CatRay.Models.CatRayMath;
using CatRay.Models.RenderData;
using System.Drawing.Imaging;
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
                byte[,,] rgbBytes = BitmapToByteRGB(_skybox);
                
                int red = rgbBytes.GetLength(0);
                int green = rgbBytes.GetLength(1);
                int blue = rgbBytes.GetLength(2);

                Color color = Color.FromArgb(red, green, blue);
                int result = color.ToArgb();

                return CatRayColor.FromInt(result);
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Exception: {exception.Message}\nU: {u} V: {v}");
                return CatRayColor.MAGENTA;
            }
        }

        public unsafe byte[,,] BitmapToByteRGB(Bitmap bitmap)
        {
            int width = bitmap.Width;
            int height = bitmap.Height;

            byte[,,] result = new byte[3, height, width];

            BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

            try
            {
                byte* curpos;
                fixed (byte* _res = result)
                {
                    byte* red = _res, green = _res + width * height, blue = _res + 2 * width * height;
                    for (int i = 0; i < height; i++)
                    {
                        curpos = ((byte*)bitmapData.Scan0) + i * bitmapData.Stride;

                        for (int j = 0; j < width; j++)
                        {
                            *blue = *(curpos++); ++blue;
                            *green = *(curpos++); ++green;
                            *red = *(curpos++); ++red;
                        }
                    }
                }
            }
            finally
            {
                bitmap.UnlockBits(bitmapData);
            }
            return result;
        }

        public bool IsLoaded() => _isLoaded;
    }
}