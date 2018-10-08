using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Move : MonoBehaviour {

    private Vector3[] movement_velocity = new Vector3[SteeringConfig.num_priorities];
    private float[] rotation_movement = new float[SteeringConfig.num_priorities];

    public GameObject target;
	public GameObject aim;
	public Slider arrow;
	public float max_mov_velocity = 5.0f;
	public float max_mov_acceleration = 0.1f;
	public float max_rot_velocity = 10.0f; // in degrees / second
	public float max_rot_acceleration = 0.1f; // in degrees

	[Header("-------- Read Only --------")]
	public Vector3 movement = Vector3.zero;
	public float rotation = 0.0f; // degrees

	// Methods for behaviours to set / add velocities
	public void SetMovementVelocity (Vector3 velocity, int priority = 0) 
	{
        movement_velocity[priority] = velocity;
        //movement = velocity;
    }

    public void AccelerateMovement (Vector3 velocity, int priority) 
	{
        movement_velocity[priority] += velocity;
        //movement += velocity;
	}

	public void SetRotationVelocity (float rotation_velocity, int priority = 0) 
	{
        rotation_movement[priority] = rotation_velocity;
        //rotation = rotation_velocity;
    }

	public void AccelerateRotation (float rotation_acceleration, int priority) 
	{
        rotation_movement[priority] += rotation_acceleration;
        //rotation += rotation_acceleration;
    }

	
	// Update is called once per frame
	void Update () 
	{
        for (uint i = 0; i < SteeringConfig.num_priorities; i++)
        {
            if(movement_velocity[i] != Vector3.zero)
            {
                movement += movement_velocity[i];
                break;
            }

            if (rotation_movement[i] != 0.0f)
            {
                rotation += rotation_movement[i];
                break;
            }
        }

        // cap velocity
        if (movement.magnitude > max_mov_velocity)
		{
			movement.Normalize();
			movement *= max_mov_velocity;
		}

		// cap rotation
		Mathf.Clamp(rotation, -max_rot_velocity, max_rot_velocity);

		// rotate the arrow
		float angle = Mathf.Atan2(movement.x, movement.z);
		aim.transform.rotation = Quaternion.AngleAxis(Mathf.Rad2Deg * angle, Vector3.up);

		// strech it
		arrow.value = movement.magnitude * 4;

		// final rotate
		transform.rotation *= Quaternion.AngleAxis(rotation * Time.deltaTime, Vector3.up);

		// finally move
		transform.position += movement * Time.deltaTime;



        for(uint i = 0;i<SteeringConfig.num_priorities;i++)
        {
            movement_velocity[i] = Vector3.zero;
        }


	}
}
