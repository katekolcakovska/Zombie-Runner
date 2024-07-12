using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayDamage : MonoBehaviour
{
    [SerializeField] Canvas displayDamageCanvas;
    [SerializeField] float displayDamageCanvasTime = 0.3f;

    private void Start()
    {
        displayDamageCanvas.enabled = false;       
    }

    public void DisplayDamageCanvas()
    {
        StartCoroutine(ShowBlood());
        
    }

    IEnumerator ShowBlood()
    {
        displayDamageCanvas.enabled = true;
        yield return new WaitForSeconds(displayDamageCanvasTime);
        displayDamageCanvas.enabled = false;
    }
}
