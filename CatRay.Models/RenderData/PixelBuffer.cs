namespace CatRay.Models.RenderData
{
    public class PixelBuffer
    {
        public PixelBuffer(int width, int height)
        {
            Width = width;
            Height = height;

            Pixels = new PixelData[Width, Height];
        }

        public PixelData[,] Pixels { get; private set; }

        public int Width { get; private set; } = 0;

        public int Height { get; private set; } = 0;

        public PixelData GetPixel(int x, int y) =>
            Pixels[x, y];

        public void SetPixel(int x, int y, PixelData pixelData) =>
            Pixels[x, y] = pixelData;

        public void FilterByEmission(float minEmission)
        {
            for (int i = 0; i < Pixels.GetLength(0); i++)
            {
                for (int j = 0; j < Pixels.GetLength(1); j++)
                {
                    PixelData pixel = Pixels[i,j];

                    if (pixel != null && pixel.Emission < minEmission)
                        Pixels[i,j] = new PixelData(CatRayColor.BLACK, pixel.Depth, pixel.Emission);
                }
            }
        }

        public PixelBuffer Add(PixelBuffer pixelBuffer)
        {
            for (int i = 0; i < Pixels.GetLength(0); i++)
            {
                for (int j = 0; j < Pixels.GetLength(1); j++)
                {
                    PixelData pixel = Pixels[i,j];
                    PixelData otherPxl = pixelBuffer.Pixels[i,j];

                    if (pixel != null && otherPxl != null)
                        Pixels[i,j].Add(otherPxl);
                }
            }

            return this;
        }

        public PixelBuffer Multiply(float brightness)
        {
            for (int i = 0; i < Pixels.GetLength(0); i++)
                for (int j = 0; j < Pixels.GetLength(1); j++)
                    Pixels[i,j].Multiply(brightness);

            return this;
        }

        public PixelBuffer Resize(int newWidth, int newHeight)
        {
            PixelBuffer copy = new(newWidth, newHeight);

            for (int i = 0; i < newWidth; i++)
                for (int j = 0; j < newHeight; j++)
                    copy.Pixels[i,j] = Pixels[i / newWidth * Width,j / newHeight * Height];

            return copy;
        }

        public void CountEmptyPixels()
        {
            int emptyPixels = 0;
            for (int i = 0; i < Pixels.GetLength(0); i++)
                for(int j = 0; j < Pixels.GetLength(1); j++)
                    if (Pixels[i, j] == null)
                        emptyPixels++;
            
            Console.WriteLine($"Found {emptyPixels} empty pixels");
        }
    }
}