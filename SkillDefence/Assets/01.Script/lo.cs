using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class lo : MonoBehaviour
{
    public Button start;

    private void Start() {
        start.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("MainLoby");
        });
    }
}
