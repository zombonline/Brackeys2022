using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ReadableItem : MonoBehaviour
{
    [SerializeField] string name;
    [SerializeField] TextAsset textFile;
    [SerializeField] Canvas buttonCanvas;

    public void Interact()
    {
        FindObjectOfType<PlayerInput>().SwitchCurrentActionMap("UI");
        FindObjectOfType<TextCanvas>().EnableCanvas(name, textFile);
        buttonCanvas.enabled = true;
        FindObjectOfType<TextCanvas>().buttonCanvas = buttonCanvas;
    }



}
