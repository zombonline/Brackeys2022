using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
public class TextCanvas : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI charName, charSpeech;
    [SerializeField] TextAsset textFile;
    Canvas canvas;
    bool textSkipped = false;
    public Canvas buttonCanvas;
    private void Awake()
    {
        canvas = GetComponent<Canvas>();
    }

    public void EnableCanvas(string charNameText, TextAsset charSpeechText)
    {
        ResetCanvas();
        textFile = charSpeechText;
        CursorController.CursorShow();
        FindObjectOfType<PlayerInput>().SwitchCurrentActionMap("UI");
        canvas.enabled = true;
        charName.text = charNameText;
        StartCoroutine(TypeWriterText());
    }

    IEnumerator TypeWriterText()
    {
        for(int i = 0; i <= textFile.text.Length; i++)
        {
                yield return new WaitForSeconds(0.01f);
                charSpeech.text = textFile.text.Substring(0, i);
        }
    }
    public void OkButton()
    {
        CursorController.CursorHide();
        FindObjectOfType<PlayerInput>().SwitchCurrentActionMap("Movement");
        ResetCanvas();
    }

    private void ResetCanvas()
    {
        canvas.enabled = false;
        if (buttonCanvas != null)
        {
            buttonCanvas.enabled = false;
            buttonCanvas = null;
        }
        charSpeech.text = null;

    }
}
