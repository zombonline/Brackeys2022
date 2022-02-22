using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySight : MonoBehaviour
{
    [SerializeField] float spotTime = 1f;
    [SerializeField] bool inSight;
    void Update()
    {
        if(inSight)
        {
            spotTime -= Time.deltaTime;
        }
        else
        {
            spotTime = 1f;
        }

        if(spotTime < 0f)
        {
            Debug.Log("Game Over");
        }
    }

    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            inSight = true;
            GetComponentInParent<EnemyMovement>().StopMoving();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            inSight = false;
            GetComponentInParent<EnemyMovement>().ContinueMoving();

        }
    }
}
