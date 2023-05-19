using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoadComponent : MonoBehaviour
{
    [SerializeField] GameObject[] LevelsList;

    private GameObject currentLevel;
    bool loading = true; 
    private int levelCounter = 0; 

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadLevel());
    }

    // Update is called once per frame
    void Update()
    {
        if (currentLevel) 
        {
            HealthComponent HealthComponent = currentLevel.GetComponentInChildren<HealthComponent>();

            if (HealthComponent.GetHealth() <= 0 && loading == false) 
            {
                loading = true;
                StartCoroutine(LoadLevel());
            }
        }
    }

    public IEnumerator LoadLevel() 
    {
        
        if (currentLevel) {
            levelCounter += 1;
            yield return new WaitForSeconds(5f);
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
        loading = false;
    }

    IEnumerator WaitSeconds(int duration)
    {
        yield return new WaitForSeconds(duration);
        
    }
}
