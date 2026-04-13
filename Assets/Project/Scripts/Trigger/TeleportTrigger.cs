using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportTrigger : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("TeleportTrigger: OnTriggerEnter");
            FadeController.Get().Cover(3.0f, () => { SceneManager.LoadSceneAsync("OutSide"); });
        }
    }
}
