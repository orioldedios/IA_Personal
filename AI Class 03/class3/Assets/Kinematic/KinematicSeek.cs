using UnityEngine;
using System.Collections;

public class KinematicSeek : MonoBehaviour {

	Move move;

	// Use this for initialization
	void Start () {
		move = GetComponent<Move>();
	}
	
	// Update is called once per frame
	void Update () 
	{
        // TODO 5: Set movement velocity to max speed in the direction of the target
        move.mov_velocity = Vector3.Normalize((move.target.transform.position - move.transform.position)) * move.max_mov_velocity;

        //move.mov_velocity = move.target.transform.position;
        // Remember to enable this component in the inspector
    }
}
