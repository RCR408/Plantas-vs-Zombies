using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class podadoraManager : MonoBehaviour
{
    private ZombiesManager zombieScript;

    [SerializeField] private float speed;
    // Update is called once per frame
    void Update()
    {
      transform.Translate(Vector3.right * speed*Time.deltaTime);

        if (transform.position.x > 10)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        zombieScript = other.GetComponent<ZombiesManager>();
        if (other.CompareTag("Zombie"))
        {
            zombieScript.life-=zombieScript.life;

            speed = 7;
        }
    }
}
