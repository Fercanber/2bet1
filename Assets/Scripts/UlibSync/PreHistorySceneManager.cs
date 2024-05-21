using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PreHistorySceneManager : MonoBehaviour
{
    public GameObject jugador;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("GoToNextScene", 6);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void GoToNextScene()
    {
        // Obtén el componente Animator
        Animator animator = jugador.GetComponent<Animator>();

        // Obtén el estado de la animación actual
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        // Detén la animación actual
        animator.Play(stateInfo.fullPathHash, -1, 0);
        SceneManager.LoadScene("HistoryExplanation");
    }
}
