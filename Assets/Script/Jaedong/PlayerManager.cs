using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerManager : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject player;

    public string buttonName;
    public float speed = 10.0f, jumpPower = 0.1f;      

    private new Rigidbody rigidbody;
    private Animator animator;

    private bool    isMovingForward = false, isMovingLeft = false,
                    isMovingBack = false, isMovingRight = false, isJump = false;

    // Start is called before the first frame update
    void Awake()
    {
        rigidbody = player.GetComponent<Rigidbody>();
        animator = player.GetComponent<Animator>();      
    }

    // Update is called once per frame
    void Update()
    {
        if (isMovingForward) MoveForward();
        else if (isMovingLeft) MoveLeft();
        else if (isMovingBack) MoveBack();
        else if (isMovingRight) MoveRight();       
    }

    private void MoveForward()
    {
        float v = 1;
        Vector3 vector = new Vector3(0, 0, v).normalized;

        player.transform.position += speed * Time.deltaTime * vector;
        player.transform.LookAt(player.transform.position + vector);
    }

    private void MoveLeft()
    {
        float h = -1;
        Vector3 vector = new Vector3(h, 0, 0).normalized;

        player.transform.position += speed * Time.deltaTime * vector;
        player.transform.LookAt(player.transform.position + vector);
    }

    private void MoveBack()
    {
        float v = -1;
        Vector3 vector = new Vector3(0, 0, v).normalized;

        player.transform.position += speed * Time.deltaTime * vector;
        player.transform.LookAt(player.transform.position + vector);
    }

    private void MoveRight()
    {
        float h = 1;
        Vector3 vector = new Vector3(h, 0, 0).normalized;

        player.transform.position += speed * Time.deltaTime * vector;
        player.transform.LookAt(player.transform.position + vector);
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

    public void OnPointerDown(PointerEventData eventData)
    {
        if(buttonName != "Jump Button") animator.SetBool("isRun", true);

        switch (buttonName)
        {
            case "W Button":
                isMovingForward = true;
                break;
            case "A Button":
                isMovingLeft = true;
                break;
            case "S Button":
                isMovingBack = true;
                break;
            case "D Button":
                isMovingRight = true;
                break;
            case "Jump Button":                
                if (!isJump) Jump();
                break;
            default:
                break;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        animator.SetBool("isRun", false);

        isMovingForward = false;
        isMovingLeft = false;
        isMovingBack = false;
        isMovingRight = false;       
    }
}