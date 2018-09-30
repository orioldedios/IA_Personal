using UnityEngine;
using System.Collections;

public class SteeringAlign : MonoBehaviour {

	public float min_angle = 0.01f;
	public float slow_angle = 0.1f;
	public float time_to_target = 0.1f;

	Move move;

	// Use this for initialization
	void Start () {
		move = GetComponent<Move>();
	}

	// Update is called once per frame
	void Update () 
	{
        // TODO 4: As with arrive, we first construct our ideal rotation
        // then accelerate to it. Use Mathf.DeltaAngle() to wrap around PI
        // Is the same as arrive but with angular velocities

        float angle_between = Vector3.Angle(move.movement, move.target.transform.position);

        angle_between = Mathf.DeltaAngle(angle_between, angle_between + 180);

        if (angle_between < slow_angle)
        {
            //Vector3 ideal_w = new Vector3(0.0f, 0.0f, 0.0f);
            float ideal_w = angle_between / time_to_target;
            float ideal_a = (ideal_w - move.rotation) / time_to_target;
            move.AccelerateRotation(Mathf.Clamp(ideal_a,0.0f,move.max_rot_acceleration));
        }
        else if(angle_between <= min_angle)
        {
            move.SetRotationVelocity(0.0f);
        }

    }
}
