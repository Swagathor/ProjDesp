using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

    public Transform target;
    public float smoothTime = 0.6f;
    public float cameraOffsetZ = 2;
    public float cameraHeight = 10;   

    private Vector3 velocity = Vector3.zero;

    private bool updateCamera = true;

    public static CameraMovement instance;
    void Awake ()
    {
        instance = this;
    }
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {

        Vector3 targetPosition = target.TransformPoint(new Vector3(0, cameraHeight, cameraOffsetZ));

        if (updateCamera == true)
        {
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
        else
        {
            transform.position = targetPosition;
        }
        transform.LookAt(target);
    }
    public void SetActive (bool active)
    {
        updateCamera = active;
    }

}
