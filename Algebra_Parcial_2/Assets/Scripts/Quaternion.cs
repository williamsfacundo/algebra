using UnityEngine;

namespace Williams
{
    namespace Quat 
    {
        public struct Quaternion 
        {
            public float _x;
            public float _y;
            public float _z;
            public float _w;

            public Quaternion(float x, float y, float z, float w) 
            {
                _x = x;
                _y = y;
                _z = z;
                _w = w;
            }

            public static Quaternion identity
            {
                get 
                {
                    return new Quaternion(0f, 0f, 0f, 1f); 
                } 
            }       

            public static Quaternion Euler(Vector3 euler) 
            {
                float cz = Mathf.Cos(Mathf.Deg2Rad * euler.z / 2);
                float sz = Mathf.Sin(Mathf.Deg2Rad * euler.z / 2);
                float cy = Mathf.Cos(Mathf.Deg2Rad * euler.y / 2);
                float sy = Mathf.Sin(Mathf.Deg2Rad * euler.y / 2);
                float cx = Mathf.Cos(Mathf.Deg2Rad * euler.x / 2);
                float sx = Mathf.Sin(Mathf.Deg2Rad * euler.x / 2);

                Quaternion q = Quaternion.identity;

                q._w = cx * cy * cz + sx * sy * sz;   
                q._x = sx * cy * cz - cx * sy * sz;   
                q._y = cx * sy * cz + sx * cy * sz;   
                q._z = cx * cy * sz - sx * sy * cz;   

                return q;
            }

            private static Vector3 ToEulerAngles(Quaternion q)
            {
                Vector3 angles;

                float sinr_cosp = 2 * (q._w * q._x + q._y * q._z);
                float cosr_cosp = 1 - 2 * (q._x * q._x + q._y * q._y);
                angles.x = Mathf.Atan2(sinr_cosp, cosr_cosp);
                
                float sinp = 2 * (q._w * q._y - q._z * q._x);
                if (Mathf.Abs(sinp) >= 1)
                    angles.y = (Mathf.PI / 2) * Mathf.Sign(sinp);
                else
                    angles.y = Mathf.Asin(sinp);
                                
                float siny_cosp = 2 * (q._w * q._z + q._x * q._y);
                float cosy_cosp = 1 - 2 * (q._y * q._y + q._z * q._z);
                angles.z = Mathf.Atan2(siny_cosp, cosy_cosp);

                return angles;
            }

            public static Quaternion Inverse(Quaternion q) 
            {
                return new Quaternion(-q._x, -q._y, -q._z, q._w);
            }                                                

            public override string ToString()
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

            public static Quaternion operator *(Quaternion q1, Quaternion q2)
            {
                float w = q1._w * q2._w - q1._x * q2._x - q1._y * q1._y - q1._z * q2._z;
                float x = q1._w * q2._x + q1._x * q2._w - q1._y * q2._z - q1._z * q2._y;
                float y = q1._w * q2._y - q1._x * q2._z + q1._y * q2._w + q1._z * q2._x;
                float z = q1._w * q2._z + q1._x * q2._y - q1._y * q2._x + q1._z * q2._w;

                return new Quaternion(x, y, z, w);
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