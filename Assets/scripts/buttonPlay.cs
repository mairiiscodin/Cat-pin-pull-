using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class buttonPlay : MonoBehaviour
{
    [SerializeField] Animator transScene;
    [SerializeField] float delayTime = 1f;

    public void Play()
    {
        StartCoroutine(LoadSceneDelay("SceneLevel1"));
    }

    public void NextLevel()
    {
        StartCoroutine(LoadSceneDelay(
            SceneManager.GetActiveScene().buildIndex + 1
        ));
    }

    public void Restart()
    {
        StartCoroutine(LoadSceneDelay(
            SceneManager.GetActiveScene().buildIndex
        ));
    }

    public void Menu()
    {
        StartCoroutine(LoadSceneDelay("Menu"));
    }

    IEnumerator LoadSceneDelay(string sceneName)
    {
        transScene.SetTrigger("end");
        yield return new WaitForSecondsRealtime(delayTime);
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneName);
    }

    IEnumerator LoadSceneDelay(int sceneIndex)
    {
        
        transScene.SetTrigger("end");
        yield return new WaitForSecondsRealtime(delayTime);
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneIndex);
    }
}
