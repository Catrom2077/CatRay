namespace CatRay.Models.RenderData
{
    public class GaussianBlur
    {
        public GaussianBlur(PixelBuffer pixelBuffer)
        {
            pixelBuffer = pixelBuffer ?? throw new ArgumentNullException(nameof(pixelBuffer), "is null!");
            _width = pixelBuffer.Width;
            _height = pixelBuffer.Height;
            _kernel = new float[]
            {
                0.0093F,
                0.028002F,
                0.065984F,
                0.121703F,
                0.175713F,
                0.198596F,
                0.175713F,
                0.121703F,
                0.065984F,
                0.028002F,
                0.0093F
            };
        }

        private PixelBuffer _pixelBuffer = new(0,0);
        private readonly float[] _kernel;
        private readonly int _width = 0;
        private readonly int _height = 0;

        #region Methods

        public void Blur(int radius, int iterations)
        {
            for (int i = 0; i < iterations; i++)
            {
                HorizontalBlur(radius);
                VerticallyBlur(radius);
            }
        }

        public void HorizontalBlur(int radius)
        {
            PixelBuffer result = new(_width, _height);
            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _width; x++)
                {
                    CatRayColor blurredColor = new(0f, 0f, 0f);
                    PixelData originalPixel = _pixelBuffer.GetPixel(x, y);

                    for (int i = -radius; i <= radius; i++)
                    {
                        float kernelMultiplier = _kernel[(int)((i + radius) / (radius * 2F) * (_kernel.Length - 1))];

                        if (x + i >= 0 && x + i < _width)
                        {
                            PixelData pixel = _pixelBuffer.GetPixel(x + i, y);

                            if (pixel != null)
                                blurredColor.AddSelf(pixel.Color.Multiply(kernelMultiplier));
                        }
                    }

                    result.SetPixel(x, y, new(blurredColor, originalPixel.Depth, originalPixel.Emission));
                }
            }
            _pixelBuffer = result;
        }

        public void VerticallyBlur(int radius)
        {
            PixelBuffer result = new(_width, _height);

            for (int x = 0; x < _width; x++)
            {
                for (int y = 0; y < _height; y++)
                {
                    CatRayColor blurredColor = new(0, 0, 0);
                    PixelData originalPixel = _pixelBuffer.GetPixel(x, y);

                    for (int i = -radius; i <= radius; i++)
                    {
                        float kernelMultiplier = _kernel[(int)((i + radius) / (radius * 2F) * (_kernel.Length - 1))];

                        if (y + i >= 0 && y + i < _height)
                        {
                            PixelData pixel = _pixelBuffer.GetPixel(x, y + i);

                            if (pixel != null)
                                blurredColor.AddSelf(pixel.Color.Multiply(kernelMultiplier));
                        }
                    }

                    result.SetPixel(x, y, new PixelData(blurredColor, originalPixel.Depth, originalPixel.Emission));
                }
            }
            _pixelBuffer = result;
        }

        #endregion
    }
}