using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 12f, jumpForce = 5f; //szybkość naszej postaci
    public float gravity = -10; //przyspieszenie ziemskie 
    Vector3 velocity; //wyliczona prędkość w każdym kierunku
    CharacterController characterController; //komponent Character Controller

    public Transform groundCheck; //miejsce na nasz obiekt
    public LayerMask groundMask; //grupa obiektów, które będą warstwą uznawaną za teren
    bool isGrounded; //sprawdzamy czy jesteśmy na ziemi
    
    

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        
    }


    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.4f, groundMask);

        RaycastHit hit; //zmienna w której zapisywana jest referencja do uderzonego obiektu
        if (Physics.Raycast(groundCheck.position, transform.TransformDirection(Vector3.down), out hit, 0.4f, groundMask))
        {
            string terrainType;
            terrainType = hit.collider.gameObject.tag; // sprawdzamy tag tego w co uderzyliśmy
            switch (terrainType)
            {
                default:    //standardowa prędkość gdy chodzimy po dowolnym terenie
                    speed = 12;
                    break;
                case "Low": //prędkość gdy chodzimy po terenie spowalniającym
                    speed = 3;
                    break;
                case "High": //prędkość gdy chodzimy po terenie przyspieszającym
                    speed = 20;
                    break;

            }
        }
		if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
		{
			velocity.y = jumpForce;
		}

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        characterController.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        characterController.Move(velocity * Time.deltaTime);

    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.tag == "PickUp")
        {
            hit.gameObject.GetComponent<PickUp>().Picked();
        }
    }

}
