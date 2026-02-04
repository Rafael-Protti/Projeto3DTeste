using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public string sceneName;

    void ChangeScene()
    {
        StartCoroutine(Fade.FadeIn(LoadScene));
    }

    void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
        StartCoroutine(Fade.FadeOut());
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ChangeScene();
        }
    }
}
