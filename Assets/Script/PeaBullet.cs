using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeaBullet : MonoBehaviour
{
    [SerializeField] private ZombiesManager zombieScript;
    [SerializeField] private float speed;

    // Start is called before the first frame update

    private void Update()
    {
        transform.Translate(Vector3.right * speed*Time.deltaTime);
    }


}
