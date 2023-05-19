using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoadComponent : MonoBehaviour
{
    [SerializeField] GameObject[] LevelsList;

    ManageLevel manageLevel;

    private GameObject currentLevel;
    private int levelCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        manageLevel = GameObject.FindWithTag("ManageUI").GetComponent<ManageLevel>();

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
                manageLevel.UpdateLevelCount(levelCounter);
                LoadLevel();
            }
        }
    }

    private void LoadLevel()
    {
        if (currentLevel)
        {
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

    public float GetLevelCount()
    {
        return levelCounter;
    }
}
