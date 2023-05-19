using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoadComponent : MonoBehaviour
{
    [SerializeField] GameObject[] LevelsList;

    ManageLevel manageLevel;

    private GameObject currentLevel;
    bool loading = false; 
    private int levelCounter = 0; 

    // Start is called before the first frame update
    void Start()
    {
        manageLevel = GameObject.FindWithTag("ManageUI").GetComponent<ManageLevel>();

        LoadLevel();
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
        // si nous ne sommes pas au dernier niveau. 
        if (LevelsList.Length > levelCounter) 
        {
            // si nous sommes déjà à l'intérieur d'un niveau
            if (currentLevel) 
            {
                levelCounter += 1;
                manageLevel.UpdateLevelCount(levelCounter);
                yield return new WaitForSeconds(3f);
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
        else 
        {
            SceneManager.LoadScene(3);
        }

        loading = false;
    }
}
