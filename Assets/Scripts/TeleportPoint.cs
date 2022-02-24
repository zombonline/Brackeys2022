using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class TeleportPoint : MonoBehaviour
{
    [SerializeField] Image screenFade;
    bool screenBlack = false ;
    float currentAlpha;
    [SerializeField] TextAsset textFile;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Teleport());
        }
    }
    IEnumerator Teleport()
    {
        FindObjectOfType<PlayerInput>().SwitchCurrentActionMap("UI");
        screenBlack = true;
        yield return new WaitForSeconds(2f);
        TeleportPlayer();
        FindObjectOfType<TextCanvas>().EnableCanvas("Unknown Voice", textFile);
        yield return new WaitForSeconds(3f);
        screenBlack = false;
    }

    private void Update()
    {
        FadeScreen();
    }

    void TeleportPlayer()
    {
        FindObjectOfType<PlayerInput>().transform.position = new Vector3(
            FindObjectOfType<PlayerInput>().transform.position.x,
            FindObjectOfType<PlayerInput>().transform.position.y + 200,
            FindObjectOfType<PlayerInput>().transform.position.z);

    }

    private void FadeScreen()
    {
        if (screenBlack)
        {
            var targetValue = 1f;
            if (currentAlpha < targetValue)
            {
                currentAlpha += 0.5f * Time.deltaTime;
            }
        }
        else
        {
            var targetValue = 0f;
            if (currentAlpha > targetValue)
            {
                currentAlpha -= 0.5f * Time.deltaTime;
            }
        }
        screenFade.color = new Color(screenFade.color.r, screenFade.color.g, screenFade.color.b, currentAlpha);
    }
}
