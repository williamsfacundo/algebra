using UnityEngine;

namespace Williams 
{
    namespace Matrix 
    {
        public class Matrix
        {
            private const short maxMatrixValues = 16;
            private const short maxRows = 4;
            private const short maxColumns = 4;

            private float[] _matrixValuesAsArray1D = new float[maxMatrixValues];

            private float[,] _matrixValuesAsArray2D = new float[maxRows, maxColumns];

            //Row 1
            private float _m00;
            private float _m01;
            private float _m02;
            private float _m03;
            //Row 2
            private float _m10;
            private float _m11;
            private float _m12;
            private float _m13;
            //Row 3
            private float _m20;
            private float _m21;
            private float _m22;
            private float _m23;
            //Row 4
            private float _m30;
            private float _m31;
            private float _m32;
            private float _m33;

            public Matrix(Vector4 row0, Vector4 row1, Vector4 row2, Vector4 row3)
            {
                _m00 = row0.x;
                _m01 = row0.y;
                _m02 = row0.z;
                _m03 = row0.w;

                _m10 = row1.x;
                _m11 = row1.y;
                _m12 = row1.z;
                _m13 = row1.w;

                _m20 = row2.x;
                _m21 = row2.y;
                _m22 = row2.z;
                _m23 = row2.w;

                _m30 = row3.x;
                _m31 = row3.y;
                _m32 = row3.z;
                _m33 = row3.w;

                SetMatrixArray1D();

                SetMatrixArray2D();
            }

            public float this[int index] //From 0 - 15
            {
                set
                {
                    _matrixValuesAsArray1D[index] = value;
                }
                get
                {
                    return _matrixValuesAsArray1D[index];
                }
            }

            public float this[int row, int column] //Row from 0 - 3 && Column from 0 - 3
            {
                set
                {
                    _matrixValuesAsArray2D[row, column] = value;
                }
                get
                {
                    return _matrixValuesAsArray2D[row, column];
                }
            }

            public static Matrix Zero
            {
                get
                {
                    return new Matrix(Vector4.zero, Vector4.zero, Vector4.zero, Vector4.zero);
                }
            }

            public static Matrix Identity
            {
                get
                {
                    return new Matrix(new Vector4(1, 0, 0, 0), new Vector4(0, 1, 0, 0), new Vector4(0, 0, 1, 0), new Vector4(0, 0, 0, 1));
                }
            }

            public Matrix transpose
            {
                get
                {
                    return Transpose(this);
                }
            }

            public Quaternion rotation //NO TERMINADO
            {
                get
                {
                    return Quaternion.identity;
                }
            }

            public Vector3 lossyScale //NO TERMINADO
            {
                get
                {
                    return Vector3.zero;
                }
            }

            public static Matrix Rotate(Quaternion quaternion) //NO TERMINADO
            {
                return Matrix.Zero;                
            }

            public static Matrix Scale(Vector3 vector)
            {
                Matrix scaleMatrix = Matrix.Identity;

                scaleMatrix[0, 0] = vector.x;
                scaleMatrix[1, 1] = vector.y;
                scaleMatrix[2, 2] = vector.z;

                return scaleMatrix;
            }

            public static Matrix Translate(Vector3 vector)
            {
                Matrix translationMatrix = Matrix.Identity;

                translationMatrix[0, 3] = vector.x;
                translationMatrix[1, 3] = vector.y;
                translationMatrix[2, 3] = vector.z;

                return translationMatrix;
            }

            public static Matrix Transpose(Matrix matrix)
            {                
                return new Matrix(new Vector4(matrix[0, 0], matrix[1, 0], matrix[2, 0], matrix[3, 0]), 
                    new Vector4(matrix[0, 1], matrix[1, 1], matrix[2, 1], matrix[3, 1]), 
                    new Vector4(matrix[0, 2], matrix[1, 2], matrix[2, 2], matrix[3, 2]), 
                    new Vector4(matrix[0, 3], matrix[1, 3], matrix[2, 3], matrix[3, 3]));
            }

            private void SetMatrixArray1D()
            {
                _matrixValuesAsArray1D[0] = _m00;
                _matrixValuesAsArray1D[1] = _m01;
                _matrixValuesAsArray1D[2] = _m02;
                _matrixValuesAsArray1D[3] = _m03;

                _matrixValuesAsArray1D[4] = _m10;
                _matrixValuesAsArray1D[5] = _m11;
                _matrixValuesAsArray1D[6] = _m12;
                _matrixValuesAsArray1D[7] = _m13;

                _matrixValuesAsArray1D[8] = _m20;
                _matrixValuesAsArray1D[9] = _m21;
                _matrixValuesAsArray1D[10] = _m22;
                _matrixValuesAsArray1D[11] = _m23;

                _matrixValuesAsArray1D[12] = _m30;
                _matrixValuesAsArray1D[13] = _m31;
                _matrixValuesAsArray1D[14] = _m32;
                _matrixValuesAsArray1D[15] = _m33;

            }

