using Unity.Mathematics;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Vector3 offset;

    public Transform target;
    public float rotateSpeed = 150f;
    public float minY = -20f;
    public float maxY = 80f;

    float currentRotation;
    //float pitch ;


    void Start()
    {
        offset = transform.position - target.position;
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {

        float mouseX = Input.GetAxis("Mouse X") * rotateSpeed * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * rotateSpeed * Time.deltaTime;
        target.Rotate(Vector3.up * mouseX);

         //target.Rotate(Vector3.right * -mouseY);

        //currentRotation -= mouseY;
       // mouseY = Mathf.Clamp(mouseY, minY, maxY);

        offset = Quaternion.Euler(0, mouseX, 0) * offset; // rotate around target
        transform.position = target.position + offset;//set position
        transform.LookAt(target); //look at target
    }
}
    //private void LateUpdate()
    //{
    //    float mouseX = Input.GetAxis("Mouse X") * rotateSpeed * Time.deltaTime;
    //    float mouseY = Input.GetAxis("Mouse Y") * rotateSpeed * Time.deltaTime;

    //    // 1️⃣ Horizontal rotation (Yaw)
    //    target.Rotate(Vector3.up * mouseX);

    //    // 2️⃣ Vertical rotation (Pitch)
    //    pitch -= mouseY;
    //    pitch = Mathf.Clamp(pitch, minY, maxY);

    //    Quaternion rotation = Quaternion.Euler(pitch, 0f, 0f);

    //    // 3️⃣ Apply rotation to camera offset
    //    Vector3 rotatedOffset = rotation * offset;

    //    // 4️⃣ Set camera position
    //    transform.position = target.position + rotatedOffset;

    //    // 5️⃣ Always look at target
    //    transform.LookAt(target);
    //}

    //private void Update()
    //{
    //    Cursor.lockState = CursorLockMode.Locked;
    //    var position = target.transform.position + offset;
    //    transform.position = position;

    //    //1st
    //    var rotation = Quaternion.Euler(0, Input.GetAxis("Mouse X") * rotateSpeed * Time.deltaTime, 0);
    //    transform.rotation = rotation * transform.rotation;

    //    //transform.LookAt(target);
    //    // offset = rotation * offset; // rotate around target

    //    //2nd
    //    //var xRotation = Input.GetAxis("Mouse X");


    //    //transform.RotateAround(
    //    //      target.position,
    //    //      Vector3.up,
    //    //      xRotation * rotateSpeed * Time.deltaTime
    //    //  );
    //}

    //void Update()
    //{
    //    var position = target.transform.position + offset;
    //    transform.position = position;
    //    //Vector3 position = target.position + offset;
    //    //transform.position = position;
    //}
    //var xRotation = Input.GetAxis("Vertical");
    //transform.RotateAround(target.position, transform.right, -xRotation* rotateSpeed * Time.deltaTime);



