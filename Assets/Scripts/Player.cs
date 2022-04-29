using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] float playerHealth = 100;
    [SerializeField] Text playerHPText;


    // Start is called before the first frame update
    void Start()
    {
        playerHPText.text = playerHealth.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(float damage)
    {
        playerHealth -= damage;
        playerHPText.text = playerHealth.ToString();
        if (playerHealth <= 0)
        {
            PlayerDeath();
        }
    }

    private void PlayerDeath()
    {
        SceneManager.LoadScene(0);
    }
    // Cursor.lockState = CursorLockMode.none;
    //Cursor.visible = true;
}
