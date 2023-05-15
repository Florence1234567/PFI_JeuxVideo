using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour
{
    [SerializeField] private GameObject muzzleFlash;

    private Animator Animator;
    private AudioSource FireAudio;
    private AudioSource ReloadAudio;
    public GameObject FirePoint;
    void Awake()
    {
       Animator = GetComponent<Animator>(); 
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FireAnimation()
    {
        
    }
}
