using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ItemPickup : MonoBehaviour {


    BoxCollider Collider;

    [TextArea(1, 10)]
    public string itemName = "item";
    public float worth;
    [TextArea(1, 255)]
    public string itemDescription;
    public Mesh itemMesh;

    gameManager Manager;
    MeshFilter MeshFilter;
    MeshRenderer MeshRender;

    float rotatorSpeed = 1f;
    Vector3 rotate; 
    public float RotateAngle = 5f; 
    void Awake ()
    {
        MeshRender = MeshRender.GetComponent<MeshRenderer>();
        MeshFilter = MeshFilter.GetComponent<MeshFilter>();

        MeshFilter.sharedMesh = itemMesh;
    }
    void Update ()
    {
        Vector3 rotate = transform.position;
    }
    void OnTriggerEnter (Collider other)
    {
        if(other.tag == "Player")
        {
            //do stuff
            Debug.Log("Player picked up Item");

            Manager.AddtoList(itemName, worth, itemDescription);
            
            Destroy (gameObject);
        }
    }
    
    void RotateMesh()
    {
        transform.Rotate(rotate, RotateAngle);
    }
}
