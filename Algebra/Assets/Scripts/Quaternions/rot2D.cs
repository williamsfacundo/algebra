using UnityEngine;

public class rot2D : MonoBehaviour
{
    Vector3 rot = Vector3.zero;
    float angle = 2.0f;    

    private void Update()
    {
        rot = new Vector3(Mathf.Cos(Mathf.Deg2Rad * angle), Mathf.Sin(Mathf.Deg2Rad * angle), 0.0f);
        
        //Rotar en el otro sentido
        //rot = new Vector3(Mathf.Cos(Mathf.Deg2Rad * angle), -Mathf.Sin(Mathf.Deg2Rad * angle), 0.0f);

        if (Input.GetKey(KeyCode.RightArrow)) 
        {
            transform.position = new Vector3(transform.position.x * rot.x - transform.position.y * rot.y,
                transform.position.y * rot.x + transform.position.x * rot.y, 0.0f);
        }        
    }
}
