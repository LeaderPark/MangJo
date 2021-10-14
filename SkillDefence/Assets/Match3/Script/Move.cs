using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Move : MonoBehaviour
{
    public Image img;

    private void Update()
    {
            float x1 = img.GetComponent<RectTransform>().anchoredPosition.x;
            x1 += 1f;
            img.GetComponent<RectTransform>().anchoredPosition = new Vector3(x1, 0);
    }
}