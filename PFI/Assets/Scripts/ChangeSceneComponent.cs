using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneComponent : MonoBehaviour
{
    public void ChangeScene()
    {
        SceneManager.LoadScene(0);
    }
}
