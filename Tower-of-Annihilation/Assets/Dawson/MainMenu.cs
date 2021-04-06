using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(60);
        PickScene();
    }

    void Start()
    {
      StartCoroutine(Wait());
    }
    public void PlayGame()
    {
        StopCoroutine(Wait());
        SceneManager.LoadScene("Introduction Scene");
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }

    void PickScene()
    {
        int scene=0;
        scene=Random.Range(0,0);

        switch (scene)
        {
            case 0:
                SceneManager.LoadScene("Demo_Mode_Pass");
                break;
            default:
                PickScene();
                break;
        }
    }
}
