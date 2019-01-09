using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]                                     // Add audio source when attaching script
public class MainMenu : MonoBehaviour
{
    private bool _ps4Controller;                                            // Creates bool when a PS4 Controller is connected
    private bool _xBoxController;                                           // Creates bool when a XBox Controller is connected

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
        _ps4Controller = false;                                             // PS4 controller is false on start up
        _xBoxController = false;                                            // XBox controller is false on start up
        
        _mainMenuController = MainMenuController.MainMenuFadeIn;            // State equals fade in on start up

        StartCoroutine("MainMenuManager");                                  // Start MainMenuManager on start up
    }

    // Update is called once per frame
    void Update()
    {
    }

    private IEnumerator MainMenuManager()
    {
        while (true)
        {
            switch (_mainMenuController)
            {
                case MainMenuController.MainMenuFadeIn:
                    MainMenuFadeIn();
                    break;
                case MainMenuController.MainMenuAtIdle:
                    MainMenuAtIdle();
                    break;
                case MainMenuController.MainMenuFadeOut:
                    MainMenuFadeOut();
                    break;
            }
            yield return null;
        }
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
