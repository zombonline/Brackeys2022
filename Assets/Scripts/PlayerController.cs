using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //Input
    PlayerInput playerInputActions;
    public Vector2 input_Movement;
    public Vector2 input_View;

    #region Movement Setup
    [Header("Movement Setup")]

    Rigidbody rigidbody;

    [SerializeField] float playerSpeed = 5f;

    float moveY = 0;
    float moveX = 0;
    #endregion

    #region Camera Setup
    [Header("Camera Setup")]
    [SerializeField] GameObject playerHead;
    Camera cam;
    [SerializeField] float minX = -60f;
    [SerializeField] float maxX = 60f;
    [SerializeField] float sensitivityX = 15f;
    [SerializeField] float sensitivityY = 15f;

    float rotationY = 0;
    float rotationX = 0;
    #endregion
    private void Awake()
    {
        //find cached references
        cam = FindObjectOfType<Camera>();
        rigidbody = GetComponent<Rigidbody>();
        playerInputActions = GetComponent<PlayerInput>();
        //lock cursor
        CursorController.CursorHide();
    }

    private void Update()
    {
        input_Movement = playerInputActions.actions.FindAction("Move").ReadValue<Vector2>();
        input_View = playerInputActions.actions.FindAction("Look").ReadValue<Vector2>();

        PlayerView();
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        moveX = input_Movement.x * playerSpeed * Time.deltaTime;
        moveY = input_Movement.y * playerSpeed * Time.deltaTime;
        transform.localPosition += transform.forward * moveY;
        transform.localPosition += transform.right * moveX;
    }

    private void PlayerView()
    {
        rotationY += input_View.x * sensitivityX * Time.deltaTime;
        rotationX += -input_View.y * sensitivityY * Time.deltaTime;

        rotationX = Mathf.Clamp(rotationX, minX, maxX);

        transform.eulerAngles = new Vector3(0, rotationY, 0);
        playerHead.transform.eulerAngles = new Vector3(rotationX, rotationY, 0);
    }

    
}
