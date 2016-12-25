using UnityEngine;
using System.Collections;

public class EnemyPatrol : MonoBehaviour {


    public float f_raduis;
    public bool f_pulse;

    private SphereCollider sphere;
    // Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
        SphereCollider sphere = GetComponent<SphereCollider>();

        if (f_pulse == true)
        {
            sphere.radius = attentionRadius(f_raduis);
        }
	}
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Player agro");
            
        }
    }
    private float attentionRadius(float input)
    {
        if (input >= input * 0.5f)
        {
            input = input + Time.deltaTime;
        }
        if (input <= input * 1.5f)
        {
            input = input - Time.deltaTime;
        }
        return input;
    }
        
}
