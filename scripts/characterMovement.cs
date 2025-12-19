using System.Collections;
using Unity.Android.Gradle.Manifest;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class characterMovement : MonoBehaviour
{
    CharacterController CharacterController;
    public Transform cameraTransform;
    Animator animator;
    Vector3 velocity;

    public float moveSpeed;
    public float runSpeed;

    public float rotateSpeed;
  
    public float jumpSpeed;
    public float jumpDownSpeed;
    public float jumpHieght;

    bool isRunning ;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CharacterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        HandleRun();
        HandleMovement();
        HandleJump();
        HandleAction();
        ApplyGravity();
    }

    //=======================================movement=========================================
    void  HandleMovement()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 camForward = cameraTransform.forward;
        Vector3 camRight = cameraTransform.right;

        camForward.y = 0;
        camRight.y = 0;

        camForward.Normalize(); // speed also same 
        camRight.Normalize();

        //Vector3 moveDirection = camForward * v + camRight * h; // forward/backward

        Vector3 move = camForward * v + camRight * h; // left/right

        transform.position += move * moveSpeed * Time.deltaTime; 

        print("++++" + move); // 0.46,0.00,0.89
        CharacterController.Move(move * moveSpeed * Time.deltaTime); // move the character smoothly

        if (move.magnitude > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(move);
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                targetRotation,
                rotateSpeed * Time.deltaTime
            );
        }

        animator.SetFloat("move", move.magnitude); //magnitude means length (strength) of a Vector.
        //print(move.magnitude);
    }
    //====================================jump=========================================
    void HandleJump()
    {
        //if (CharacterController.isGrounded && velocity.y < 0)
        //    velocity.y = -2f;
        if(CharacterController.isGrounded)
        {
            if (velocity.y < 0)
                velocity.y = -2f;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                animator.SetBool("IsJump", true);
                velocity.y = Mathf.Sqrt(jumpHieght * -2f * Physics.gravity.y);
            }
            else
            {
                animator.SetBool("IsJump", false);
            }
        }
    }

    //====================================action=========================================
    void HandleAction()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            animator.SetBool("IsShoot", true);
        }
        if (Input.GetKeyUp(KeyCode.F))
        {
            animator.SetBool("IsShoot", false);
        }
    }
    //=====================================run====================================
    void HandleRun()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            isRunning = true;
            moveSpeed = runSpeed;
            animator.SetBool("Run", true);
        }
        else if (Input.GetKeyUp(KeyCode.Z))
        {
            isRunning = false;
            moveSpeed = 5f;
            animator.SetBool("Run", false);
        }
    }
    //====================================gravity=========================================
    void ApplyGravity()
    {
        velocity.y += Physics.gravity.y * Time.deltaTime;
        CharacterController.Move(velocity * Time.deltaTime);
    }
}
