using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneScripts : MonoBehaviour
{
    public string nameS;
    public void A()
    {
        FadeController.Get()?.Cover(3.0f, () => { SceneManager.LoadSceneAsync(nameS); });
    }
}
