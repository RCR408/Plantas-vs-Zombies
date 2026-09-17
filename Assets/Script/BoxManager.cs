using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxManager : MonoBehaviour
{
    [SerializeField] private ZombiesManager zombieScript;
    [SerializeField] private GrassManager grassScript;

    [SerializeField] private float damageDo;

    [SerializeField] public float life;

    [SerializeField] private Ray rangeAttack;
    [SerializeField] private float rayRange;
    [SerializeField] private LayerMask zombieMask;

    [SerializeField] private Animator verguizasCabronas;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rangeAttack = new Ray(transform.position, Vector3.right*rayRange);
        RaycastHit hit;

        Debug.DrawRay(transform.position,Vector3.right*rayRange);

        if(Physics.Raycast(rangeAttack,out hit, rayRange, zombieMask))
        {
            zombieScript=hit.collider.GetComponent<ZombiesManager>();
            zombieScript.life-=damageDo*Time.deltaTime;
            verguizasCabronas.SetBool("Idle",false);
            verguizasCabronas.SetBool("Punch", true);
        }
        else
        {
            verguizasCabronas.SetBool("Idle", true);
            verguizasCabronas.SetBool("Punch", false);
        }
        if (life<=0)
        {
            Destroy(gameObject);

            grassScript.isEmpy=true;

            zombieScript.isOnAttack=false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Grass"))
        {
            grassScript=other.GetComponent<GrassManager>();
        }

        if (other.CompareTag("Zombie"))
        {
            other.GetComponent<ZombiesManager>();
        }
    }
}