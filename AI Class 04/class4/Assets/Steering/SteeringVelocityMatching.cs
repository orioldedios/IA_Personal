using UnityEngine;
using System.Collections;

public class SteeringVelocityMatching : MonoBehaviour {

	public float time_to_target = 0.25f;

	Move move;
	Move target_move;

	// Use this for initialization
	void Start () {
		move = GetComponent<Move>();
		target_move = move.target.GetComponent<Move>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(target_move)
		{
            // TODO 5: First come up with your ideal velocity
            // then accelerate to it.
            Vector3 ideal_v = target_move.movement;

            Vector3 ideal_v_increment = ideal_v - move.movement;
            Vector3 ideal_a = Vector3.ClampMagnitude((ideal_v_increment / time_to_target), move.max_mov_acceleration);
            move.AccelerateMovement(ideal_a);
                    }
	}
}
