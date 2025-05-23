using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSpawnAtBed : MonoBehaviour
{
    public void SetSpawnPoint()
    {
        PlayerPrefs.SetString("Spawnpoint", "Bed");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
    }
}
