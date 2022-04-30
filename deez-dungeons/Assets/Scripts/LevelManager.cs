using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void Restart()
    {
        //restart the scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //reset player position
        //save players position when game starts
        //when respawning simply reposition the player to that init position
    }
}
