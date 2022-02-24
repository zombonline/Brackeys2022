using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coinslot : MonoBehaviour
{

    [SerializeField] TextAsset textfile;
    [SerializeField] Canvas buttonCanvas;

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Coin>())
        {
            Destroy(other.gameObject);
            FindObjectOfType<TextCanvas>().EnableCanvas("Vending Machine", textfile);
            buttonCanvas.enabled = true;
            FindObjectOfType<TextCanvas>().buttonCanvas = buttonCanvas;
        }
    }
}
