using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fade_volume : MonoBehaviour
{
    public AudioSource music_menu;
    // Start is called before the first frame update
    void Start()
    {
        music_menu.volume = 0;
    }

    // Update is called once per frame
    void Update()
    {
        music_menu.volume += 0.1f*Time.deltaTime;
    }
}
