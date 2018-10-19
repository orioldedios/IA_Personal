using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Stop : MonoBehaviour {

	public NavMeshAgent navMeshAgent;
	public Animator animation;
    public float distance;

	// Use this for initialization
	void Start () 
	{
		navMeshAgent = GetComponent<NavMeshAgent>();
		animation = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
	{
        distance = navMeshAgent.remainingDistance;


        if (navMeshAgent.remainingDistance > 1.0f) {
			animation.SetBool("movement",true);	 	
		}
        else
        {
            animation.SetBool("movement", false);
        }

        Vector3 vel = 
    }
}
