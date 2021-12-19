using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseAnim : MonoBehaviour
{
    [SerializeField] GameObject pausePopup;
    [SerializeField] GameObject wholePanel;
    [SerializeField] float fadeAlpha;
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
        wholePanel.SetActive (true);
        while(canvasGroup.alpha != 1){
            canvasGroup.alpha += fadeAlpha;
            yield return new WaitForSeconds (0.01f);
        }
        Time.timeScale=0;
        yield break;
    }
    private IEnumerator PopupFadeOut() {
        Time.timeScale=1;
    while(canvasGroup.alpha != 0){
        canvasGroup.alpha -= fadeAlpha;
        yield return new WaitForSeconds (0.005f);
        }
        wholePanel.SetActive (false);
    yield break;
    }
}
