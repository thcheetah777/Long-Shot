using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public Animator transition;
    public float transitionTime = 1;

    public void LoadScene(string sceneName) {
        StartCoroutine(LoadSceneCoroutine(sceneName));
    }

    public IEnumerator LoadSceneCoroutine(string sceneName) {
        transition.SetTrigger("Leave");
        yield return new WaitForSecondsRealtime(transitionTime);
        SceneManager.LoadScene(sceneName);
    }

}
