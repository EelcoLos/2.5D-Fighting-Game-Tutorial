using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
/// Controller manager.cs
/// Eelco Los
/// 03-01-2019
/// </summary>

public class ControllerManager : MonoBehaviour
{
    public Texture2D _controllerNotDetected;                                // Creates slot in inspector to assign controller not detected warning text

    public bool _pS4Controller;                                             // Creates a boolean for when a ps4 controller is connected
    public bool _xBOXController;                                            // Creates a boolean for when a xbox controller is connected
    public bool _controllerDetected;                                        // Creates a boolean for when a controller is connected

    public static bool _startupFinished;                                    // Creates a boolean for when startup is finished

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        _pS4Controller = false;                                             // PS4 controller is false on awake
        _xBOXController = false;                                            // XBox controller is false on awake
        _controllerDetected = false;                                        // Controller is false on awake

        _startupFinished = false;                                           // Start up finished is false on awake
    }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);                                            // Don't destroy this game object when loading a new scene
    }

    // LateUpdate is called once per second
    void LateUpdate()
    {
        
    }

    private void OnGUI()
    {
        if (!_startupFinished || _controllerDetected)                       // if startup finished equals false or controller detected equals true
        {
            return;                                                         // then do nothing and return
        }
        
        if (!_controllerDetected)                                           // if controller detected equals false
        {
            Rect position = new Rect(0, 0, Screen.width, Screen.height);    // Draw a texture at this position by these dimensions
            GUI.DrawTexture(position, _controllerNotDetected);              // draw the controller not detected texture
        }
    }
}
