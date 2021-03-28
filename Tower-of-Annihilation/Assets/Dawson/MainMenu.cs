using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private IEnumerator wait()
    {
        yield return new WaitForSeconds(60);
        pickScene();
    }

    void Start()
    {
      StartCoroutine(wait());
    }
    public void PlayGame()
    {
        StopCoroutine(wait());
        SceneManager.LoadScene("Introduction Scene");
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }

    void pickScene()
    {
        int scene=0;
        scene=Random.Range(0,0);

        switch (scene)
        {
            case 0:
                SceneManager.LoadScene("Demo_Mode_Pass");
                break;
            default:
                pickScene();
                break;
        }
    }
}
