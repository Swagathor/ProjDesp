using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {

 
    
    //public enum CyckleMethod    {  bounce, repeat    }
    
    public Transform[] m_Waypoints;
    public float moveSpeed = 5f;
    public bool loop;

    private Vector3 m_currentPosition;
    private int currentWaypoint = 0;
    private bool forward = true; 
    //Inituialization
	void Start ()
    {
        
        GoToNextPoint(loop);
	}
	

	void Update ()
    {
        transform.position = m_currentPosition;

        if (loop == true)
            Loop();
        else
            PingPong();

	}
    //Back and Forth
    void PingPong()
    {
        m_currentPosition = Vector3.MoveTowards(m_currentPosition, m_Waypoints[currentWaypoint].position, moveSpeed * Time.deltaTime);

        float dist = Vector3.Distance(m_currentPosition, m_Waypoints[currentWaypoint].position);
        if (dist < 0.5f)
            GoToNextPoint(false);
    }
    //Looping
    void Loop()
    {

        m_currentPosition = Vector3.MoveTowards(m_currentPosition, m_Waypoints[currentWaypoint].position, moveSpeed * Time.deltaTime);

        float dist = Vector3.Distance(m_currentPosition, m_Waypoints[currentWaypoint].position);
        if (dist < 0.5f)
            GoToNextPoint(loop);
        
    }

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
            if(forward == true)
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
