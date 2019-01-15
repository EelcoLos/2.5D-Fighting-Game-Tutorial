using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

///<summary>
/// Main Menu.cs
/// Eelco Los
/// 09-01-2019
/// </summary>

[RequireComponent(typeof(AudioSource))]                                     // Add audio source when attaching script
public class MainMenu : MonoBehaviour
{
    #region variables
    [Range(0,2)]
    public int _selectedButton = 0;                                         // Defines selected GUI Button
    public float _timeBetweenButtonPress = 0.1f;                            // Defines delay time between button presses
    public float _timeDelay;                                                // Defines delay variable value

    public float _mainMenuVerticalInputTimer;                               // Defines vertical input timer
    public float _mainMenuVerticalInputDelay = 1f;                          // Defines vertical input delay

    public Texture2D _mainMenuBackground;                                   // Creates slot in inspector to assign main menu background
    public Texture2D _mainMenuTitle;                                        // Creates slot in inspector to assign main menu title

    private AudioSource _mainMenuAudio;                                     // Defines naming convention for the main menu audio Component
    public AudioClip _mainMenuMusic;                                        // Creates slot in inspector to assign main menu music
    public AudioClip _mainMenuStartButtonAudio;                             // Creates slot in inspector to assign main menu start button audio
    public AudioClip _mainMenuQuitButtonAudio;                              // Creates slot in inspector to assign main menu quit button audio

    [Range(0f,2f)]
    public float _mainMenuFadeValue;                                        // Defines fade Value
    public float _mainMenuFadeSpeed = 0.35f;                                // Defines fade speed

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

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        _startingOnePlayerGame = false;                                     // Starting one player game is false on start up
        _startingTwoPlayerGame = false;                                     // Starting two player game is false on start up
        _quittingGame = false;                                              // Quitting is false on start up

        _ps4Controller = false;                                             // PS4 controller is false on start up
        _xBoxController = false;                                            // XBox controller is false on start up

        _mainMenuFadeValue = 0;                                             // fade value is set to 0 on start up

        _mainMenuAudio = GetComponent<AudioSource>();                       // _mainMenuAudio equals the audio source component
        _mainMenuAudio.volume = 0;                                          // Audio Volume equals 0 on start up
        _mainMenuAudio.clip = _mainMenuMusic;                               // audio clip equals main menu music
        _mainMenuAudio.loop = true;                                         // Set audio to loop
        _mainMenuAudio.Play();                                              // Play the audio
        _mainMenuController = MainMenuController.MainMenuFadeIn;            // State equals fade in on start up

