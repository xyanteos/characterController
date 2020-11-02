using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strzelanie : MonoBehaviour
{
    public GameObject pref;
    public float bulletSpeed = 2f;
    public bool uwzglednijCzas = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject kula = Instantiate(pref, transform.position, Quaternion.identity);
            Rigidbody rb = kula.GetComponent<Rigidbody>();
            if (!uwzglednijCzas) {
                rb.AddForce(transform.forward * bulletSpeed);
            }
            else
            {
                rb.AddForce(transform.forward * bulletSpeed * Time.deltaTime);
            }

        }
    }
}
