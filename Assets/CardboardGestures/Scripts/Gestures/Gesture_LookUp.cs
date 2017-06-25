using UnityEngine;

namespace CardboardGestures.Gestures
{
    public class Gesture_LookUp : AbstractGesture
    {
        public DeviceOrientation orientation;

        private Vector3 initialVector;

        float range = 0.7f;

        public override string GestureName()
        {
            return "Look Up";
        }

        public override bool Analyze()
        {
            if ((orientation == DeviceOrientation.LandscapeLeft || orientation == DeviceOrientation.LandscapeRight)
               && initialVector.z + range <= Input.acceleration.z)
            {
                return true;
            }
            return false;
        }

        void Start()
        {
            initialVector = new Vector3(0.0f, -1.0f, 0.0f);
        }

    }
}