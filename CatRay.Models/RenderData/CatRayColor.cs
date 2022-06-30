using System.Drawing;

namespace CatRay.Models.RenderData
{
    public class CatRayColor
    {
        public CatRayColor(float red, float green, float blue)
        {
            if (red > 1f || green > 1f || blue > 1f)
                throw new ArgumentOutOfRangeException("Colors parameters outside of the range");

            if(red < 0f || green < 0f || blue < 0f)
                throw new ArgumentOutOfRangeException("Colors parameters outside of the range");

            Red = red;
            Green = green;
            Blue = blue;
        }

        public float Red { get; private set; } = 0f;

        public float Green { get; private set; } = 0f;

        public float Blue { get; private set; } = 0f;

        public CatRayColor Add(CatRayColor color) =>
            new(Math.Min(1, Red + color.Red), Math.Min(1, Green + color.Green), Math.Min(1, Blue + color.Blue));

        public CatRayColor Add(float brightness) =>
            new(Math.Min(1, Red + brightness), Math.Min(1, Green + brightness), Math.Min(1, Blue + brightness));

        public CatRayColor Multiply(CatRayColor color) =>
            new(Red * color.Red, Green * color.Green, Blue * color.Blue);

        public float GetLuminance() =>
            Red * 0.2126f + Green * 0.7152f + Blue * 0.0722f;

        public Color ToColor() =>
            Color.FromArgb(GetRGB());

        private static float Lerp(float a, float b, float t) =>
            a + t * (b - a);

        public static CatRayColor Lerp(CatRayColor a, CatRayColor b, float t) =>
            new(Lerp(a.Red, b.Red, t), Lerp(a.Green, b.Green, t), Lerp(a.Blue, b.Blue, t));

        public int GetRGB()
        {
            int red = (int)(Red * 255);
            int green = (int)(Green * 255);
            int blue = (int)(Blue * 255);

            red = (red << 16) & 0x00FF0000;
            green = (green << 8) & 0x0000FF00;
            blue &= 0x000000FF;

            return (int)(0xFF000000 | red | green | blue);
        }

        public static CatRayColor Average(List<CatRayColor> colors)
        {
            float rSum = 0;
            float gSum = 0;
            float bSum = 0;

            int colorCount = colors.Count;
            for (int i = 0; i < colorCount; i++)
            {
                rSum += colors[i].Red;
                gSum += colors[i].Green;
                bSum += colors[i].Blue;
            }

            return new(rSum / colorCount, gSum / colorCount, bSum / colorCount);
        }

        public static CatRayColor Average(params CatRayColor[] colors)
        {
            float rSum = 0;
            float gSum = 0;
            float bSum = 0;

            int colorCount = colors.Length;
            for (int i = 0; i < colorCount; i++)
            {
                rSum += colors[i].Red;
                gSum += colors[i].Green;
                bSum += colors[i].Blue;
            }

            return new(rSum / colorCount, gSum / colorCount, bSum / colorCount);
        }

        public static CatRayColor Average(List<CatRayColor> colors, List<float> weights)
        {
            if (colors.Count != weights.Count)
                throw new ArgumentOutOfRangeException("Specified color count does not match weight count");

            float rSum = 0;
            float gSum = 0;
            float bSum = 0;
            float weightSum = 0;

            for (int i = 0; i < colors.Count; i++)
            {
                CatRayColor color = colors[i];
                float weight = weights[i];

                rSum += color.Red * weight;
                gSum += color.Green * weight;
                bSum += color.Blue * weight;
                weightSum += weight;
            }

            return new(rSum / weightSum, gSum / weightSum, bSum / weightSum);
        }

        public static CatRayColor FromInt(int argb)
        {
            int r = (argb >> 16) & 0xFF;
            int g = (argb >> 8) & 0xFF;
            int b = (argb) & 0xFF;

            return new(r / 255f, g / 255f, b / 255f);
        }

        public void AddSelf(CatRayColor color)
        {
            Red = Math.Min(1, Red + color.Red);
            Green = Math.Min(1, Green + color.Green);
            Blue = Math.Min(1, Blue + color.Blue);
        }

        public CatRayColor Multiply(float brightness)
        {
            brightness = Math.Min(1, brightness);
            return new(Red * brightness, Green * brightness, Blue * brightness);
        }

        #region Constants

        public static CatRayColor BLACK = new(0f, 0f, 0f);
        public static CatRayColor WHITE = new(1f, 1f, 1f);
        public static CatRayColor RED = new(1f, 0f, 0f);
        public static CatRayColor GREEN = new(0f, 1f, 0f);
        public static CatRayColor BLUE = new(0f, 0f, 1f);
        public static CatRayColor MAGENTA = new(1.0f, 0.0f, 1.0f);
        public static CatRayColor GRAY = new(0.5f, 0.5f, 0.5f);
        public static CatRayColor DARK_GRAY = new(0.2f, 0.2f, 0.2f);

        #endregion
    }
}