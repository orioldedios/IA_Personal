using UnityEngine;
using System.Collections;

public class SteeringSeparation : MonoBehaviour {

	public LayerMask mask;
	public float search_radius = 5.0f;
	public AnimationCurve falloff;

    //private Vector3[] escape_vectors =null;

    Move move;

	// Use this for initialization
	void Start () {
		move = GetComponent<Move>();
	}
	
	// Update is called once per frame
	void Update () 
	{
        // TODO 1: Agents much separate from each other:
        // 1- Find other agents in the vicinity (use a layer for all agents)
        // 2- For each of them calculate a escape vector using the AnimationCurve
        // 3- Sum up all vectors and trim down to maximum acceleration
        Collider[] tank_colliders = Physics.OverlapSphere(move.transform.position, search_radius, mask);

        Vector3 escape_vector = Vector3.zero;

        for (int i = 0; i < tank_colliders.Length; i++)
        {

            float curve = falloff.Evaluate(Vector3.Magnitude(tank_colliders[i].transform.position - move.transform.position) / search_radius);

            move.AccelerateMovement((tank_colliders[i].transform.position - move.transform.position) * -1 * curve);

            //escape_vector = escape_vector + escape_vectors[i];
        }

        //move.movement = escape_vector;
    }

	void OnDrawGizmosSelected() 
	{
		// Display the explosion radius when selected
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(transform.position, search_radius);
	}
}
