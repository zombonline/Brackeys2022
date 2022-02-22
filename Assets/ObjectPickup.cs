using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class ObjectPickup : MonoBehaviour
{
    PlayerInput playerInputActions;
    public LayerMask layer;
    [SerializeField] Transform raycastStart, raycastEnd;
    [SerializeField] Rigidbody currentObject;
    private void Awake()
    {
        playerInputActions = GetComponent<PlayerInput>();
    }
    private void Update()
    { 
        Debug.DrawLine(raycastStart.position, raycastEnd.position, Color.red);
        HoldObject();
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            SelectObject();
        }
    }

    private void HoldObject()
    {
        if (currentObject != null)
        {
           
        }
    }

    public void SelectObject()
    {
        var ray = Physics.Linecast(raycastStart.position, raycastEnd.position, out RaycastHit hitInfo, layer);
        if (currentObject != null)
        {
            currentObject.useGravity = true;
            currentObject.GetComponent<FixedJoint>().connectedBody = null;
            Destroy(currentObject.GetComponent<FixedJoint>());
            currentObject.AddForce(Camera.main.transform.forward * Mathf.Abs(playerInputActions.actions.FindAction("Look").ReadValue<Vector2>().sqrMagnitude));
            currentObject = null;
            return;
        }
        else
        {
            if (currentObject == null && hitInfo.collider !=null && hitInfo.collider.CompareTag("Interactable"))
            {
                Debug.Log(hitInfo.collider.name);
                currentObject = hitInfo.collider.GetComponent<Rigidbody>();
                currentObject.gameObject.AddComponent<FixedJoint>();
                currentObject.GetComponent<FixedJoint>().connectedMassScale = 0.1f;
                currentObject.GetComponent<FixedJoint>().massScale = 0.1f;
                currentObject.GetComponent<FixedJoint>().connectedBody = raycastEnd.GetComponent<Rigidbody>();
                currentObject.useGravity = false;
            }
        }
    }
}
