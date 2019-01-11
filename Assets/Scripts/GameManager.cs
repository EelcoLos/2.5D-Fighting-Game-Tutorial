using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        Cursor.visible = false;                                                     // Set visible to false on awake
        Cursor.lockState = CursorLockMode.Locked;                                   // and lock the cursor on awake as well
    }
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);                                                    // Don't destroy this gameobject when loading a new scene
    }
}
