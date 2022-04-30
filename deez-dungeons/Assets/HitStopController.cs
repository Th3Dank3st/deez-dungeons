using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitStopController : MonoBehaviour
{
    private void Stop(float duration)
    {
        Time.timeScale = 0.0f;
        StartCoroutine(Wait(duration));
    }
    IEnumerator Wait(float duration)
    {
        yield return new WaitForSecondsRealtime(duration);
        Time.timeScale = 1.0f;
    }
}

