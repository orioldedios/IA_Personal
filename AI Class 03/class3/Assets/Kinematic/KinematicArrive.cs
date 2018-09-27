using UnityEngine;
using System.Collections;

public class KinematicArrive : MonoBehaviour {

	public float min_distance = 0.1f;
	public float time_to_target = 0.25f;

	Move move;

	// Use this for initialization
	void Start () {
		move = GetComponent<Move>();
	}

	// Update is called once per frame
	void Update () 
	{
        // TODO 8: calculate the distance. If we are in min_distance radius, we stop moving
        // Otherwise devide the result by time_to_target (0.25 feels good)
        // Then call move.SetMovementVelocity()

        //move.target.transform.position

        Vector3 speed_vector = move.mov_velocity;

       if (Vector3.Distance(transform.position, move.target.transform.position) < min_distance)
        {
            speed_vector = Vector3.zero;
        }
        else
        {
            speed_vector *= Vector3.Distance(transform.position, move.target.transform.position) * time_to_target;
        }

        move.SetMovementVelocity(speed_vector);

    }

	void OnDrawGizmosSelected() 
	{
		// Display the explosion radius when selected
		Gizmos.color = Color.white;
		Gizmos.DrawWireSphere(transform.position, min_distance);
	}
}
