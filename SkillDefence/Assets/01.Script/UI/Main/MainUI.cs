using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainUI : MonoBehaviour
{
    public Button stage;
    public Button character;
    public Button map;
    public Button shop;

    // Start is called before the first frame update
    void Start()
    {
        stage.onClick.AddListener(() => goStage());        
        character.onClick.AddListener(() => goCharacter());    
        map.onClick.AddListener(() => goMap());    
        shop.onClick.AddListener(() => goShop());    
    }

    private void goShop()
    {
        SceneManager.LoadScene("Shop");
    }

    private void goMap()
    {
        SceneManager.LoadScene("Map");
    }

    private void goCharacter()
    {
        SceneManager.LoadScene("CheckUnit");
    }

    private void goStage()
    {
        SceneManager.LoadScene("Taehyen");
    }
}
