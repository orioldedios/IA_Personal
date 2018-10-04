using UnityEngine;
using System.Collections;

[System.Serializable]
public class MyRay
{
    public float length = 0.0f;
    public Vector3 direction = Vector3.zero;
}

public class SteeringObstacleAvoidance : MonoBehaviour {

	public LayerMask mask;
	public float avoid_distance = 5.0f;
    public MyRay[] rays;

	Move move;
	SteeringSeek seek;

	// Use this for initialization
	void Start () {
		move = GetComponent<Move>(); 
		seek = GetComponent<SteeringSeek>();
	}
	
	// Update is called once per frame
	void Update () 
	{
        // TODO 2: Agents must avoid any collider in their way
        // 1- Create your own (serializable) class for rays and make a public array with it
        // 2- Calculate a quaternion with rotation based on movement vector
        // 3- Cast all rays. If one hit, get away from that surface using the hitpoint and normal info
        // 4- Make sure there is debug draw for all rays (below in OnDrawGizmosSelected)

        for(uint i = 0; i < rays.Length;i++)
        {
            RaycastHit hit;
            float angle = Mathf.Atan2(move.movement.x, move.movement.z) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.up);

            Vector3 ray_direction = rotation * rays[i].direction;

            if (Physics.Raycast(transform.position, ray_direction, out hit, rays[i].length, mask))
            {
                Vector3 new_position = Vector3.Normalize(hit.normal) * avoid_distance;
                seek.Steer(new_position);
            }
        }


	}

	void OnDrawGizmosSelected() 
	{
		if(move && this.isActiveAndEnabled)
		{
			Gizmos.color = Color.red;
			float angle = Mathf.Atan2(move.movement.x, move.movement.z);
			Quaternion q = Quaternion.AngleAxis(Mathf.Rad2Deg * angle, Vector3.up);

			// TODO 2: Debug draw thoise rays (Look at Gizmos.DrawLine)
            for(int i = 0; i<rays.Length;i++)
            {
                Vector3 ray_direction = q * rays[i].direction;
                ray_direction.y = 0.0f;
                Gizmos.DrawLine(move.transform.position, (transform.position - ray_direction) * rays[i].length);
            }
		}
	}
}
