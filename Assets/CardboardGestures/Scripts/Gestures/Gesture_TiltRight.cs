using UnityEngine;

namespace CardboardGestures.Gestures
{
    public class Gesture_TiltRight : AbstractGesture
    {
        public DeviceOrientation orientation;

        private Vector3 initialVector;

        float range = 0.7f;

        public override string GestureName()
        {
            return "Tilt Right";
        }

        public override bool Analyze()
        {
            if ((orientation == DeviceOrientation.LandscapeLeft
               && initialVector.x + range < Input.acceleration.x)
               ||
               (orientation == DeviceOrientation.LandscapeRight
               && initialVector.x - range < Input.acceleration.x)
               )
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