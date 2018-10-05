using UnityEngine;
using System.Collections;
using BansheeGz.BGSpline.Components;
using BansheeGz.BGSpline.Curve;

public class SteeringFollowPath : MonoBehaviour {

	Move move;
	SteeringSeek seek;

    public BGCcMath MyPath;
    public float range = 0.1f;
    private Vector3 closest_point;
    private float distance;

    // Use this for initialization
    void Start ()
    {
		move = GetComponent<Move>();
		seek = GetComponent<SteeringSeek>();

        // TODO 1: Calculate the closest point in the range [0,1] from this gameobject to the path
        closest_point = MyPath.CalcPositionByClosestPoint(move.transform.position, out distance);
     }
	
	// Update is called once per frame
	void Update () 
	{
        // TODO 2: Check if the tank is close enough to the desired point
        // If so, create a new point further ahead in the path

        if ((closest_point - transform.position).magnitude < range)
        {
            
            distance += 0.1f;
            if((distance / MyPath.GetDistance()) > 1.0f)
            {
                distance = 0;
            }
            closest_point = MyPath.CalcPositionByDistanceRatio(distance/ MyPath.GetDistance());
        }
        seek.Steer(closest_point);

    }

	void OnDrawGizmosSelected() 
	{

		if(isActiveAndEnabled)
		{
			// Display the explosion radius when selected
			Gizmos.color = Color.green;
            // Useful if you draw a sphere were on the closest point to the path
            Gizmos.DrawSphere(closest_point, 2.0f);
        }

    }
}
