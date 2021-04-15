using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;
using UnityEngine.SceneManagement;

public class DragonDialogue : MonoBehaviour
{
    public Text dMessageText;
    public Transform dDialogueBox;
    private TextWriter.TextWriterSingle textWriterSingle;

    private void Awake()
    {
        ///messageText = transform.Find("message").Find("dialogueText").GetComponent<Text>();
        int counter = 0;
        int boredCounter = 0;
        string message = "";
        //transform.Find("message").GetComponent<Button_UI>().ClickFunc = () => {
        dDialogueBox.GetComponent<Button_UI>().ClickFunc = () => {
            if (textWriterSingle != null && textWriterSingle.IsActive())
            {
                // Currently active TextWriter
                textWriterSingle.WriteAllAndDestroy();
            }
            else
            {
                string[] messageArray = new string[] {
                    "So you are the mortal that has been trashing this dungeon.",
                    "And you're doing this all for a simple bounty. Tsk.",
                    "You want your princess back? Fight me with all your might then."
                };
                //string message = messageArray[Random.Range(0, messageArray.Length)];
                if (counter != messageArray.Length)
                {
                    message = messageArray[counter];
                    ++counter;
                }
                if (counter == messageArray.Length)
                {
                    counter = 0;
                }
                textWriterSingle = TextWriter.AddWriter_Static(dMessageText, message, .02f, true, true);
            }
        };
    }

    private void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        // Retrieve the name of this scene.
        string sceneName = currentScene.name;

        if (sceneName == "Boss Scene")
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);

        }
    }

}
