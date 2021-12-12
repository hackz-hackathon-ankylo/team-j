using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System;

public class SceneLoader : MonoBehaviour
{
    public enum Scenes
    {
        Title,
        Runking,
        Main
    }

    [SerializeField] Scenes sceneName;

    //<summary>
    //�C���X�y�N�^�[�őI�΂ꂽ�V�[���ɔ��
    //</summary>
    public void LoadScene()
    {
        SceneManager.LoadScene(Enum.GetName(typeof(Scenes), sceneName));
    }

}
