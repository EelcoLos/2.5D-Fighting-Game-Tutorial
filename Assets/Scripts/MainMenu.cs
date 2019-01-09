using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]                                     // Add audio source when attaching script
public class MainMenu : MonoBehaviour
{

    private string[] _mainMenuButtons = new string[]                        // Creates an array of GUI Buttons for the main menu scene
    {
        "_onePlayer",
        "_twoPlayer",
        "_quit"
    };

    private MainMenuController _mainMenuController;                         // Defines naming convention for main menu controller
    private enum MainMenuController                                         // Defines states main menu can exist in
    {
        MainMenuFadeIn = 0,
        MainMenuAtIdle = 1,
        MainMenuFadeOut = 2
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void MainMenuFadeIn()
    {
        Debug.Log("MainMenuFadeIn");
    }
    private void MainMenuAtIdle()
    {
        Debug.Log("MainMenuAtIdle");
    }
    private void MainMenuFadeOut()
    {
        Debug.Log("MainMenuFadeOut");
    }

    private void MainMenuButtonPress()
    {
        Debug.Log("MainMenuButtonPress");
    }
}
