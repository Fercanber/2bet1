using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadSceneUlibsync()
    {
        SceneManager.LoadScene("UlibSync");
    }

    public void LoadSceneMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
