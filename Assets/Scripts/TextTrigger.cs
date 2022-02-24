using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextTrigger : MonoBehaviour
{
    [SerializeField] TextAsset textFile;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Interactable"))
        {
            FindObjectOfType<TextCanvas>().EnableCanvas("Derek", textFile);
        }
    }
}