            private void SetMatrixArray2D()
            {
                _matrixValuesAsArray2D[0, 0] = _m00;
                _matrixValuesAsArray2D[0, 1] = _m01;
                _matrixValuesAsArray2D[0, 2] = _m02;
                _matrixValuesAsArray2D[0, 3] = _m03;

                _matrixValuesAsArray2D[1, 0] = _m10;
                _matrixValuesAsArray2D[1, 1] = _m11;
                _matrixValuesAsArray2D[1, 2] = _m12;
                _matrixValuesAsArray2D[1, 3] = _m13;

                _matrixValuesAsArray2D[2, 0] = _m20;
                _matrixValuesAsArray2D[2, 1] = _m21;
                _matrixValuesAsArray2D[2, 2] = _m22;
                _matrixValuesAsArray2D[2, 3] = _m23;

                _matrixValuesAsArray2D[3, 0] = _m30;
                _matrixValuesAsArray2D[3, 1] = _m31;
                _matrixValuesAsArray2D[3, 2] = _m32;
                _matrixValuesAsArray2D[3, 3] = _m33;
            }

            public static Vector4 operator *(Matrix matrix, Vector4 vector)
            {
                Vector4 result = new Vector4();

                result.x = matrix[0, 0] * vector.x + matrix[0, 1] * vector.y + matrix[0, 2] * vector.z + matrix[0, 3] * vector.w;
                result.y = matrix[1, 0] * vector.x + matrix[1, 1] * vector.y + matrix[1, 2] * vector.z + matrix[1, 3] * vector.w;
                result.z = matrix[2, 0] * vector.x + matrix[2, 1] * vector.y + matrix[2, 2] * vector.z + matrix[2, 3] * vector.w;
                result.w = matrix[3, 0] * vector.x + matrix[3, 1] * vector.y + matrix[3, 2] * vector.z + matrix[3, 3] * vector.w;

                return result;
            }

            public static Matrix operator *(Matrix m1, Matrix m2)
            {
                Matrix result = Matrix.Zero;

                result[0, 0] = m1[0, 0] * m2[0, 0] + m1[0, 1] * m2[1, 0] + m1[0, 2] * m2[2, 0] + m1[0, 3] * m2[3, 0];
                result[0, 1] = m1[0, 0] * m2[0, 1] + m1[0, 1] * m2[1, 1] + m1[0, 2] * m2[2, 1] + m1[0, 3] * m2[3, 1];
                result[0, 2] = m1[0, 0] * m2[0, 2] + m1[0, 1] * m2[1, 2] + m1[0, 2] * m2[2, 2] + m1[0, 3] * m2[3, 2];
                result[0, 3] = m1[0, 0] * m2[0, 3] + m1[0, 1] * m2[1, 3] + m1[0, 2] * m2[2, 3] + m1[0, 3] * m2[3, 3];

                result[1, 0] = m1[1, 0] * m2[0, 0] + m1[1, 1] * m2[1, 0] + m1[1, 2] * m2[2, 0] + m1[1, 3] * m2[3, 0];
                result[1, 1] = m1[1, 0] * m2[0, 1] + m1[1, 1] * m2[1, 1] + m1[1, 2] * m2[2, 1] + m1[1, 3] * m2[3, 1];
                result[1, 2] = m1[1, 0] * m2[0, 2] + m1[1, 1] * m2[1, 2] + m1[1, 2] * m2[2, 2] + m1[1, 3] * m2[3, 2];
                result[1, 3] = m1[1, 0] * m2[0, 3] + m1[1, 1] * m2[1, 3] + m1[1, 2] * m2[2, 3] + m1[1, 3] * m2[3, 3];

                result[2, 0] = m1[2, 0] * m2[0, 0] + m1[2, 1] * m2[1, 0] + m1[2, 2] * m2[2, 0] + m1[2, 3] * m2[3, 0];
                result[2, 1] = m1[2, 0] * m2[0, 1] + m1[2, 1] * m2[1, 1] + m1[2, 2] * m2[2, 1] + m1[2, 3] * m2[3, 1];
                result[2, 2] = m1[2, 0] * m2[0, 2] + m1[2, 1] * m2[1, 2] + m1[2, 2] * m2[2, 2] + m1[2, 3] * m2[3, 2];
                result[2, 3] = m1[2, 0] * m2[0, 3] + m1[2, 1] * m2[1, 3] + m1[2, 2] * m2[2, 3] + m1[2, 3] * m2[3, 3];

                result[3, 0] = m1[3, 0] * m2[0, 0] + m1[3, 1] * m2[1, 0] + m1[3, 2] * m2[2, 0] + m1[3, 3] * m2[3, 0];
                result[3, 1] = m1[3, 0] * m2[0, 1] + m1[3, 1] * m2[1, 1] + m1[3, 2] * m2[2, 1] + m1[3, 3] * m2[3, 1];
                result[3, 2] = m1[3, 0] * m2[0, 2] + m1[3, 1] * m2[1, 2] + m1[3, 2] * m2[2, 2] + m1[3, 3] * m2[3, 2];
                result[3, 3] = m1[3, 0] * m2[0, 3] + m1[3, 1] * m2[1, 3] + m1[3, 2] * m2[2, 3] + m1[3, 3] * m2[3, 3];
                                
                return result;
            }

            public static Matrix TRS(Vector3 pos, Quaternion q, Vector3 s) //NO TERMINADO 
            {
                return Matrix.Zero;
            }

            public override bool Equals(object obj)
            {
                return base.Equals(obj);
            }

            public override int GetHashCode()
            {
                return base.GetHashCode();
            }

            public override string ToString() //NO TERMINADO
            {
                return base.ToString();
            }

            public static bool operator ==(Matrix m1, Matrix m2) //NO TERMINADO 
            {
                return true;
            }
            
            public static bool operator !=(Matrix m1, Matrix m2) //NO TERMINADO
            {
                return true;
            }
        }
    }
}
