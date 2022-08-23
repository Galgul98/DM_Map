using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    public float speed = 7f;
    public float sprintSpeed;
    public float crouchSpeed;
    private bool isGrounded;
    public float gravity = -9.8f;
    public float jumpHeight = 2f;
    private bool lerpCrouch;
    public bool crouching;
    public bool sprinting;
    public bool isWalking = false;
    public bool isIdle = false;
    public Animator camAnim;
    public PlayerInput playerInput;
    public PlayerInput.OnFootActions onFoot;
    public float crouchTimer;
    void Start()
    {
        playerInput = new PlayerInput();
        playerInput.Enable();
        playerInput.OnFoot.Enable();
        onFoot = playerInput.OnFoot;

        controller = GetComponent<CharacterController>();
        camAnim.SetTrigger("Idle");
    }

    void Update()
    {
        isGrounded = controller.isGrounded;
        if (lerpCrouch)
        {
            crouchTimer += Time.deltaTime;
            float p = crouchTimer / 1;
            p *= p;
            if (crouching)
            {
                controller.height = Mathf.Lerp(controller.height, 1, p);
                speed = crouchSpeed;
            }
            else
            {
                controller.height = Mathf.Lerp(controller.height, 2, p);
                speed = 7f;
            }
               

            if (p > 1)
            {
                lerpCrouch = false;
                crouchTimer = 0f;
            }
        }
    }

    public void ProcessMove(Vector3 input)
    {

        Vector3 Direction = Vector3.zero;
        Vector3 moveDirection = Vector3.zero;
            moveDirection.x = input.x;
            moveDirection.z = input.y;
            controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
            playerVelocity.y += gravity * Time.deltaTime;
        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;



            




        }
        if(input.x == 0 && input.z == 0 && input.y == 0)
        {
            Debug.Log("Check12");
            camAnim.SetTrigger("Idle");
            camAnim.ResetTrigger("Walk");
            camAnim.ResetTrigger("Run");
            isIdle = true;
        }
        else
        {
            camAnim.SetTrigger("Walk");
            camAnim.ResetTrigger("Idle");
            camAnim.ResetTrigger("Run");
        }
        if (sprinting)
        {
            camAnim.SetTrigger("Run");
            camAnim.ResetTrigger("Walk");
            camAnim.ResetTrigger("Idle");
            isWalking = false;
            isIdle = false;
        }
    

        controller.Move(playerVelocity * Time.deltaTime);
       
      
        
        //Debug.Log(playerVelocity);
    }

    public void Jump()
    {
        if (isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3f * gravity);
        }
    }

    public void Crouch()
    {
        crouching = !crouching;
        crouchTimer = 0f;
        lerpCrouch = true;
    }

    public void StartSprinting()
    {
        sprinting = true;
        speed = sprintSpeed;
       camAnim.SetTrigger("Run");
    }

    public void StopSprinting()
    {
        sprinting = false;
        speed = 7f;
       // camAnim.SetTrigger("Walk");
    }


}
