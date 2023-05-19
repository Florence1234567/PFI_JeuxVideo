using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ManageLevel : MonoBehaviour
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

    public void UpdateLevelCount(float levelCount)
    {
        text.text = $"{levelCount}";
    }
}
