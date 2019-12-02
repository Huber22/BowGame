using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    //WASD movement values
    [SerializeField] private string horizontalInputName;
    [SerializeField] private string verticalInputName;

    public float walkSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float runBuildUpSpeed;
    [SerializeField] private KeyCode runKey;

    [SerializeField] private float movementSpeed;

    [SerializeField] private float slopeForce;
    [SerializeField] private float slopeForceRayLength;

    private CharacterController charController;

    //jump curve multiplier and key
    [SerializeField] private AnimationCurve jumpFallOff;
    public float jumpMultiplier;
    [SerializeField] private KeyCode jumpKey;


    private bool isJumping;
    private void Awake()
    {
        charController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        runSpeed = walkSpeed * 2;
        PlayerMovement();

    }


    //values for the speed of movement
    private void PlayerMovement()
    {
        float horizInput = Input.GetAxis(horizontalInputName);
        float vertInput = Input.GetAxis(verticalInputName);

        //movement function
        Vector3 forwardMovement = transform.forward * vertInput;
        Vector3 rightMovement = transform.right * horizInput;

        //controller movement component clamp the sideways movement
        charController.SimpleMove(Vector3.ClampMagnitude(forwardMovement + rightMovement, 1.0f) * movementSpeed);


        //checking charecter is moving on a slope apply downward force
        if ((vertInput != 0 || horizInput != 0) && OnSlope())
            charController.Move(Vector3.down * charController.height / 2 * slopeForce * Time.deltaTime);

        //call variables
        SetMovementSpeed();
        JumpInput();
    }

    //run speed and walk speed
    private void SetMovementSpeed()
    {
        if (Input.GetKey(runKey))
            movementSpeed = Mathf.Lerp(movementSpeed, runSpeed, Time.deltaTime * runBuildUpSpeed);
        else
            movementSpeed = Mathf.Lerp(movementSpeed, walkSpeed, Time.deltaTime * runBuildUpSpeed);
    }


    //test if charecter is on a slope
    private bool OnSlope()
    {
        //if jumping no need to check
        if (isJumping)
            return false;
        //store variable of surface that has been hit
        RaycastHit hit;

        //specifiy player position, direction of ray down store the hit output value length of ray
        if (Physics.Raycast(transform.position, Vector3.down, out hit, charController.height / 2 * slopeForceRayLength))
            //check normal of surface ray has hit
            if (hit.normal != Vector3.up)
                return true;
        return false;
    }

    //make sure player has pressed key
    private void JumpInput()
    {
        if (Input.GetKeyDown(jumpKey) && !isJumping)
        {
            isJumping = true;
            StartCoroutine(JumpEvent());
        }
    }

    //return any of the same IEnumerator values
    private IEnumerator JumpEvent()
    {
        //removes jitter for collision jump with wall
        charController.slopeLimit = 90.0f;
        float timeInAir = 0.0f;

        //do while loop move player up until collision with ceiling and jump is false
        do
        {
            float jumpForce = jumpFallOff.Evaluate(timeInAir);
            charController.Move(Vector3.up * jumpForce * jumpMultiplier * Time.deltaTime);
            timeInAir += Time.deltaTime;
            yield return null;
        } while (!charController.isGrounded && charController.collisionFlags != CollisionFlags.Above);

        charController.slopeLimit = 45.0f;
        isJumping = false;
    }

}