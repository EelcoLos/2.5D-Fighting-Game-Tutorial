using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundManager : MonoBehaviour
{
    public string _selectedBackground = "";                             // Defines which background is currently selected
    public int _backgroundCounter;                                      // Defines numerical counter for our background

    public string[] _backgroundScenes = new string[]                    // Create array of backgrounds
    {
        "Scene0",
        "Scene1",
        "Scene2",
        "Scene3",
        "Scene4",
        "Scene5",
        "Scene6",
        "Scene7"
    };
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);                                        // Don't destroy this gameobject when loading a new scene

        _backgroundCounter = 0;                                         // set background counter to 0 on start up
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SceneBackgroundManager()
    {
        Debug.Log("SceneBackgroundManager");

        if (_backgroundCounter < _backgroundScenes.Length)              // if backgroundcounter is less than background scenes length
            _backgroundCounter++;                                       // then increase the background counter
        if (_backgroundCounter == _backgroundScenes.Length)             // if backgroundcounter equal to background scenes length
            _backgroundCounter = 0;                                     // then reset the background counter to 0

        _selectedBackground = _backgroundScenes[_backgroundCounter];    // selected background is equals to the background scenes based on background counter value
    }

    private void SceneBackgroundLoad()
    {
        Debug.Log("SceneBackgroundLoad");
        SceneManager.LoadScene(_selectedBackground);                    // Load scene that is based on the selected background value
    }
}
