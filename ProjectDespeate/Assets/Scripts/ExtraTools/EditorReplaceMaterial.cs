using UnityEngine;
using UnityEditor;
using System.Collections;

public class EditorReplaceMaterial : EditorWindow {

    Material Newmaterial;
    public Material m_TargetMaterial;
    public bool hasChildern;
    public GameObject currentObj;

    [MenuItem("Extra Tools/Material Replacer")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(EditorReplaceMaterial));
    }
    
    void OnGUI()
    {
        //Pick new material
        GUILayout.Label("Target Material", EditorStyles.boldLabel);
        m_TargetMaterial = (Material)EditorGUILayout.ObjectField(m_TargetMaterial, typeof(Material), true);
        hasChildern = EditorGUILayout.Toggle("Has Children", hasChildern);
        
        
        if (GUILayout.Button ("Replace Material")   )
        {
            // Replaces Active gameobject material with target material
            currentObj = Selection.activeGameObject;
            ReplaceMat(currentObj);
            Debug.Log("Material Changed");

        }
        
    }
    /*
    [MenuItem("Extra Tools/Replace _g")]
    public void KeyReplace()
    {
        currentObj = Selection.activeGameObject;
        ReplaceMat(currentObj);
    }

    */



    //Method for replacing material
    public void ReplaceMat (GameObject go)
    {
        if (go.GetComponent<Renderer>())
        {
            go.GetComponent<Renderer>().material = m_TargetMaterial;
        }

    }


    
}
 