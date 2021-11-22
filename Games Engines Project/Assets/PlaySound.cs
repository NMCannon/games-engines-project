using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    AudioSource beep;

    void Start()
    {
        beep = GetComponent<AudioSource>();
        TriggerBeep();
        Debug.Log("HELLO");
    }

    void TriggerBeep()
    {
        StartCoroutine(delayPrompt());
    }

    IEnumerator delayPrompt()
    {
        yield return new WaitForSeconds(5);
        beep.Play();
        TriggerBeep();
    }
}
