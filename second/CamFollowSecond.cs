using UnityEngine;

public class CamFollowSecond : MonoBehaviour
{
    Vector3 offset;

    public Transform target;
    public float rotateSpeed;
    float currentX = 0f;



    void Start()
    {
        offset = transform.position - target.position;
        
    }
    private void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;
        float mouseX = Input.GetAxis("Mouse X") * rotateSpeed * Time.deltaTime;
        offset = Quaternion.Euler(0, mouseX, 0) * offset;
        
        transform.position = target.position + offset;
       // transform.LookAt(target);
        // transform.Rotate(Vector3.up * mouseX);
        transform.RotateAround(target.position, Vector3.up, mouseX);

        currentX -= Input.GetAxis("Mouse Y") * rotateSpeed * Time.deltaTime;
        currentX = Mathf.Clamp(currentX, -20, 50);
        transform.localRotation = Quaternion.Euler(currentX, transform.localRotation.eulerAngles.y, 0);
    }
}
