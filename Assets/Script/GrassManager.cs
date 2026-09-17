using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GrassManager : MonoBehaviour
{

    [SerializeField] private GameObject peashoteer;
    [SerializeField] private GameObject sunflower;
    [SerializeField] private GameObject IcePea;
    [SerializeField] private GameObject boxer;

    [SerializeField] private Vector3 startPos;
    [SerializeField] private float peaZPos;

    [SerializeField] private Manager managerScript;

    public bool isEmpy=true;

    // Start is called before the first frame update
    void Start()
    {
        managerScript=GameObject.Find("GameManager").GetComponent<Manager>();
        startPos=transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        if (managerScript.peashooter == true && isEmpy == true && managerScript.suns>=100 && managerScript.plantsTimer[0]<=0)
        {
            Instantiate(peashoteer, startPos+new Vector3(0,0,peaZPos), peashoteer.transform.rotation);
            isEmpy = false;

            managerScript.suns -= 100;
            managerScript.plantsTimer[0] = managerScript.plantsTime[0];
            managerScript.peashooter = false;
        }

        else if (managerScript.sunflower == true && isEmpy == true&& managerScript.suns >= 50 && managerScript.plantsTimer[3] <= 0)
        {
            Instantiate(sunflower, startPos + new Vector3(0, 0, peaZPos), sunflower.transform.rotation);
            isEmpy = false;

            managerScript.suns -= 50;
            managerScript.plantsTimer[3] = managerScript.plantsTime[3];
            managerScript.sunflower = false;
        }

        else if (managerScript.icePea == true && isEmpy == true && managerScript.suns >= 150 && managerScript.plantsTimer[1] <= 0)
        {
            Instantiate(IcePea, startPos + new Vector3(0, 0, peaZPos), IcePea.transform.rotation);
            isEmpy = false;

            managerScript.suns -= 150;
            managerScript.plantsTimer[1] = managerScript.plantsTime[1];
            managerScript.icePea = false;
        }

        else if (managerScript.martiaArts == true && isEmpy == true && managerScript.suns >= 100 && managerScript.plantsTimer[2] <= 0)
        {
            Instantiate(boxer, startPos + new Vector3(0, -0.1f, peaZPos), boxer.transform.rotation);
            isEmpy = false;

            managerScript.suns -= 100;
            managerScript.plantsTimer[2] = managerScript.plantsTime[2];
            managerScript.martiaArts = false;
        }
    }
}
