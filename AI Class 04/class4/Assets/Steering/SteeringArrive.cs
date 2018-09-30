using UnityEngine;
using System.Collections;

public class SteeringArrive : MonoBehaviour {

	public float min_distance = 0.1f;
	public float slow_distance = 5.0f;
	public float time_to_target = 0.1f;

	Move move;

	// Use this for initialization
	void Start () { 
		move = GetComponent<Move>();
	}

	// Update is called once per frame
	void Update () 
	{
		Steer(move.target.transform.position);
	}

	public void Steer(Vector3 target)
	{
		if(!move)
			move = GetComponent<Move>();

        // TODO 3: Create a vector to calculate our ideal velocity
        // then calculate the acceleration needed to match that velocity
        // before sending it to move.AccelerateMovement() clamp it to 
        // move.max_mov_acceleration

        float distance_to_t = Vector3.Distance(target, transform.position);


        if (distance_to_t < slow_distance)
        {
            Vector3 ideal_v = new Vector3(0.0f, 0.0f, 0.0f);
            ideal_v = (target - transform.position) / time_to_target;
            Vector3 ideal_v_increment = ideal_v - move.movement;
            Vector3 ideal_a = Vector3.ClampMagnitude((ideal_v_increment / time_to_target),move.max_mov_acceleration);
            move.AccelerateMovement(ideal_a);
        }
        else
        {
            move.AccelerateMovement(Vector3.Normalize(target - transform.position) * move.max_mov_acceleration);
        }
    }

	void OnDrawGizmosSelected() 
	{
		// Display the explosion radius when selected
		Gizmos.color = Color.white;
		Gizmos.DrawWireSphere(transform.position, min_distance);

		Gizmos.color = Color.green;
		Gizmos.DrawWireSphere(transform.position, slow_distance);
	}
}
