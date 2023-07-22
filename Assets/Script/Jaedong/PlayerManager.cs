using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerManager : MonoBehaviour
{
    public float speed = 2.0f, jumpPower = 13.0f;

    private Vector3 moveVec;
    private float hAxis, vAxis;

    private new Rigidbody rigidbody;
    private Animator animator;

    private bool isRunDown, isJumpDown, isJump = false;

    // Start is called before the first frame update
    void Awake()
    {        
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();      
    }

    // Update is called once per frame
    void Update()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");
        isRunDown = Input.GetButton("Run");
        isJumpDown = Input.GetButtonDown("Jump");
        
        moveVec = new Vector3(hAxis, 0, vAxis).normalized;

        if (isRunDown) transform.position += moveVec * speed * Time.deltaTime * 2;
        else transform.position += moveVec * speed * Time.deltaTime;

        transform.LookAt(transform.position + moveVec);

        animator.SetBool("isWalk", moveVec != Vector3.zero);
        animator.SetBool("isRun", isRunDown || isJump);

        if (isJumpDown && !isJump) Jump();
    }

    private void Jump()
    {       
        isJump = true;
        rigidbody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);        
    }

    private void OnCollisionEnter(Collision collision)
    {        
        if (collision.collider.gameObject.CompareTag("Floor")) isJump = false;                
    }
}