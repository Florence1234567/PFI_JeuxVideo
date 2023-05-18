using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoadComponent : MonoBehaviour
{
    [SerializeField] GameObject[] LevelsList;

    private GameObject currentLevel; 
    private int levelCounter = 0; 

    // Start is called before the first frame update
    void Start()
    {
       LoadLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LoadLevel() 
    {
        if (currentLevel) {
            Destroy(currentLevel);
        }

        currentLevel = Instantiate(LevelsList[levelCounter]);
    }
}
