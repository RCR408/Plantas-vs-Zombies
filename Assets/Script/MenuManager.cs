using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Manager managerScript;
    [SerializeField] private GameObject[] uiObjects;
    [SerializeField] private GameObject menuObjects;

    public void StartGame()
    {
        managerScript.isStart = true;

        for(int i = 0; i < uiObjects.Length; i++)
        {
            uiObjects[i].SetActive(true);
        }
        
        menuObjects.SetActive(false);
    }
}
