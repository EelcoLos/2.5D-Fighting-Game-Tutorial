using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]                                     // Add audio source when attaching script
public class MainMenu : MonoBehaviour
{
    public int _selectedButton = 0;                                         // Defines selected GUI Button
    public float _timeBetweenButtonPress = 0.1f;                            // Defines delay time between button presses
    public float _timeDelay;                                                // Defines delay variable value

    public float _mainMenuVerticalInputTimer;                               // Defines vertical input timer
    public float _mainMenuVerticalInputDelay = 1f;                          // Defines vertical input delay

    public Texture2D _mainMenuBackground;                                   // Creates slot in inspector to assign main menu background

    private AudioSource _mainMenuAudio;                                     // Defines naming convention for the main menu audio Component
    public AudioClip _mainMenuMusic;                                        // Creates slot in inspector to assign main menu music
    public AudioClip _mainMenuStartButtonAudio;                             // Creates slot in inspector to assign main menu start button audio
    public AudioClip _mainMenuQuitButtonAudio;                              // Creates slot in inspector to assign main menu quit button audio

    public float _mainMenuFadeValue;                                        // Defines fade Value
    public float _mainMenuFadeSpeed = 0.15f;                                // Defines fade speed

    public float _mainMenuButtonWidth = 100f;                               // Defines main menu button width size
    public float _mainMenuButtonHeight = 25f;                               // Defines main menu button height size
    
    public float _mainMenuGUIOffset = 10f;                                  // Defines main menu GUI Offset

    private bool _startingOnePlayerGame;                                    // Defines if we are starting a one player game
    private bool _startingTwoPlayerGame;                                    // Defines if we are starting a two player game
    private bool _quittingGame;                                             // Defines if we are quitting the game

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
