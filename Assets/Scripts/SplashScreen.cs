using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

///<summary>
/// Splash Screen.cs
/// Eelco Los
/// 19-12-2018
/// </summary>


[RequireComponent(typeof(AudioSource))]                     // Add audio source when attaching the script
public class SplashScreen : MonoBehaviour
{

    public Texture2D _splashScreenBackground;               // Creates slot in inspector to assign splash screen background image
    public Texture2D _splashScreenText;                     // Creates slot in inspector to assign splash screen text

    private AudioSource _splashScreenAudio;                 // Defines naming convention for audio source component
    public AudioClip _splashScreenMusic;                    // Create slot in inspector to assign splash screen music

    private float _splashScreenFadeValue;                   // Defines fade value
    private float _splashScreenFadeSpeed = 0.15f;           // Defines fade speed

    private SplashScreenController _splashScreenController; // Defines naming convention for splash screen controller

    private enum SplashScreenController                     // Defines states for splash screen
    {
        SplashScreenFadeIn = 0,
        SplashScreenFadeOut = 1
    }


    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        _splashScreenFadeValue = 0;                         // Fade value equals zero on start up
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;                             // Set the cursor visible state to false
        Cursor.lockState = CursorLockMode.Locked;           // and lock the cursor

        _splashScreenAudio = GetComponent<AudioSource>();   // Splash screen audio equals the audio source
        _splashScreenAudio.volume = 0;                      // audio volume equals zero on startup
        _splashScreenAudio.clip = _splashScreenMusic;       // Audio clip equals splash screen music
        _splashScreenAudio.loop = true;                     // Set Audio Loop
        _splashScreenAudio.Play();                          // Play Audio

        _splashScreenController =                           // State equals
    SplashScreen.SplashScreenController.SplashScreenFadeIn; // fade in on start up

        StartCoroutine("SplashScreenManager");              // Start SplashScreenManager function
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SplashScreenManager()
    {
        while (true)
        {
            switch (_splashScreenController)
            {
                case SplashScreenController.SplashScreenFadeIn:
                    SplashScreenFadeIn();
                    break;
                case SplashScreenController.SplashScreenFadeOut:
                    SplashScreenFadeOut();
                    break;
            }
            yield return null;
        }
        
    }

    private void SplashScreenFadeIn()
    {
        Debug.Log("SplashScreenFadeIn");
        _splashScreenAudio.volume += _splashScreenFadeSpeed * Time.deltaTime;   // increase volume by the fade speed
        _splashScreenFadeValue += _splashScreenFadeSpeed * Time.deltaTime;      // increase fade value by fade speed

        if (_splashScreenFadeValue > 1)                                         // if fade value is greater than 1
        {
            _splashScreenFadeValue = 1;                                         // then set fade value to 1
        }

        if(_splashScreenFadeValue == 1)                                         // if fade value equals one
        {
            _splashScreenController =                                           // Set Splash screen controller to equal
                SplashScreen.SplashScreenController.SplashScreenFadeOut;        // Splash Screen fade out
        }
    }

    private void SplashScreenFadeOut()
    {
        Debug.Log("SplashScreenFadeOut");
        _splashScreenAudio.volume -= _splashScreenFadeSpeed * Time.deltaTime;   // decrease volume by the fade speed
        _splashScreenFadeValue -= _splashScreenFadeSpeed * Time.deltaTime;      // decrease fade value by fade speed

        if (_splashScreenFadeValue < 0)                                         // if fade value is greater than 0
        {
            _splashScreenFadeValue = 0;                                         // then set fade value to 0
        }

        if (_splashScreenFadeValue == 0)                                        // if fade value equals zero
        {
            SceneManager.LoadScene("ControllerWarning");                        // load scene ControllerWarning
        }
    }

    /// <summary>
    /// OnGUI is called for rendering and handling GUI events.
    /// This function can be called multiple times per frame (one call per event).
    /// </summary>
    /// <remarks> With 2018.3.0f2, not using try-catch in this method will result in Unity crashing. </remarks>
    private void OnGUI()
    {
        try
        {
            Rect position = new Rect(0, 0, Screen.width, Screen.height);            // Draw texture starting at 0/0 by the screen width and height
            GUI.DrawTexture(position, _splashScreenBackground);                     // and draw the background texture
            GUI.color = new Color(1,1,1,_splashScreenFadeValue);                    // GUI color is equal to (1 1 1) plus the fade value
            GUI.DrawTexture(position, _splashScreenText);                           // Draw splash screen text
        }
        catch (System.Exception ex)
        {
            Debug.LogError(ex);
        }
    }
}
