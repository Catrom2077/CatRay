namespace CatRay.Models.CatRayMath
{
    public class Line
    {
        public Line()
        {
            PointA = new Vector3().Zero;
            PointB = new Vector3().Zero;
        }

        public Line(Vector3 pointA, Vector3 pointB)
        {
            PointA = pointA ?? throw new ArgumentNullException(nameof(pointA), "is null!");
            PointB = pointB ?? throw new ArgumentNullException(nameof(pointB), "is null!");
        }

        public Vector3 PointA { get; private set; } = new Vector3().Zero;
        
        public Vector3 PointB { get; private set; } = new Vector3().Zero;

        public Ray ToRay() =>
            new(PointA, PointB.Substract(PointB).Normalize());

        public override string ToString() =>
            $"Point A: {PointA}, Point B: {PointB}";
    }
}