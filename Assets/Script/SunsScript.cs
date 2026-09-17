using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunsScript : MonoBehaviour
{
    private Manager managerScript;
    void Start()
    {
        managerScript=GameObject.Find("GameManager").GetComponent<Manager>();
    }

    private void Update()
    {
        Destroy(gameObject,5f);
    }

    private void OnMouseDown()
    {
        managerScript.suns += 25;

        Destroy(gameObject);
    }
}
