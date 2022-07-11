using UnityEngine;

public class Rot3D : MonoBehaviour
{
    [SerializeField] private Vector3 angle = Vector3.zero;

    private float real;

    private float imaginaryX;
    private float imaginaryY;
    private float imaginaryZ;


    // Update is called once per frame
    void Update()
    {
        imaginaryZ = Mathf.Sign(Mathf.Deg2Rad * angle.z / 2.0f);
        real = Mathf.Cos(Mathf.Deg2Rad * angle.z / 2.0f);

        Quaternion rotZ = Quaternion.identity;
        rotZ.w = real;
        rotZ.z = imaginaryZ;

        imaginaryX = Mathf.Sign(Mathf.Deg2Rad * angle.x / 2.0f);
        real = Mathf.Cos(Mathf.Deg2Rad * angle.x / 2.0f);

        Quaternion rotX = Quaternion.identity;
        rotX.w = real;
        rotX.x = imaginaryX;

        imaginaryY = Mathf.Sign(Mathf.Deg2Rad * angle.y / 2.0f);
        real = Mathf.Cos(Mathf.Deg2Rad * angle.y / 2.0f);

        Quaternion rotY = Quaternion.identity;
        rotY.w = real;
        rotY.y = imaginaryY;

        transform.rotation = (rotY * rotX * rotZ);
    }
}
