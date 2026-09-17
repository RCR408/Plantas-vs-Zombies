using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ZombiesManager : MonoBehaviour
{
    private peashoterScript peaScript;
    private sunflowerManager sunflowerScript;
    private BoxManager boxScript;
    [SerializeField] private Manager manager;

    [SerializeField] private float speed;
    [SerializeField] private float speedStart;

    public float life=100;
    [SerializeField] private float damageTake;

    public bool isOnAttack;
    [SerializeField] private float attackTime;
    [SerializeField] private float attackTimer;
    [SerializeField] private float damageDo;

    [SerializeField] private bool isFreeze;
    [SerializeField] private float freezeTime;
    [SerializeField] private float freezeTimer;
    [SerializeField] private Material freezeMaterial;
    [SerializeField] private float freezeSpeed;

    [SerializeField] private Material normalMaterial;
    [SerializeField] private Renderer render;


    void Start()
    {
        manager=GameObject.Find("GameManager").GetComponent<Manager>();
        render = GetComponent<Renderer>();
        normalMaterial = render.material;
        speedStart=speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (manager.isStart == true && manager.gameOver == false)
        {
            if (isOnAttack == false)
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
            }

            if (life <= 0)
            {
                Destroy(gameObject);
            }

            if (transform.position.x <= -10)
            {
                manager.gameOver = true;
                manager.isStart = false;
            }

            if (isFreeze == true)
            {
                speed = freezeSpeed;

                render.material = freezeMaterial;

                freezeTimer -= Time.deltaTime;
            }

            if (freezeTimer <= 0)
            {
                isFreeze = false;
                render.material = normalMaterial;
                speed = speedStart;
            }
        }
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            life-=damageTake;
            Destroy(other.gameObject);
        }

        if (other.CompareTag("hielo"))
        {
            isFreeze = true;
            freezeTimer = freezeTime;
            life -= damageTake;
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Peashooter"))
        {
            isOnAttack = true;
            peaScript = other.GetComponent<peashoterScript>();
        }

        else if (other.CompareTag("Girasol"))
        {
            isOnAttack = true;
            sunflowerScript = other.GetComponent<sunflowerManager>();
        }

        else if (other.CompareTag("boxeador"))
        {
            isOnAttack = true;
            boxScript = other.GetComponent<BoxManager>();
        }

        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Peashooter"))
        {
            attackTimer -= Time.deltaTime;
            if (attackTimer <= 0)
            {
                peaScript.life -= damageDo;
                attackTimer=attackTime;
            }
        }

        else if (other.CompareTag("Girasol"))
        {
            attackTimer -= Time.deltaTime;
            if (attackTimer <= 0)
            {
                sunflowerScript.life -= damageDo;
                attackTimer = attackTime;
            }
        }

        else if (other.CompareTag("boxeador"))
        {
            attackTimer -= Time.deltaTime;
            if (attackTimer <= 0)
            {
                boxScript.life -= damageDo;
                attackTimer = attackTime;
            }
        }
        
    }

}
