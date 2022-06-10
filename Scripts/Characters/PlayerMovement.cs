using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController chController;

    public float playerSpeed;
    public float jumpForce = 2;
    public float gravity = -9.81f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public PlayerFootSteps playerFS;

    private bool isCrouching;
    private Vector3 originalCenter;
    private Vector3 lastPos;
    private float originalHeight;
    private float originalMoveSpeed;

    Vector3 velocity;
    bool isGrounded;
    bool canPlaySound = true;

    void Start()
    {
        chController = GetComponent<CharacterController>();
        playerFS = GetComponent<PlayerFootSteps>();
        originalCenter = chController.center;
        originalHeight = chController.height;
        originalMoveSpeed = playerSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        PlayerJump();
        PlayerGravity();
        PlayerCrouch();
    }

    private void PlayerMove()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (canPlaySound && CheckIfIsMoving())
            StartCoroutine(PlayFootSteps());

        Vector3 move = transform.right * x + transform.forward * z;

        chController.Move(move * playerSpeed * Time.deltaTime);
    }

    private void PlayerGravity()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;
        chController.Move(velocity * Time.deltaTime);
    }

    void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpForce * gravity * -2);
        }
    }

    void PlayerCrouch()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            chController.height /= 2f;
            chController.center = new Vector3(0f, -0.5f, 0f);
            playerSpeed /= 2f;
            isCrouching = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftControl) && isCrouching)
        {
            //Vector3 point0 = transform.position + originalCenter - new Vector3(0.0f, originalHeight, 0.0f);
            //Vector3 point1 = transform.position + originalCenter + new Vector3(0.0f, originalHeight, 0.0f);
            //if (Physics.OverlapCapsule(point0, point1, chController.radius).Length == 0)
            //{
            chController.height = originalHeight;
            chController.center = originalCenter;
            playerSpeed = originalMoveSpeed;
            isCrouching = false;
            //}
        }
    }

    bool CheckIfIsMoving()
    {
        if (lastPos != this.transform.position)
        {
            lastPos = this.transform.position;
            return true;
        }
        else
        {
            lastPos = this.transform.position;
            return false;
        }
    }

    IEnumerator PlayFootSteps()
    {
        playerFS.PlayerStep();
        canPlaySound = false;
        yield return new WaitForSeconds(1f);
        canPlaySound = true;
    }
}
