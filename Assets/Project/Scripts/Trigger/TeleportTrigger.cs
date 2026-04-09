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
            //SceneManager.LoadSceneAsync("OutSide");
        }
    }
}
