using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonRefill : MonoBehaviour
{
    [SerializeField] private Manager manager;

    [SerializeField] private int plantTarget;

    [SerializeField] private Image chargeImage;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        chargeImage.fillAmount = manager.plantsTimer[plantTarget]/ manager.plantsTime[plantTarget];
    }
}
