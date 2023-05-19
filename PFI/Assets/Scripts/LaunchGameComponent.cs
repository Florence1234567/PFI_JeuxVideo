using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class LaunchGameComponent : MonoBehaviour
{
    [SerializeField] InputAction launchAction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        launchAction.Enable();
    }

    private void OnDisable()
    {
        launchAction.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        if (launchAction.IsPressed())
            LaunchGame();
    }

    void LaunchGame()
    {
        SceneManager.LoadScene(2);
    }
}
