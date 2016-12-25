using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;

    private bool agro;
    private SphereCollider sphere;
    // Use this for initialization
	void Start ()
    {
        agent = GetComponent<NavMeshAgent>();

        sphere = GetComponent<SphereCollider>(); //agrro aura 
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

    void OnTriggerEnter (Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            
            
            
        }
    }
    //chosing new target
    public void TargetPlayer(bool newTarget)
    {
        if(newTarget == true)
        {
            //agent.destination = Player.position;
        }
    }


	// Update is called once per frame
	void Update ()
    {
        if (agent.remainingDistance < 0.5f)
        {
            GotoNextPoint();
        }
	}
}
