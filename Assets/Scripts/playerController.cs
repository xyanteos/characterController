using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float movementSpeed = 7f, gravity = -10f;
    
    CharacterController chr;
    // Start is called before the first frame update
    void Start()
    {
        chr = GetComponent<CharacterController>();   
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        chr.Move(move * movementSpeed * Time.deltaTime);
        chr.Move(new Vector3(0f,1f,0f) * gravity * Time.deltaTime);
    }
}
