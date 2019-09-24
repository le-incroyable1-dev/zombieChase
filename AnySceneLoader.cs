using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnySceneLoader : MonoBehaviour
{

    public int Scene_Int;

    public void LoadScene()
    {
        SceneManager.LoadScene(Scene_Int);
    }
}
