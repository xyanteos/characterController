using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
	private Transform tr;
	public float predkoscObrotu = 10f;
    // Start is called before the first frame update
    void Start()
    {
		tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
		tr.Rotate(new Vector3(0,0,1f),  predkoscObrotu);
    }

    public void Picked()
    {
        Debug.Log("Podniosłem");
        Destroy(this.gameObject);
    }
}
