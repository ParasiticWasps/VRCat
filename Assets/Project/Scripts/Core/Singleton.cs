using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T m_Instance;

    public static T Get()
    {
        if (m_Instance == null)
        {
            m_Instance = FindObjectOfType<T>(true);
        }
        return m_Instance;
    }
}
