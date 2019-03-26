using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterDoor : MonoBehaviour {
    private Scene currentScene;

    private void Start()
    {
        currentScene = SceneManager.GetActiveScene();
    }
     

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player"&&currentScene.name=="Town")
        {
            SceneManager.LoadScene(sceneName: "Room");
        }
        else if (other.tag == "Player" && currentScene.name == "Room")
        {
            SceneManager.LoadScene(sceneName: "Town");
        }
    }
}
