using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UImanager : MonoBehaviour
{
    public Spawner enemyManager;
    public TextMeshProUGUI enemyLeftText;
    public TextMeshProUGUI waveText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemyLeftText.text = enemyManager.enemyOnField.ToString();
        waveText.text = enemyManager.wave.ToString();
    }
}
