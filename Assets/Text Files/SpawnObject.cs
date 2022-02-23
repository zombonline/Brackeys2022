using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    [SerializeField] int maxItemsCanSpawn;
    [SerializeField] GameObject itemToSpawn;
    [SerializeField] TextAsset nothingToSpawnText;

    public void SpawnItem()
    {
        if (maxItemsCanSpawn > 0)
        {
            Instantiate(itemToSpawn, transform.position, Quaternion.identity);
            maxItemsCanSpawn--;
            FindObjectOfType<TextCanvas>().OkButton();
        }
        else
        {
            FindObjectOfType<TextCanvas>().EnableCanvas("", nothingToSpawnText);
        }
    }
}
