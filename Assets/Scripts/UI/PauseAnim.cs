using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseAnim : MonoBehaviour
{
    [SerializeField] GameObject wholePanel;
    [SerializeField] GameObject backPanel;
    [SerializeField] GameObject pausePopup;
    [SerializeField] float fadeAlpha;
    Image background;
    
    CanvasGroup canvasGroup;
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
        yield break;
    }
    private IEnumerator PopupFadeOut() {
    while(canvasGroup.alpha != 0){
        canvasGroup.alpha -= fadeAlpha;
        yield return new WaitForSeconds (0.005f);
        }
        wholePanel.SetActive (false);
    yield break;
    }
}
