using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sunflowerManager : MonoBehaviour
{
    [SerializeField] private ZombiesManager zombieScript;
    private GrassManager grassScript;

    [SerializeField] private GameObject suns;

    [SerializeField] private int sunsTime;
    [SerializeField] private float sunsTimer;
    [SerializeField] private float timerAn;
    [SerializeField] private float timeAn;

    public float life;

    public Animator animations;

    private void Start()
    {
        sunsTimer = sunsTime;
    }
    void Update()
    {
        sunsTimer-= Time.deltaTime;
        timerAn-= Time.deltaTime;

        if (sunsTimer<=0)
        {
            int randomSunDrop = Random.Range(0, 7);

            if(randomSunDrop >= 5)
            {
                animations.SetBool("sun",true);
                animations.SetBool("idle", false);
                timerAn = timeAn;
                Instantiate(suns, transform.position + new Vector3(0, 0.5f, -1), suns.transform.rotation);
            }

            sunsTimer=sunsTime;
        }

        if (timerAn <= 0)
        {
            ChangeAnimation();
        }

        if (life <= 0)
        {
            zombieScript.isOnAttack = false;

            grassScript.isEmpy = true;

            Destroy(gameObject);
        }
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

    public void ChangeAnimation()
    {
        animations.SetBool("sun", false);
        animations.SetBool("idle", true);
    }
}
