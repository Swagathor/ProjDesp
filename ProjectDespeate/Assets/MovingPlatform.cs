using UnityEngine;
using System.Collections.Generic;
using System.Linq;

[RequireComponent(typeof(Rigidbody))]
public class MovingPlatform : MonoBehaviour {

    //public enum CyckleMethod    {  bounce, repeat    }

    public List<Transform> Waypoints = new List<Transform>();
    Transform[] m_Waypoints;
    int currentWaypoint;

    public float moveSpeed = 5f;
    public bool loop;

    private Vector3 m_currentPosition;
    private Vector3 m_movement;
    private bool forward = true;

    Rigidbody rigid;
    void Awake ()
    {
        m_Waypoints = Waypoints.ToArray();
        
        rigid = GetComponent<Rigidbody>();  
    }
    void Start()
    {
        transform.DetachChildren(); //MFKEYTHING
        GoToNextPoint(loop);
    }
	void FixedUpdate ()
    {
        m_movement  = Vector3.MoveTowards(rigid.position, m_Waypoints[currentWaypoint].position, moveSpeed * Time.deltaTime);
        rigid.MovePosition(m_movement);
        float dist = Vector3.Distance(transform.position, m_Waypoints[currentWaypoint].position);
        if (dist < 0.1f)
            GoToNextPoint(loop);

	}
    //bool decides if the movement is going to loop or count /\ and \/
    void GoToNextPoint(bool loop)
    {
        //loop
        if (loop == true)
        {
            if (m_Waypoints.Length == 0)
            {
                return;
            }

            currentWaypoint = (currentWaypoint + 1) % m_Waypoints.Length;
        }
        //PingPong
        else
        {
                if (forward == true)
                {
                    currentWaypoint = (currentWaypoint + 1);
                    if (currentWaypoint >= m_Waypoints.Length)
                    {
                        forward = false;
                        currentWaypoint = m_Waypoints.Length - 2;
                    }
                }
                else
                {
                    currentWaypoint = (currentWaypoint - 1);
                    if (currentWaypoint < 0)
                    {
                        forward = true;
                        currentWaypoint = 1;
                    }
                }
        }
    }
}