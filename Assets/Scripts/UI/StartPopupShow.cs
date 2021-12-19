using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPopupShow : MonoBehaviour
{
    [SerializeField] GameObject startGroup;
    PauseAnim pauseAnim;
    [SerializeField]CanvasGroup startWholeGroup;    // Start is called before the first frame update
    void Start()
    {
        pauseAnim = startGroup.GetComponent<PauseAnim>();
        startWholeGroup.alpha = 1;
        pauseAnim.PauseButtonPushed();
    }


}
