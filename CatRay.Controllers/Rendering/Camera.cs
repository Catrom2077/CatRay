using CatRay.Models.CatRayMath;

namespace CatRay.Controllers.Rendering
{
    public class Camera
    {
        public Camera()
        {
            Position = new Vector3().Zero;
            Yaw = 0f;
            Pitch = 0f;
            FieldOfVision = 60f;
        }

        public Vector3 Position { get; private set; }

        public float Yaw { get; private set; } = 0f;

        public float Pitch { get; private set; } = 0f;

        public float FieldOfVision { get; private set; } = 0f;

        public void SetYaw(float yaw) =>
            Yaw = yaw;

        public void SetPitch(float pitch) =>
            Pitch = pitch;

        public void SetFOV(float fieldOfVision) =>
            FieldOfVision = fieldOfVision;

        public void Translate(Vector3 direction) =>
            Position.Translate(direction);
    }
}