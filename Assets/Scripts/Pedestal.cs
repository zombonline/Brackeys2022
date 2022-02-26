using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedestal : MonoBehaviour
{
    [SerializeField] LockedDoor door;
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<MissingArtifact>())
        {
            door.UnlockDoor();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<MissingArtifact>())
        {
            door.LockDoor();
        }
    }
}
