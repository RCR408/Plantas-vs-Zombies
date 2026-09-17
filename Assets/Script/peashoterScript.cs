using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class peashoterScript : MonoBehaviour
{
    private ZombiesManager zombieScript;
    private GrassManager grassScript;

    private Ray rayZombie;
    [SerializeField] private LayerMask zombieMask;

    private Vector3 zombieDistance;

    [SerializeField] private GameObject peaBullet;

    [SerializeField] private float shootTimer;
    [SerializeField] private float shootTime;

    [SerializeField] private float maxDistance;

    [SerializeField] private Animator peaAnimation;

    public float life;
    void Start()
    {
        shootTimer = shootTime;
    }

    // Update is called once per frame
    void Update()
    {
        zombieDistance = transform.right * maxDistance;

        rayZombie =new Ray(transform.position,zombieDistance);
        RaycastHit hitZombie;

        if(Physics.Raycast(rayZombie,out hitZombie,maxDistance,zombieMask))
        {
            shootTimer-=Time.deltaTime;
            if (shootTimer <= 0) 
            {
                PeashooterBullet();
                peaAnimation.SetBool("IsAttacking", true);
            }
            peaAnimation.SetBool("Idle", false);
        }
        else
        {
            peaAnimation.SetBool("Idle", true);
            peaAnimation.SetBool("IsAttacking", false);
        }

        Debug.DrawRay(transform.position,zombieDistance,color: Color.yellow);

        if (life<=0)
        {
            zombieScript.isOnAttack = false;

            grassScript.isEmpy = true;

            Destroy(gameObject);
        }
    }

    private void PeashooterBullet()
    {
        Instantiate(peaBullet, transform.position, peaBullet.transform.rotation);
        shootTimer=shootTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Zombie"))
        {
            zombieScript = other.GetComponent<ZombiesManager>();
        }

        if (other.CompareTag("Grass"))
        {
            grassScript = other.GetComponent<GrassManager>();
        }
    }
}
