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

        #region Constants

        public static CatRayColor BLACK = new(0F, 0F, 0F);
        public static CatRayColor WHITE = new(1F, 1F, 1F);
        public static CatRayColor RED = new(1F, 0F, 0F);
        public static CatRayColor GREEN = new(0F, 1F, 0F);
        public static CatRayColor BLUE = new(0F, 0F, 1F);
        public static CatRayColor MAGENTA = new(1.0F, 0.0F, 1.0F);
        public static CatRayColor GRAY = new(0.5F, 0.5F, 0.5F);
        public static CatRayColor DARK_GRAY = new(0.2F, 0.2F, 0.2F);

        #endregion
    }
}