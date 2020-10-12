using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uderzenie : MonoBehaviour
{
	public GameObject pref;

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.name != "Pistolet" && col.gameObject.name != "Kula") {
			Instantiate(pref, transform.position, Quaternion.identity);

			GameObject.Destroy(this.gameObject);

		}
	}

}
