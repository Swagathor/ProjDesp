using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class gizmoRender : MonoBehaviour {

    Mesh ParentMesh;
    Vector3 ParentScale;
    public bool WireMesh;

    void Update () //Get mesh and scale
    {   
        
            ParentMesh = GetComponentInParent<MeshFilter>().sharedMesh;
            ParentScale = GetComponentInParent<Transform>().lossyScale;
        

    }
    void OnDrawGizmos () //Draws Gizmo 
    {
        if (Application.isEditor)
        {
            
            if (WireMesh == true) //Wiremesh or not
                Gizmos.DrawWireMesh(ParentMesh, 0, transform.position, transform.rotation, ParentScale);
            else
                Gizmos.DrawMesh(ParentMesh, 0, transform.position, transform.rotation, ParentScale);
        } 
    }
}
