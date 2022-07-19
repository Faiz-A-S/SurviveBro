using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UImanager : MonoBehaviour
{
    public Spawner enemyManager;
    public PlayerManager player;

    public TextMeshProUGUI enemyLeftText;
    public TextMeshProUGUI waveText;
    public TextMeshProUGUI healthText;
    // Start is called before the first frame update
    void Start()
    {
        //enemyLeftText = GetComponentInChildren<TextMeshProUGUI>();
        //waveText = GetComponentInChildren<TextMeshProUGUI>();
        //healthText = GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyLeftText.text = enemyManager.enemyOnField.ToString();
        waveText.text = enemyManager.wave.ToString();
        healthText.text = player.health.ToString();
    }
}
