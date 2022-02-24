using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    [SerializeField] int maxItemsCanSpawn;
    [SerializeField] GameObject itemToSpawn;
    [SerializeField] TextAsset nothingToSpawnText;
    [SerializeField] Transform spawnPoint;
    public void SpawnItem()
    {
        if (maxItemsCanSpawn > 0)
        {
            Instantiate(itemToSpawn, spawnPoint.position, Quaternion.identity);
            maxItemsCanSpawn--;
            FindObjectOfType<TextCanvas>().OkButton();
        }
        else
        {
            FindObjectOfType<TextCanvas>().EnableCanvas("", nothingToSpawnText);
        }
    }
}
