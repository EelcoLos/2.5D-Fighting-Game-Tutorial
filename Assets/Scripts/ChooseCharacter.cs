using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

///<summary>
/// Choose character.cs
/// Eelco Los
/// 11-01-2019
/// </summary>

[RequireComponent(typeof(AudioSource))]                             // Add audio source when attaching the script
public class ChooseCharacter : ChooseCharacterManager
{

    public Texture2D _selectCharacterTextBackground;                // Creates slot in inspector to assign select character text background
    public Texture2D _selectCharacterTextForeground;                // Creates slot in inspector to assign select character text foreground
    public Texture2D _selectCharacterText;                          // Creates slot in inspector to assign select character text
    
    public Texture2D _selectCharacterArrowLeft;                     // Creates slot in inspector to assign select character arrow left
    public Texture2D _selectCharacterArrowRight;                    // Creates slot in inspector to assign select character arrow right

    private float _foregroundTextWidth;                             // Creates naming convention for foreground text width
    private float _foregroundTextHeight;                            // Creates naming convention for foreground text height
    private float _arrowSize;                                       // Creates naming convention for arrow size

    public float _chooseCharacterInputTimer;                        // Defines choose character input timer
    public float _chooseCharacterInputDelay = 1f;                   // Defines choose character input delay

    public AudioClip _cycleCharacterButtonPress;                    // creates slot in inspector to assign audio clip when cycling through the characters

    private GameObject _characterDemo;                              // Defines naming convention for selected character game object

    public int _characterSelectState;                               // Defines naming convention for selected character state
    private enum CharacterSelectModels                              // Defines which character to load
    {
        BlackRobot = 0,
        WhiteRobot = 1,
        RedRobot = 2,
        BlueRobot = 3,
        BrownRobot = 4,
        GreenRobot = 5,
        PinkRobot = 6,
        GoldRobot = 7
    }

    // Start is called before the first frame update
    void Start()
    {
        CharacterSelectManager();                                   // Call CharacterSelectManager on start up

        _foregroundTextWidth = Screen.width / 1.5f;                 // Foreground text width equals 1.5f of the screen width on start up
        _foregroundTextHeight = Screen.height / 10f;                // Foreground text height equals 10f of the screen height on start up
        _arrowSize = Screen.height / 10f;                           // Arrow size equals height divided by 10 on start up
    }

    // Update is called once per frame
    void Update()
    {
        if (_chooseCharacterInputTimer > 0)                         // if choose character input timer is greater than 0
            _chooseCharacterInputTimer -= 1f * Time.deltaTime;      // then reduce choose character input timer value

        if (_chooseCharacterInputTimer > 0)                         // if choose character input timer is greater than 0
            return;                                                 // then do nothing and return

        SelectCharacterHorizontal(-0.5f, 0.5f);
    }

    private void SelectCharacterHorizontal(float negativeThreshold, float positiveThreshold)
    {
        if (Input.GetAxis("Horizontal") < negativeThreshold ||       // if input equals horizontal less than negativeThreshold OR
                    Input.GetAxis("Horizontal") > positiveThreshold) // if input equals horizontal greater then positiveThreshold
        {
            if (Input.GetAxis("Horizontal") < negativeThreshold)     // if input equals horizontal less than negativeThreshold
            {
                if (_characterSelectState == 0)                      // if character select state equals 0
                    return;                                          // then do nothing and return

                _characterSelectState--;                             // decrease from character select state value
            }

            if (Input.GetAxis("Horizontal") > positiveThreshold)     // if input equals horizontal greater than positiveThreshold
            {
                if (_characterSelectState == 7)                      // if character select state equals 7
                    return;                                          // then do nothing and return

                _characterSelectState++;
            }

            GetComponent<AudioSource>()                              // Get component
                .PlayOneShot(_cycleCharacterButtonPress);            // and play cycle button press audio clip
                
            CharacterSelectManager();                                // and call CharacterSelectManager function
            _chooseCharacterInputTimer = _chooseCharacterInputDelay; // make choose character input timer equal to input delay
        }
    }

