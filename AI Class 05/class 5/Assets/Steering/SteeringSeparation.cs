﻿using UnityEngine;
using System.Collections;
using UnityEngine.Assertions;

public class SteeringSeparation : MonoBehaviour
{

    public LayerMask mask;
    public float search_radius = 5.0f;
    public AnimationCurve falloff;

    //private Vector3[] escape_vectors =null;

    Move move;

    // Use this for initialization
    void Start()
    {
        move = GetComponent<Move>();
    }

    // Update is called once per frame
    void Update()
    {
        // TODO 1: Agents much separate from each other:
        // 1- Find other agents in the vicinity (use a layer for all agents)
        // 2- For each of them calculate a escape vector using the AnimationCurve
        // 3- Sum up all vectors and trim down to maximum acceleration
        Collider[] tank_colliders = Physics.OverlapSphere(move.transform.position, search_radius, mask);

        Vector3 escape_vector = Vector3.zero;

        Assert.IsTrue(move.transform.position.y == 0.0f);


        for (int i = 0; i < tank_colliders.Length; i++)
        {
            if(tank_colliders[i].gameObject.tag != this.tag)
            {
                Vector3 distance_vector = tank_colliders[i].transform.position - move.transform.position;

                float curve = falloff.Evaluate(Vector3.Magnitude(distance_vector) / search_radius);

                escape_vector += distance_vector * -1 * curve;

                Assert.IsTrue(move.transform.position.y == 0.0f);

            }

            Assert.IsTrue(escape_vector.y == 0);

            //hardcoded because the fliying error wtf?
            Vector3 hardcoded_vector =  new Vector3(move.transform.position.x,0.0f, move.transform.position.z);

            move.transform.position = hardcoded_vector;

        }

        move.AccelerateMovement(Vector3.ClampMagnitude(escape_vector, move.max_mov_acceleration));

        //move.movement = escape_vector;
    }

    void OnDrawGizmosSelected()
    {
        // Display the explosion radius when selected
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, search_radius);
    }
}
