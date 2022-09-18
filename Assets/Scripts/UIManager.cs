using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    //private PlayerController playerController;
    public GameObject gameOverMenu;

    //private void Start()
    //{
    //    playerController = FindObjectOfType<PlayerController>();
    //}
    private void OnEnable()
    {
        PlayerController.OnPlayerDeath += EnableGameOverMenu;
    }

    private void OnDisable()
    {
        PlayerController.OnPlayerDeath -= EnableGameOverMenu;
    }

    public void EnableGameOverMenu()
    {
        gameOverMenu.SetActive(true);
    }
    
}
