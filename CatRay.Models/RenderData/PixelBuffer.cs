namespace CatRay.Models.RenderData
{
    public class PixelBuffer
    {
        public PixelBuffer(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public int Width { get; private set; } = 0;
        public int Height { get; private set; } = 0;
    }
}