    void CharacterSelectManager()
    {
        switch (_characterSelectState)
        {
            case 0:
                var CharNameBlack = "BlackRobot";
                templateRobot(CharNameBlack, new Vector3(-0.5f, 0 - 7));
                _robotBlack = true;
                setCharacterResourceResourceName(CharNameBlack);
                break;
            case 1:
                const string CharNameWhite = "WhiteRobot";
                templateRobot(CharNameWhite, new Vector3(-0.5f, 0 - 7));
                _robotWhite = true;
                setCharacterResourceResourceName(CharNameWhite);
                break;
            case 2:
                const string CharNameRed = "RedRobot";
                templateRobot(CharNameRed, new Vector3(-0.5f, 0 - 7));
                setCharacterResourceResourceName(CharNameRed);
                _robotRed = true;
                break;
            case 3:
                const string CharNameBlue = "BlueRobot";
                templateRobot(CharNameBlue, new Vector3(-0.5f, 0 - 7));
                setCharacterResourceResourceName(CharNameBlue);
                _robotBlue = true;
                break;
            case 4:
                const string CharNameBrown = "BrownRobot";
                templateRobot(CharNameBrown, new Vector3(-0.5f, 0 - 7));
                setCharacterResourceResourceName(CharNameBrown);
                _robotBrown = true;
                break;
            case 5:
                const string CharNameGreen = "GreenRobot";
                templateRobot(CharNameGreen, new Vector3(-0.5f, 0 - 7));
                setCharacterResourceResourceName(CharNameGreen);
                 _robotGreen = true;
                break;
            case 6:
                const string CharNamePink = "PinkRobot";
                templateRobot(CharNamePink, new Vector3(-0.5f, 0 - 7));
                setCharacterResourceResourceName(CharNamePink);
                _robotPink = true;
                break;
            case 7:
                const string CharNameGold = "GoldRobot";
                templateRobot(CharNameGold, new Vector3(-0.5f, 0 - 7));
                setCharacterResourceResourceName(CharNameGold);
                _robotGold = true;
                break;
            //default:
        }
    }

    private void templateRobot(string charName, Vector3 position)
    {
        Debug.Log(charName);
        DestroyAndInstantiateCharacterDemo(charName, position);
        setAllRobotsFalse();
    }

    private void DestroyAndInstantiateCharacterDemo(string resourceName, Vector3 position)
    {
        DestroyObject(_characterDemo);                              // Destroy current character demo object
        _characterDemo =                                            // Character demo game object is equal to
            Instantiate(Resources.Load(resourceName))               // the resourceName fighter within our resources folder
            as GameObject;                                          // as a game object
        _characterDemo.transform.position = position;               // Set character demo position to a new vector3 at provided position
    }

    private static void setAllRobotsFalse()
    {
        _robotBlack = false;                                         // set robot black to false
        _robotWhite = false;                                         // set robot white to false
        _robotRed = false;                                           // set robot red to false
        _robotBlue = false;                                          // set robot blue to false
        _robotBrown = false;                                         // set robot brown to false
        _robotGreen = false;                                         // set robot green to false
        _robotPink = false;                                          // set robot pink to false
        _robotGold = false;                                          // set robot gold to false
    }

    /// <summary>
    /// OnGUI is called for rendering and handling GUI events.
    /// This function can be called multiple times per frame (one call per event).
    /// </summary>
    void OnGUI()
    {
        var bgrndpos = new Rect(0, 0,                               // Draw GUI Texture at this position
            Screen.width, Screen.height / 10);                      // by these dimensions
        var fgrndpos = new Rect(Screen.width /2 -                   // Draw GUI Texture at this position Z
        (_foregroundTextWidth / 2), 0,                              // at this position Y
            _foregroundTextWidth, _foregroundTextHeight);           // by these dimensions

        var arleft = new Rect(Screen.width /2 -                     // Draw GUI Texture at this position 
        (_foregroundTextWidth / 2) - _arrowSize                     // + this size on the Z
        , 0,                                                        // at this position Y
            _arrowSize, _arrowSize);                                // by these dimensions

        var arright = new Rect(Screen.width /2 +                    // Draw GUI Texture at this position Z
        (_foregroundTextWidth / 2), 0,                              // at this position Y
            _arrowSize, _arrowSize);                                // by these dimensions

        

        GUI.DrawTexture(bgrndpos, _selectCharacterTextBackground);  // and then draw this texture
        GUI.DrawTexture(fgrndpos, _selectCharacterTextForeground);  // and then draw this texture
        GUI.DrawTexture(fgrndpos, _selectCharacterText);            // and then draw this texture
        GUI.DrawTexture(arleft, _selectCharacterArrowLeft);         // and then draw this texture
        GUI.DrawTexture(arright, _selectCharacterArrowRight);       // and then draw this texture


    }
}
