using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Startup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start:");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Esc");
            OnQuit();
        }
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(50, 50, 100, 100), "Test"))
        {
            OnTest();
        }

    }

    private void OnQuit()
    {
        Application.Quit();
    }

    void OnTest()
    {
        Debug.Log("OnTest:");
        Debug.Log("OnTest:"+ DefConst.TEMP_01);

    }

}
