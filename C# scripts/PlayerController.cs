using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] CharacterController character;

    CharacterController characterController;
    Rigidbody rigidbody;
    bool isGrounded;
    public Transform groundCheck;
    public float groundDistance = .2f;
    public LayerMask groundMask;
    Vector3 velocity;
    [SerializeField] float speed = 5f;
    [SerializeField] float jumpHeight = 3f;
    [SerializeField] float gravity = -9.8f;

    Vector3 spawn = new Vector3(0,0,0);
    public float force = 10f;
    private void Start()
    {
        characterController = gameObject.GetComponent<CharacterController>();
        rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {


        Move();









    }



    void Move()
    {



        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float xDir = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
        float zDir = Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;

        Vector3 moveDir = xDir * transform.right + zDir * transform.forward;


        velocity.y += gravity * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }


        //Vector3 newMove = (moveDir);
        //transform.position = new Vector3(transform.position.x + newMove.x, transform.position.y + newMove.y, transform.position.z + newMove.z);

        characterController.Move(velocity * Time.deltaTime); //Jump and Dash
        characterController.Move(moveDir); //forward and sideways
                                           // Debug.Log(characterController.velocity.magnitude);
                                           //Debug.Log(FindObjectOfType<TerrainManager>().GetTerrainAtPosition(transform.position));
       

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Respawn") || other.gameObject.CompareTag("Candy"))
        {
            MoveToSpawn();
        }
        
    }

    public void UpdateSpawn(Vector3 newSpawn)
    {
        spawn = newSpawn;
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundDistance);
    }


    void MoveToSpawn()
    {
        characterController.enabled = false;
        this.transform.position = spawn;
        characterController.enabled = true;
        velocity.y = 0;

    }

    public void AddPushUp()
    {
        // characterController.Move(Vector3.up * force);
        velocity.y += force;
    }


}
