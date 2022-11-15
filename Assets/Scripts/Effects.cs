using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effects : MonoBehaviour
{

    public void PauseForEffect(float duration) {
        StartCoroutine(PauseForEffectCoroutine(duration));
    }

    private IEnumerator PauseForEffectCoroutine(float duration) {
        float timeScaleBefore = Time.timeScale;
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(duration);
        Time.timeScale = timeScaleBefore == 0 ? 1 : timeScaleBefore;
    }

}
