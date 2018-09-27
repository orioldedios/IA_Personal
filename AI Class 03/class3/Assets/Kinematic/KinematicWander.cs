using UnityEngine;
using System.Collections;

public class KinematicWander : MonoBehaviour {

	public float max_angle = 0.5f;
    private float counter = 0.0f;
    public float time_to_change = 0.0f;
    private Vector3 angle = Vector3.zero;

    Move move;

	// Use this for initialization
	void Start () {
		move = GetComponent<Move>();
	}

	// number [-1,1] values around 0 more likely
	float RandomBinominal()
	{
		return Random.value * Random.value;
	}
	
	// Update is called once per frame
	void Update () 
	{
        // TODO 9: Generate a velocity vector in a random rotation (use RandomBinominal) and some attenuation factor
        if (counter > time_to_change)
        {
            Vector3 vector = new Vector3(RandomBinominal(), 0, RandomBinominal());

            angle = Vector3.Normalize(vector) * move.max_mov_velocity;

            counter = 0.0f;
        }
        else
        {
            counter += 0.1f;
        }

        move.mov_velocity = angle;
        //transform.rotation *= q;

    }
}
