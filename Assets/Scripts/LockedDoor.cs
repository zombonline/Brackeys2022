using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : MonoBehaviour
{
    [SerializeField] bool key = true;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<Key>() && key)
        {
            UnlockDoor();
        }
    }

    public void UnlockDoor()
    {
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
    }
    public void LockDoor()
    {
        GetComponent<MeshRenderer>().enabled = true;
        GetComponent<BoxCollider>().enabled = true;
    }
}
