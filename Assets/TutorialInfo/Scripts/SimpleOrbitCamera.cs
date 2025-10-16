using UnityEngine;

public class SimpleOrbitCamera : MonoBehaviour
{
    public Transform target; // objetivo a orbitar
    public float distance = 10.0f; // distancia inicial
    public float xSpeed = 120.0f; // velocidad de rotacion en X
    public float ySpeed = 120.0f; // velocidad de rotacion en Y
    public float yMinLimit = -20f; // limite minimo de rotacion en Y
    public float yMaxLimit = 80f; // limite maximo de rotacion en Y
    float x = 0.0f;
    float y = 0.0f;

    private void Start()
    {
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;
    }

    private void LateUpdate()
    {
        if (Input.GetMouseButton(1))
        { 
            x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
            y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;
            y = Mathf.Clamp(y, yMinLimit, yMaxLimit);
            
        }
        Quaternion rotation = Quaternion.Euler(y, x, 0);
        Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
        Vector3 position = rotation * negDistance + target.position;
        transform.rotation = rotation;
        transform.position = position;
    }

}
