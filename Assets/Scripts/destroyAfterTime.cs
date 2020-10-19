using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyAfterTime : MonoBehaviour
{
	public float TimeToDistroy = 2f, iterator;

	void Start()
	{
		iterator = 50 * TimeToDistroy;
	}

    // Update is called once per frame
    void FixedUpdate()
    {
		iterator--;
		if (iterator == 0)
		{
			GameObject.Destroy(this.gameObject);
		}
    }
}
