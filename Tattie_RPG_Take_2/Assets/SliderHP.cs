﻿using UnityEngine;
using UnityEngine.UI;
using RPG.Resources;

public class SliderHP : MonoBehaviour
{

    GameObject player;
    Slider slider;
    Health playerHP;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        slider = GetComponent<Slider>();
        playerHP = player.GetComponent<Health>();
        
    }


    void setText()
    {
    }
    // Update is called once per frame
    void Update()
    {
        slider.value = playerHP.getHealth();
    }
}
