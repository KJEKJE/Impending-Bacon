using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    [RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement Properties")]
    public float _walkSpeed = 30f;
    public float runSpeed = 60f;
    private float turnSpeed = 500f;
    public float pitch = 0;
    public float gravity;

    [Header("Controls")]        // creating keyCodes for actions within the game
    [SerializeField] private KeyCode sprintKey = KeyCode.LeftShift;
    [SerializeField] private KeyCode primaryAction = KeyCode.Mouse0;  // left click
    [SerializeField] private KeyCode secondaryAction = KeyCode.Mouse1;  // right click
    [SerializeField] private KeyCode interactKey = KeyCode.E;
    [SerializeField] private KeyCode pauseKey = KeyCode.Escape;

    private Transform camTransform;
    private Camera playerCam;
    private CharacterController character;

    // need controllers for UI, and GameController once game starts being build as well as interactable scrips for objects.


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;  // lock cursor to the window
        character = GetComponent<CharacterController>();
        playerCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();  // find the camera in game and attach it to this variable.
        camTransform = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal"); // get input from the mouse
        float y = Input.GetAxis("Vertical");

        Vector3 moveDirection = transform.right * x + transform.forward * y;


        if (Input.GetKey(sprintKey))        // set up movement - depending on key press we can make the player sprint.
        {
            character.Move(moveDirection * runSpeed * Time.deltaTime);
        }
        else
        {
            character.Move(moveDirection * _walkSpeed * Time.deltaTime);
        }

        float xMouse = Input.GetAxis("Mouse X") * turnSpeed * Time.deltaTime;  // gather data on mouse movement speed - we can change the sensitivity by changing turnSpeed. Or apply a slider to it so the player can do it themselves.
        float yMouse = Input.GetAxis("Mouse Y") * turnSpeed * Time.deltaTime;

        // assigning the pitch to the y Axis so it stops the user being able to rotate 180Degrees and turning themselves around and upside down
        pitch -= yMouse;
        pitch = Mathf.Clamp(pitch, -85, 85); // the player can look up, and down just below the 90degree angle.
        

        // applying pitch to x axis too, applying local rotation so camera is consistance with parent objects. i.e the player
        camTransform.localRotation = Quaternion.Euler(pitch, 0, 0);
        transform.Rotate(Vector3.up * xMouse);
    }
}
