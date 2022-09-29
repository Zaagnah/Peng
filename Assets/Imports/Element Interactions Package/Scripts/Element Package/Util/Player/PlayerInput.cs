
using System.Collections;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

    Vector3 nextMove;
    Vector3 targetVelocity;
    Vector3 deltaVelocity;
    Vector3 smoothMovement;
    Vector3 smoothMove;


    public Transform holdPosition;

    bool isOnGround = false;
    Vector3 playerInputDirection;
    Vector3 playerMoveDirection;
    Vector3 playerFacingDirection;
    Vector3 currentVelocity;
    Vector3 currentRotVelocity;
    Vector3 jumpTarget;

    float moveDirX;
    float moveDirZ;
    float rotTimeStamp;
    float updateTimeStampX;
    float fixedTimeStamp;
    float fixedTimeStampJump;
    float updateJumpTimeStamp;

    bool doJump = false;

    Rigidbody rb;
    public float force = 1f;
    public float jump = 2f;

    public float holdAbleDistance = 2f;
    bool holding = false;

	void Start () {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(GroundCheck());
	}
	
    IEnumerator GroundCheck()
    {
        while (this.gameObject !=null)
        {
            yield return new WaitForEndOfFrame();
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), 1))
            {
                isOnGround = true;
                //Debug.Log("on ground");
            }
            else
            {
                isOnGround = false;
            }
        }
  

    }
	void Update() {
        //playerInputDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        playerInputDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        moveDirX = playerInputDirection.x;
        moveDirZ = playerInputDirection.z;


        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))//(KeyCode.A))
        {
            SetXMove(playerInputDirection, Time.time);
            SetFacing(playerInputDirection, Time.time);

        }
        //(Input.GetKeyDown(KeyCode.Space) && isOnGround)
        if (Input.GetButtonDown("Jump") && isOnGround)
        {
            SetJump(Vector3.up * jump, Time.time);
        }
        
        if //(Input.GetButton("Fire3"));
            (Input.GetKeyDown(KeyCode.F))
        {
            CheckHoldables();
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            DoDrop();
        }
  
    }


    private void FixedUpdate()
    {

            DoFacingX(playerFacingDirection, rotTimeStamp);
            DoMoveX(playerMoveDirection, updateTimeStampX);
      
        if (doJump)
        {
            DoJump(jumpTarget, Time.time);
        }


    }

    private void CheckGround()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), 1))
        {
            isOnGround = true;
            //Debug.Log("on ground");
        }else
        {
            isOnGround = false;
        }
    }
    private void CheckHoldables()
    {
      
            RaycastHit hit;
            Vector3 left = new Vector3(.5f, 0, 0);
            Vector3 right = new Vector3(-.5f, 0, 0);

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, holdAbleDistance))
            {
                //print("Found an object - distance: " + hit.distance);
                DoPickup(hit);
                holding = true;
            }
            else if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward - left), out hit, holdAbleDistance))
            {
                //print("Found an object - distance: " + hit.distance);
                DoPickup(hit);
                holding = true;
            }
            else if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward - right), out hit, holdAbleDistance))
            {
                //print("Found an object - distance: " + hit.distance);
                DoPickup(hit);
                holding = true;
            }
      
        
        //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward - new Vector3(.5f, 0, 0)), Color.black);
    }
    private void DoPickup(RaycastHit hit)
    {
        if (hit.collider.GetComponent<HoldAble>())
        {
            hit.collider.GetComponent<HoldAble>().Hold(this.gameObject, holdPosition);

        }else
        {
            Debug.Log(hit.collider.gameObject.name + " doesn't have HOLDABLE");

        }



    }
    private void DoDrop()
    {
        if (holding)
        {
            if (this.gameObject.GetComponentInChildren<HoldAble>() !=null)
            {
                this.gameObject.GetComponentInChildren<HoldAble>().Drop();
                holding = false;
            }
         
        }
      
    }
    private void SetJump(Vector3 jumpVector, float timeStamp)
    {
        updateJumpTimeStamp = timeStamp;
        jumpTarget = jumpVector;
        doJump = true;
    }
    private void DoJump(Vector3 jumpHeight, float updateTime)
    {
        fixedTimeStampJump = Time.time;
        rb.AddForce(jumpHeight, ForceMode.Impulse);
        doJump = false;

    }
   
    private void SetFacing(Vector3 facingDir, float timeStamp)
    {

        playerFacingDirection = facingDir;
        timeStamp = rotTimeStamp;
    }
    private void DoFacingX(Vector3 facingDirection, float updateTimeRot)
    {
        if (facingDirection != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(Vector3.Lerp(playerInputDirection, facingDirection, (Time.time - updateTimeRot) / Time.time));

        }
      
            //Mathf.Clamp(transform.eulerAngles.y, -90, 90);
        
    }
    private void SetXMove(Vector3 input, float timeStamp)
    {
        playerMoveDirection = input;
        updateTimeStampX = timeStamp;
        SetNextMove(input);
    }

 
    void SetNextMove(Vector3 input)
    {
         nextMove = input - transform.position.normalized;
         targetVelocity = nextMove * force;
         deltaVelocity = targetVelocity - rb.velocity;
        if (this.rb.useGravity)
            deltaVelocity.y = 0;

        
        smoothMovement = deltaVelocity *  force;
    }
    private void DoMoveX(Vector3 moveDirection, float updateTime)
    {

       // if (moveDirection != Vector3.zero)
       // {
            float fixedTimeStamp = Time.time;
            smoothMove = Vector3.SmoothDamp(playerInputDirection, smoothMovement, ref currentVelocity, fixedTimeStamp - updateTime, force, Time.deltaTime);
            Mathf.Clamp(smoothMove.x, 0, 1);
            Mathf.Clamp(smoothMove.z, 0, 1);
            rb.AddForce (smoothMove * force, ForceMode.Impulse);
       // }

    }

    
}
