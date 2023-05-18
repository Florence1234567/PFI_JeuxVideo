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
        if (currentLevel) 
        {
            HealthComponent HealthComponent = currentLevel.GetComponent<HealthComponent>();

            if (HealthComponent.GetHealth() <= 0) 
            {
                levelCounter += 1;
                LoadLevel();
            }
        }
    }

    private void LoadLevel() 
    {
        if (currentLevel) {
            Destroy(currentLevel);
        }

        currentLevel = Instantiate(LevelsList[levelCounter]);

        GameObject player = GameObject.FindWithTag("Player");
        GameObject spawnPoint = GameObject.FindWithTag("Respawn");

        if (player != null && spawnPoint != null)
        {
            player.transform.position = spawnPoint.transform.position;
            player.transform.rotation = spawnPoint.transform.rotation;
        }

    }
}
