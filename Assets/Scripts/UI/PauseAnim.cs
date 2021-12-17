using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseAnim : MonoBehaviour
{
    [SerializeField] GameObject pausePopup;
    [SerializeField] float fadeInAlpha;
    [SerializeField] float fadeOutAlpha;
    CanvasGroup canvasGroup;
    // Start is called before the first frame update
    void Start()
    {
        canvasGroup = pausePopup.GetComponent<CanvasGroup>();
    }

    public void PauseButtonPushed(){
        StartCoroutine ("PopupFadeIn");
    }
    public void ResumeButtonPushed(){
        StartCoroutine ("PopupFadeOut");
    }

    private IEnumerator PopupFadeIn() {
        while(canvasGroup.alpha != 1){
            canvasGroup.alpha += fadeInAlpha;
            yield return new WaitForSeconds (0.01f);
        }
        yield break;
    }
    private IEnumerator PopupFadeOut() {
    while(canvasGroup.alpha != 0){
        canvasGroup.alpha -= fadeOutAlpha;
        yield return new WaitForSeconds (0.005f);
        }
    yield break;
    }
}
