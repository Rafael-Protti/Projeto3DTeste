using System.Collections;
using UnityEngine;

public class Fade : MonoBehaviour
{
    static CanvasGroup cg;

    public bool canStartFadeout = true;
    void Start()
    {
        cg = GetComponent<CanvasGroup>();

        if (canStartFadeout)
        {
            StartCoroutine(FadeOut());
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            StartCoroutine(FadeIn());
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            StartCoroutine(FadeOut());
        }
    }

    public static IEnumerator FadeIn(System.Action callBack = null)
    {
        cg.alpha = 0;

        cg.blocksRaycasts = true;
        cg.interactable = true;

        while (cg.alpha < 1)
        {
            cg.alpha += Time.deltaTime;
            yield return null;
        }

        cg.alpha = 1;

        callBack?.Invoke();
    }

    public static IEnumerator FadeOut(System.Action callBack = null)
    {
        cg.alpha = 1;

        cg.blocksRaycasts = false;
        cg.interactable = false;

        while (cg.alpha > 0)
        {
            cg.alpha -= Time.deltaTime;
            yield return null;
        }

        cg.alpha = 0;

        callBack?.Invoke();
    }
}
