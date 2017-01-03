using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {

 
    
    public enum CyckleMethod    {  bounce, repeat    }
    
    public Transform[] m_Waypoints;
    public float moveSpeed = 5f; 
    public bool loop;

    private Vector3 m_currentPosition;
    private int currentWaypoint = 0;

    //Inituialization
	void Start ()
    {
        
        GoToNextPoint();
	}
	

	void Update ()
    {
        
        if (loop == true)
            Loop();
        else
            PingPong();

	}
    //Back and Forth
    void PingPong()
    {

    }
    //Looping
    void Loop()
    {

        m_currentPosition = Vector3.MoveTowards(m_currentPosition, m_Waypoints[currentWaypoint].position, moveSpeed);
        float dist = Vector3.Distance(m_currentPosition, m_Waypoints[currentWaypoint].position);
        if (dist < 0.2f)
            GoToNextPoint();
        
    }
    void GoToNextPoint()
    {
        if (m_Waypoints.Length == 0)
        {
            return;
        }

        currentWaypoint = (currentWaypoint + 1) % m_Waypoints.Length;
    }
}
