using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float playerSpeed = 6f;
    public float gravity = 20f;

    private Vector3 characterLocation = Vector3.zero;
    CharacterController controller;

    public static PlayerController instance;
    // Use this for initialization
    void Awake()
    {
        instance = this;
    }
    void Start()
    {       


    }

    // Update is called once per frame
    void Update()
    {
        controller = GetComponent<CharacterController>();
        if(controller.isGrounded)
        {
            characterLocation = transform.TransformDirection(MoveCtrl());
            characterLocation *= playerSpeed;

        }
        characterLocation.y -= gravity * Time.deltaTime;
        controller.Move(characterLocation * Time.deltaTime);

    }

    // Move method 
    Vector3 MoveCtrl()
    {
        return new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    }
}

