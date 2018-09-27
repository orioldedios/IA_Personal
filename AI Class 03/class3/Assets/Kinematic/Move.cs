using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Move : MonoBehaviour {

	public GameObject target;
	public GameObject aim;
	public Slider arrow;
	public float max_mov_velocity = 5.0f;

	public Vector3 mov_velocity = Vector3.zero;

	// Use this for initialization
	public void SetMovementVelocity (Vector3 vel) {
		mov_velocity = vel;
	}

	// Update is called once per frame
	void Update () 
	{
		// TODO 1: Make sure mov_velocity is never bigger that max_mov_velocity

		// TODO 2: rotate the arrow to point to mov_velocity direction. First find out the angle
		// then create a Quaternion with that expressed that rotation and apply it to aim.transform

		// TODO 3: stretch it the arrow (arrow.value) to show how fast the tank is getting push in
		// that direction. Adjust with some factor so the arrow is visible.

		// TODO 4: update tank position based on final mov_velocity and deltatime

		// Reset movement to 0 to simplify things ...
		mov_velocity = Vector3.zero;
	}
}
