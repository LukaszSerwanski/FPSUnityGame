using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour {

	public GameObject destroyed;	// Reference to the destroyed object

	// Click the object when looking at it
	void OnMouseDown ()
	{
		// Spawn destroyed object
		Instantiate(destroyed, transform.position, transform.rotation);
		// Remove remain object
		Destroy(gameObject);
	}

}
