using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ongamestart : MonoBehaviour
{
    public GameObject m_camera;
    public GameObject g_camera;
    [RuntimeInitializeOnLoadMethod]

    static void OnRuntimeMethodLoad()
    {
        m_camera.SetActive(false);
        g_camera.SetActive(true);
        WaitForSeconds(2)
        g_camera.SetActive(false);
        m_camera.SetActive(true);
    }
}
