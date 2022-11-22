using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public int sceneNumber;

    private void OnTriggerEnter(Collider other) {
        SceneManager.LoadScene(sceneNumber);
    }
}
