using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour{

    public Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;

    private bool agro;
    private SphereCollider sphere;
    private Transform target = null;
    private bool followTarget;

    // Use this for initialization
    void Start ()
    {
        agent = GetComponent<NavMeshAgent>();

        agent.autoBraking = false;

        GotoNextPoint();


	}
	
    //Patrolling to next Point
    void GotoNextPoint()
    {
        if (points.Length == 0)
        {
            return;
        }
        agent.destination = points[destPoint].position;

        destPoint = (destPoint + 1) % points.Length;
    }

    //Chase Player
    void OnTriggerEnter (Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("PlayerCollision");
            target = other.gameObject.transform;
            followTarget = true;

            
        }
    }
	// Update is called once per frame
	void Update ()
    {
        if (followTarget == false)
        {
            if (agent.remainingDistance < 0.5f)
            {
                GotoNextPoint();
            }
                
        }
        else
        {
            agent.destination = target.position;
        }
	}
}
