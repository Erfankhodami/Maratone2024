using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Animator animator;

    public void StartGame()
    {
        SceneManager.LoadSceneAsync(1);
        animator.SetBool("Stop", true);
    }
}
