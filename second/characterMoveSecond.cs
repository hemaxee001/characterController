using UnityEngine;

public class characterMoveSecond : MonoBehaviour
{
    CharacterController characterController;
    public float moveSpeed;
    public float rotateSpeed;
    public Transform camFollow;
    public float runSpeed;
    public float jumpSpeed;
    public float jumpDownSpeed;
    public float jumpHieght;
    Animator animator;
    Vector3 velocity;

    //bool isRunning;

    public BulletGenerate bulletGenerate;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float vAxis = Input.GetAxis("Vertical");
        float hAxis = Input.GetAxis("Horizontal");
        if(Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = runSpeed;
            animator.SetFloat("move", vAxis *2);
        }
        else
        {
            moveSpeed = 1f;
            animator.SetFloat("move", vAxis);
        }
        
        animator.SetFloat("SideMove", hAxis);

        var move = (transform.forward * vAxis) + (transform.right * hAxis);
        characterController.Move(move * moveSpeed * Time.deltaTime);

        var cameraRotation = Quaternion.Euler(0, camFollow.eulerAngles.y, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, cameraRotation, rotateSpeed * Time.deltaTime);

        HandleJump();
        //HandleRun();
        HandleAction();
        ApplyGravity();
    }
    void HandleJump()
    {
        //if (CharacterController.isGrounded && velocity.y < 0)
        //    velocity.y = -2f;
        if (characterController.isGrounded && velocity.y < 0)
        {

            velocity.y = -2f;
        }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                print("jump");
                animator.SetBool("IsJump", true);
                velocity.y = Mathf.Sqrt(jumpHieght * -2f * Physics.gravity.y);
            }
            else if (Input.GetKeyUp(KeyCode.Space))
            {
                animator.SetBool("IsJump", false);
            }
     
        
    }
    void HandleAction()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            animator.SetBool("IsShoot", true);
            Invoke("bulletShoot", 0.2f);
        }
        if (Input.GetKeyUp(KeyCode.F))
        {
            animator.SetBool("IsShoot", false);
        }
    }
    //=====================================run====================================
    //void HandleRun()
    //{
    //    if (Input.GetKeyDown(KeyCode.Z))
    //    {
    //        moveSpeed = runSpeed;
    //        animator.SetBool("Run", true);
    //    }
    //    else if (Input.GetKeyUp(KeyCode.Z))
    //    {
    //        moveSpeed = 5f;
    //        animator.SetBool("Run", false);
    //    }
    //}

    void ApplyGravity()
    {
        velocity.y += Physics.gravity.y * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }

    void bulletShoot()
    {
        bulletGenerate.ganerateBullate();

    }





}
