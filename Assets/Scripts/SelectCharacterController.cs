using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectCharacterController : MonoBehaviour
{
    public static SelectCharacterController instance;
    [SerializeField] private bool isPj1 = false;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void OnButtonPressed(bool isPj1)
    {
        this.isPj1 = isPj1;
        SceneManager.LoadScene("SampleScene");
    }

    public Boolean isPj1Selected() { return isPj1; }
}
