using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public void ExitShop(){
        SceneManager.LoadScene(0);
    }
}
