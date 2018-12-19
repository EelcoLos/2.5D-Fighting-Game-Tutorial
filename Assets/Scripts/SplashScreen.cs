using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SplashScreenFadeIn()
    {
        Debug.Log("SplashScreenFadeIn");
    }

    private void SplashScreenFadeOut()
    {
        Debug.Log("SplashScreenFadeOut");
    }
}
