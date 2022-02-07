using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    // Handle the event when clicking the Start button
    public void clickStartButton()
    {
        Debug.Log("Starting the simulation...");
    }

    // Handle the event when clicking the Quit button
    public void clickQuitButton()
    {
        Debug.Log("Quitting...");
        Application.Quit();
    }
}
