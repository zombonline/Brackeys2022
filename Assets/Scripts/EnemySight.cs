using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySight : MonoBehaviour
{
    [SerializeField] float spotTime = 1f;
    [SerializeField] bool inSight;
    [SerializeField] Transform rayCastStart;
    [SerializeField] LayerMask layerMask;
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
            var heading = other.transform.position - rayCastStart.position;
            var distance = heading.magnitude;
            var direction = heading / distance;

            Physics.Raycast(rayCastStart.position, direction * distance, out RaycastHit hitInfo, 100f, layerMask);
            Debug.DrawRay(rayCastStart.position, direction * distance, Color.red);
            if (hitInfo.collider != null)
            {
                if (hitInfo.collider.CompareTag("Player"))
                {
                    inSight = true;
                    GetComponentInParent<EnemyMovement>().StopMoving();
                }
                else
                {
                    inSight = false;
                    GetComponentInParent<EnemyMovement>().StopMoving();
                }
            }
            else
            {
                inSight = false;
                GetComponentInParent<EnemyMovement>().StopMoving();
            }
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
