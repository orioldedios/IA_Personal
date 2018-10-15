using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.AI;

public class MoveToMouseClick : MonoBehaviour {

	public LayerMask mask;
	public int mouse_button = 0;

    public GameObject[] objects;

    // Update is called once per frame
    void Update () {
		if(Input.GetMouseButton(mouse_button))
		{
			RaycastHit hit;
			Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast(r, out hit, 10000.0f, mask) == true)
				transform.position = hit.point;

            for (int i = 0; i < objects.Length; i++)
            {
                if (objects[i].GetComponent<NavMeshAgent>() != null)
                {
                    objects[i].GetComponent<NavMeshAgent>().destination = transform.position;
                }

            }
        }
	}

}