        StartCoroutine("MainMenuManager");                                  // Start MainMenuManager on start up
    }

    // Update is called once per frame
    void Update()
    {
        var _joyStickNames = Input.GetJoystickNames();                      // _joyStickNames equals joystick names from inbuilt input

        for (int i = 0; i < _joyStickNames.Length; i++)                     // i equals the joysticknames length
        {
            if(_joyStickNames[i].Length == 0)                               // if joystick names equals zero (if no controller attached)
                return;                                                     // then do nothing and return
            
            if (_joyStickNames[i].Length == 19)                             // if joystick names equals 19 (PS4 controller)
                _ps4Controller = true;                                      // then set ps4controller to true 
            if (_joyStickNames[i].Length == 33)                             // if joystick names equals 33 (XBox controller)
                _xBoxController = true;                                     // then set xboxcontroller to true 
        }

        if (_mainMenuVerticalInputTimer > 0)                                // if vertical input timer is greater than 0
            _mainMenuVerticalInputTimer -=1f * Time.deltaTime;              // then reduce vertical input timer

        float v = Input.GetAxis("Vertical");

        #region video tutorial intent
        /*
        if (v > 0f && _selectedButton == 0)                                 // if input equals vertical (positive) and selected button equals 0
            return;                                                         // then do nothing
        
        if (v > 0f && _selectedButton == 1)                                 // if input equals vertical (positive) and selected button equals 1
        {
            if (_mainMenuVerticalInputTimer > 0)                            // if vertical input is greater than 0
                return;                                                     // then do nothing
                                                                            // else
            _mainMenuVerticalInputTimer = _mainMenuVerticalInputDelay;      // make vertical input timer equals to input delay
            _selectedButton = 0;                                            // and make selected button equal to 0
        }

        if (v > 0f && _selectedButton == 2)                                 // if input equals vertical (positive) and selected button equals 2
        {
            if (_mainMenuVerticalInputTimer > 0)                            // if vertical input is greater than 0
                return;                                                     // then do nothing
                                                                            // else
            _mainMenuVerticalInputTimer = _mainMenuVerticalInputDelay;      // make vertical input timer equals to input delay
            _selectedButton = 1;                                            // and make selected button equal to 1
        }

        if (v < 0f && _selectedButton == 0)                                 // if input equals vertical (negative) and selected button equals 0
        {
            if (_mainMenuVerticalInputTimer > 0)                            // if vertical input is greater than 0
                return;                                                     // then do nothing
                                                                            // else
            _mainMenuVerticalInputTimer = _mainMenuVerticalInputDelay;      // make vertical input timer equals to input delay
            _selectedButton = 1;                                            // and make selected button equal to 1
        }

        if (v < 0f && _selectedButton == 1)                                 // if input equals vertical (negative) and selected button equals 1
        {
            if (_mainMenuVerticalInputTimer > 0)                            // if vertical input is greater than 0
                return;                                                     // then do nothing
                                                                            // else
            _mainMenuVerticalInputTimer = _mainMenuVerticalInputDelay;      // make vertical input timer equals to input delay
            _selectedButton = 2;                                            // and make selected button equal to 2
        }
        */


        // if (v < 0f)                                                         // if input equals vertical (positive) and selected button equals 2
        //     return;                                                         // then do nothing
                #endregion

        if (v != 0f)
        {
            if (_mainMenuVerticalInputTimer > 0)                            // if vertical input timer is greater than 0
                return;                                                     // then do nothing
                                                                            // else
            _mainMenuVerticalInputTimer = _mainMenuVerticalInputDelay;      // make vertical input timer equals to input delay
            var mathres = CalculateSelectedButton(v);
            _selectedButton = mathres;
        }
    }

    private int CalculateSelectedButton(float v)
    {
        var upOrDown = v > 0 ? Mathf.CeilToInt(v) : Mathf.FloorToInt(v);
        var inverted = upOrDown * -1;
        var mathres = _selectedButton += inverted;
        if (mathres < 0)                                                    // Tried this via the RangeAttribute, but didn't find a solution
        {
            mathres = _mainMenuButtons.Length - 1;
        }
        else if (mathres > _mainMenuButtons.Length)
        {
            mathres = 0;
        }
        return mathres;
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
        //Debug.Log("MainMenuFadeIn");

        _mainMenuAudio.volume += _mainMenuFadeSpeed * Time.deltaTime;       // increase volume by the fade speed
        _mainMenuFadeValue += _mainMenuFadeSpeed * Time.deltaTime;          // increase fade value by the fade speed

        if(_mainMenuFadeValue >= 1)                                         // if fade value is greater than 1
        {
            _mainMenuFadeValue = 1;                                         // then make fade value equal to 1
        }
        if(_mainMenuFadeValue == 1)                                         // if fade value equals 1
        {
            _mainMenuController = MainMenuController.MainMenuAtIdle;        // then make state equal to main menu at idle
        }
    }
    private void MainMenuAtIdle()
    {
        //Debug.Log("MainMenuAtIdle");

        if (_startingOnePlayerGame == true || _quittingGame == true)        // if starting one player game OR quitting equals true
            _mainMenuController = MainMenuController.MainMenuFadeOut;       // then make state equals to main menu fade out
    }
    private void MainMenuFadeOut()
    {
        //Debug.Log("MainMenuFadeOut");
        _mainMenuAudio.volume -= _mainMenuFadeSpeed * Time.deltaTime;       // decrease volume by the fade speed
        _mainMenuFadeValue -= _mainMenuFadeSpeed * Time.deltaTime;          // decrease fade value by the fade speed

        if(_mainMenuFadeValue < 0)                                          // if fade value is greater than 0
            _mainMenuFadeValue = 0;                                         // then make fade value equal to 0
        
        if (_mainMenuFadeValue == 0 && _startingOnePlayerGame)              // if fade value equals 0 AND starting one player game is equal to true
            SceneManager.LoadScene("ChooseCharacter");                      // Load choose character scene
    }

    private void MainMenuButtonPress()
    {
        Debug.Log("MainMenuButtonPress");
        GUI.FocusControl(_mainMenuButtons[_selectedButton]);

        switch (_selectedButton)
        {
            case 0:
                _mainMenuAudio.PlayOneShot(_mainMenuStartButtonAudio);      // play start button audio clip
                _startingOnePlayerGame = true;                              // set starting one player game to true
                break;
            case 1:
                _mainMenuAudio.PlayOneShot(_mainMenuStartButtonAudio);      // play start button audio clip
                _startingTwoPlayerGame = true;                              // set starting two player game to true
                break;
            case 2:
                _mainMenuAudio.PlayOneShot(_mainMenuQuitButtonAudio);       // play quit button audio clip
                _quittingGame = true;                                       // set quit game to true
                break;
        }
    }

    /// <summary>
    /// OnGUI is called for rendering and handling GUI events.
    /// This function can be called multiple times per frame (one call per event).
    /// </summary>
    public void OnGUI()
    {
        try
        {
            if (Time.deltaTime >= _timeDelay && (Input.GetButtonDown("Fire1"))) // if time is greater than or equals our time delay AND input equals "fire1"
            {
                StartCoroutine("MainMenuButtonPress");                          // then start MainMenuButtonPress function
                _timeDelay = Time.deltaTime + _timeBetweenButtonPress;          // and then make the time delay equal current time plus timebetweenbuttonpress
            }

            Rect rect = new Rect(0, 0, Screen.width, Screen.height);            // Draw texture at position by these dimenions
            GUI.DrawTexture(rect, _mainMenuBackground);                         // and draw this texture

            GUI.DrawTexture(rect, _mainMenuTitle);

            GUI.color = new Color(1,1,1, _mainMenuFadeValue);                   // GUI color is equal to (1 1 1 rgb) plus the fade value (alpha)

            GUI.BeginGroup(new Rect(                                            // Begin GUI Group
                Screen.width/2-_mainMenuButtonWidth/2,                          // at this position X
                Screen.height/1.5f,                                             // at this position Y
                _mainMenuButtonWidth,                                           // by this dimension X
                _mainMenuButtonHeight*3 + _mainMenuGUIOffset * 2));             // by this dimension Y

                GUI.SetNextControlName("_onePlayer");                           // Set name to one player
                if (GUI.Button(new Rect(                                        // Create button
                    0,0,                                                        // at this position within the gui group
                    _mainMenuButtonWidth, _mainMenuButtonHeight),               // at these dimension
                    "One Player"))
                    {
                        _selectedButton = 0;                                    // set selected button to 0
                        MainMenuButtonPress();                                  // Call MainMenuButtonPress function
                    }

                GUI.SetNextControlName("_twoPlayer");                           // Set name to two player
                if (GUI.Button(new Rect(                                        // Create button
                    0,_mainMenuButtonHeight + _mainMenuGUIOffset,               // at this position within the gui group
                    _mainMenuButtonWidth, _mainMenuButtonHeight),               // at these dimension
                    "Two Player"))
                    {
                        _selectedButton = 1;                                    // set selected button to 1
                        MainMenuButtonPress();                                  // Call MainMenuButtonPress function
                    }

                GUI.SetNextControlName("_quit");                                // Set name to quit
                if (GUI.Button(new Rect(                                        // Create button
                    0,_mainMenuButtonHeight* 2 + _mainMenuGUIOffset * 2,        // at this position within the gui group
                    _mainMenuButtonWidth, _mainMenuButtonHeight),               // at these dimension
                    "Quit"))
                    {
                        _selectedButton = 2;                                    // set selected button to 2
                        MainMenuButtonPress();                                  // Call MainMenuButtonPress function
                    }                                                   

            GUI.EndGroup();                                                     // End GUI Group

            if (_ps4Controller == true || _xBoxController == true)                              // if ps4 controller OR xbox controller equals true
            {
                try
                {
                    GUI.FocusControl(_mainMenuButtons[_selectedButton]);            // then focus equals main menu selected button
                }
                catch (System.IndexOutOfRangeException iex)
                {
                    Debug.LogErrorFormat("Index OOB: selectedbutton: {0}, error: {1}", _selectedButton, iex);
                }
                
            }
            
        }
        catch (System.Exception ex)
        {
            Debug.LogError(ex);
        }
        
    }
}
