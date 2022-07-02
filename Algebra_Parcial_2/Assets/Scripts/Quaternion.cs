using UnityEngine;

namespace Williams
{
    namespace Quat 
    {
        public class Quaternion 
        {
            private float _x;
            private float _y;
            private float _z;
            private float _w;

            public Quaternion(float x, float y, float z, float w) 
            {

            }

            public static Quaternion identity //NO TERMINADO
            {
                get 
                {
                    return new Quaternion(0f, 0f, 0f, 0f); 
                } 
            }
            
            public Vector3 eulerAngles //NO TERMINADO
            {
                set 
                {

                }
                get 
                {
                    return new Vector3();
                }
            }
            
            public Quaternion normalized //NO TERMINADO
            {
                get 
                {
                    return new Quaternion(0f, 0f, 0f, 0f);
                }
            }

            public static Quaternion Euler(Vector3 euler) //NO TERMINADO 
            {
                return new Quaternion(0f, 0f, 0f, 0f);
            }

            public static Quaternion FromToRotation(Vector3 fromDirection, Vector3 toDirection) //NO TERMINADO
            {
                return new Quaternion(0f, 0f, 0f, 0f);
            }
            
            public static Quaternion Inverse(Quaternion rotation) //NO TERMINADO
            {
                return new Quaternion(0f, 0f, 0f, 0f);
            }

            public static Quaternion Lerp(Quaternion a, Quaternion b, float t) //NO TERMINADO 
            {
                return new Quaternion(0f, 0f, 0f, 0f);
            }

            public static Quaternion Normalize(Quaternion q) //NO TERMINADO
            {
                return new Quaternion(0f, 0f, 0f, 0f);
            }

            public static Quaternion Slerp(Quaternion a, Quaternion b, float t) //NO TERMINADO
            {
                return new Quaternion(0f, 0f, 0f, 0f);
            }

            public static Vector3 ToEulerAngles(Quaternion rotation) //NO TERMINADO 
            {
                return new Vector3();
            }

            public override string ToString() //NO TERMINADO
            {
                return base.ToString();
            }

            public override bool Equals(object other)
            {
                return base.Equals(other);
            }

            public override int GetHashCode()
            {
                return base.GetHashCode();
            }

            public static Vector3 operator *(Quaternion rotation, Vector3 point) //NO TERMINADO
            {
                return Vector3.zero;
            }

            public static Quaternion operator *(Quaternion lhs, Quaternion rhs) //NO TERMINADO
            {
                return new Quaternion(0f, 0f, 0f, 0f);
            }

            public static bool operator ==(Quaternion lhs, Quaternion rhs) //NO TERMINADO 
            {
                return true;
            }

            public static bool operator !=(Quaternion lhs, Quaternion rhs) //NO TERMINADO
            {
                return false;
            }
        }
    }
}