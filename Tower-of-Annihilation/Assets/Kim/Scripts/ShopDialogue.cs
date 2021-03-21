/* 
    ------------------- Code Monkey -------------------

    Thank you for downloading this package
    I hope you find it useful in your projects
    If you have any questions let me know
    Cheers!

               unitycodemonkey.com
    --------------------------------------------------
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;

public class ShopDialogue : MonoBehaviour
{

    public Text messageText;
    public Transform dialogueBox;
    private TextWriter.TextWriterSingle textWriterSingle;

    private void Awake()
    {
        //messageText = transform.Find("message").Find("dialogueText").GetComponent<Text>();
        int counter = 0;
        int boredCounter = 0;
        string message = "";
        //transform.Find("message").GetComponent<Button_UI>().ClickFunc = () => {
        dialogueBox.GetComponent<Button_UI>().ClickFunc = () => {
            if (textWriterSingle != null && textWriterSingle.IsActive())
            {
                // Currently active TextWriter
                textWriterSingle.WriteAllAndDestroy();
            }
            else
            {
                string[] messageArray = new string[] {
                    "Hey, you aren't from around here, are you?",
                    "...you're looking for a princess?",
                    "Haven't seen one around here since...forever. I haven't been outside since that one plague anyway. What was it? COVI-",
                    "Anyway, I think the dragon ruling this tower has a fancy for capturing royalty.",
                    "Why? Don't ask me. But there is surely no malicious intent behind it.",
                    "Nevermind that. Do you have some coins?",
                    "Yeah, I've got rent to pay too you know? There's been some mild inflation nowadays.",
                    "I even have an exam to study for...you too? Uh, what's software engineering?",
                    "Also, have you seen a flying spagetti monster anywhere? I'm hungry.",
                    "Stay safe, generic-protagonist-of-the-day. (snicker)"
                };
                //string message = messageArray[Random.Range(0, messageArray.Length)];
                if (counter != messageArray.Length)
                {
                    message = messageArray[counter];
                    ++counter;
                }
                if (counter == messageArray.Length & boredCounter < 5)
                {
                    counter = 0;
                    boredCounter++;
                }
                else if (boredCounter >= 5)
                {
                    message = "Hey. I know you like listening to me. But don't you have something better to do? Seriously.";
                }
                textWriterSingle = TextWriter.AddWriter_Static(messageText, message, .02f, true, true);
            }
        };
    }

    private void Start()
    {
        //TextWriter.AddWriter_Static(messageText, "This is the assistant speaking, hello and goodbye, see you next time!", .1f, true);
    }

}

