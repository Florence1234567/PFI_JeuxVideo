using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageGrenadeCount : MonoBehaviour
{
    [SerializeField] TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateGrenadeCount(float grenadeCount)
    {
        if(grenadeCount <= 0)
            SceneManager.LoadScene(0);

        text.text = $"{grenadeCount}";
    }
}
