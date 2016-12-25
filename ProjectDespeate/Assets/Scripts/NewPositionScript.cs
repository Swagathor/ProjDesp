using UnityEngine;
using System.Collections;

public class NewPositionScript : MonoBehaviour {

    private Transform TeleportArrive;
    //private BoxCollider DoorCollider;

    public GameObject targetObjective;
    private Transform targetTeleport;

    [Range(0.1f,2f)]
    public float timeLeft;
    private float currentTime;

    private bool startTime;


    // Use this for initialization
    void Start ()
    {
        //DoorCollider = gameObject.GetComponent<BoxCollider>();
        targetTeleport = targetObjective.transform;

        if (targetObjective == null)
        {
            Debug.Log("Target objective is Null");
            targetTeleport.position = new Vector3(1, 1, 1);
        }
    }
	// Update is called once per frame
	void Update ()
    {
        StartTimer(startTime, timeLeft);
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player Collision is working");
            
            other.transform.position = targetTeleport.position;
            CameraMovement.instance.SetActive(false);
            startTime = true; //starts the counter

        }
    }
    //Start Camera after Delay
    void StartTimer(bool start, float T)
    {
        if(start == true)
        {
            currentTime -= Time.deltaTime;
            Debug.Log(currentTime);
            if (currentTime <= 0)
            {
                CameraMovement.instance.SetActive(true);
                startTime = false;
                Debug.Log("Timer Stopt");
            }
        }
        else
        {
            currentTime = T;
            
        }
    }

    void OnTriggerExit (Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player left Collider");
            
        }
    }
    


}
