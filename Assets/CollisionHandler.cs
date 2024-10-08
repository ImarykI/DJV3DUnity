using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    [SerializeField] float loadDelay = 1.0f;
    private void OnTriggerEnter(Collider other)
    {
        StartCrashSequence(other);
    }

    void StartCrashSequence(Collider other)
    {
        if (other.gameObject.name == "Terrain") return;
            
        GetComponent<PlayerControls>().enabled = false;
        Invoke("ReloadScene", loadDelay);
    }

    void ReloadScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

}
