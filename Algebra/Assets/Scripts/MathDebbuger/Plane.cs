using UnityEngine;

namespace WilliamsMath 
{
    public class Plane
    {
        private Vec3 planeNormal;

        private float planeDistance;

        private float planeArea;

        public Vec3 Normal
        {
            set
            {
                planeNormal = value;
            }
            get
            {
                return planeNormal;
            }
        }

        public float Distance
        {
            set
            {
                planeDistance = value;
            }
            get
            {
                return planeDistance;
            }
        }

        public float Area
        {
            set
            {
                planeArea = value;
            }
            get
            {
                return planeArea;
            }
        }

        public Plane(Vec3 inNormal, Vec3 inPoint)
        {
            planeNormal = Vec3.Normalize(inNormal);

            planeDistance = -Vec3.Dot(inNormal, inPoint);

            planeArea = planeDistance;
        }

        public Plane(Vec3 inNormal, float distance)
        {
            planeNormal = Vec3.Normalize(inNormal);

            planeDistance = distance;

            planeArea = distance;
        }

        public Plane(Vec3 vecA, Vec3 vecB, Vec3 vecC)
        {
            planeNormal = Vec3.Normalize(Vec3.Cross(vecB - vecA, vecC - vecA));

            planeDistance = -Vec3.Dot(planeNormal, vecA);

            planeArea = Vec3.Cross(vecB - vecA, vecC - vecA).magnitude * .5f;
        }

        public void SetNormalAndPosition(Vec3 inNormal, Vec3 inPoint)
        {
            planeNormal = Vec3.Normalize(inNormal);

            planeDistance = -Vec3.Dot(inNormal, inPoint);
        }

        public void Set3Points(Vec3 vectA, Vec3 vecB, Vec3 vecC)
        {
            planeNormal = Vec3.Normalize(Vec3.Cross(vecB - vectA, vecC - vectA));

            planeDistance = -Vec3.Dot(planeNormal, vectA);
        }

        public void Flip()
        {
            planeNormal = -planeNormal;

            planeDistance = -planeDistance;
        }

        public void Translate(Vec3 translation)
        {
            planeDistance += Vec3.Dot(planeNormal, translation);
        }

        public static Plane Translate(Plane plane, Vec3 translation) 
        {
            return new Plane(plane.Normal, plane.Distance += Vec3.Dot(plane.Normal, translation));
        }

        public Vec3 ClosestPointOnPlane(Vec3 point)
        {
            float dot = Vec3.Dot(planeNormal, point) + planeDistance;
            
            return point - planeNormal * dot;
        }

        public float GetDistanceToPoint(Vec3 point) 
        { 
            return Vec3.Dot(planeNormal, point) + planeDistance; 
        }

        public bool GetSide(Vec3 point) 
        {
            return Vec3.Dot(planeNormal, point) + planeDistance > 0.0; 
        }

        public bool SameSide(Vec3 inPt0, Vec3 inPt1)
        {
            float distanceToPoint1 = GetDistanceToPoint(inPt0);
            float distanceToPoint2 = GetDistanceToPoint(inPt1);

            return distanceToPoint1 > 0.0 && distanceToPoint2 > 0.0 ||
                   distanceToPoint1 <= 0.0 && distanceToPoint2 <= 0.0;
        }
    }
}