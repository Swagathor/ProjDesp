using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {

 
    
    public enum CyckleMethod    {  bounce, repeat    }
    
    public Transform[] m_Waypoints;
    public float moveSpeed;
    public bool loop;

    private Vector3 m_currentPosition;

    //Inituialization
	void Start ()
    {
	
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
        transform.position = Vector3.Lerp(m_currentPosition, m_Waypoints, Time.Deltatime * moveSpeed);

    }
}
