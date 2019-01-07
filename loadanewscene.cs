using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadanewscene : MonoBehaviour
{
    public string sceneName;
    // Use this for initialization
    void Start()
    {
        SceneManager.LoadScene(sceneName);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
