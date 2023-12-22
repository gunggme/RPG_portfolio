using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float _runSpeed;
    [SerializeField] private float _walkSpeed;

    [Header("IsRun?")]
    [SerializeField] private bool isRun;

    [Header("Check Equip")] public bool isEquipSword;
    

    [SerializeField]
    private float rotationSpeed;

    [SerializeField]
    private Transform cameraTransform;

    private Animator animator;
    private CharacterController characterController;
    private float ySpeed;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isEquipSword)
        {
            animator.SetTrigger("Attack");
        }

        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Attack1") && !animator.GetCurrentAnimatorStateInfo(0).IsName("Attack2"))
        {
            Move();
        }

        // if (characterController.isGrounded)
        // {
        //     lastGroundedTime = Time.time;
        // }

        // if (Input.GetButtonDown("Jump"))
        // {
        //     jumpButtonPressedTime = Time.time;
        // }
        //
        // if (Time.time - lastGroundedTime <= jumpButtonGracePeriod)
        // {
        //     characterController.stepOffset = originalStepOffset;
        //     ySpeed = -0.5f;
        //
        //     if (Time.time - jumpButtonPressedTime <= jumpButtonGracePeriod)
        //     {
        //         ySpeed = jumpSpeed;
        //         jumpButtonPressedTime = null;
        //         lastGroundedTime = null;
        //     }
        // }
        // else
        // {
        //     characterController.stepOffset = 0;
        // }

             
    }

    void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        float inputMagnitude = Mathf.Clamp01(movementDirection.magnitude);
        
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            inputMagnitude /= 2;
        }
        
        movementDirection = Quaternion.AngleAxis(cameraTransform.rotation.eulerAngles.y, Vector3.up) * movementDirection;
        movementDirection.Normalize();

        ySpeed += Physics.gravity.y * Time.deltaTime;

        isRun = Input.GetKey(KeyCode.LeftShift);
        animator.SetBool("Move", movementDirection != Vector3.zero);
        animator.SetBool("Run", isRun);
        RunCheck(isRun);
        
        Vector3 velocity = movementDirection * speed;
        velocity.y = ySpeed;

        characterController.Move(velocity * Time.deltaTime);

        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }   
    }

    void RunCheck(bool running)
    {
        speed = running ? _runSpeed : _walkSpeed;
    }

    private void OnApplicationFocus(bool focus)
    {
        if (focus)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

  
}
