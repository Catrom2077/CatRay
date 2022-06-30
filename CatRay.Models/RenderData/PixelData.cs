namespace CatRay.Models.RenderData
{
    public class PixelData
    {
        public PixelData(CatRayColor color, float depth, float emission)
        {
            Color = color;
            Depth = depth;
            Emission = emission;
        }

        public CatRayColor Color { get; private set; } = CatRayColor.WHITE;

        public float Depth { get; private set; } = 0f;

        public float Emission { get; private set; } = 0f;

        public void Multiply(float brightness) =>
            Color = Color.Multiply(brightness);

        public void Add(PixelData pixelData)
        {
            Color.AddSelf(pixelData.Color);
            Depth = (Depth + pixelData.Depth) / 2f;
            Emission += pixelData.Emission;
        }
    }
}