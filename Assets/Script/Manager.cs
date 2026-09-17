using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public int suns;

    public bool peashooter;
    public bool sunflower;
    public bool martiaArts;
    public bool icePea;

    [SerializeField] private ZombiesManager[] zombiesScript;

    [SerializeField] private TextMeshProUGUI sunsText;
    [SerializeField] private TextMeshProUGUI timerText;

    [SerializeField] private GameObject sunsObj;
    [SerializeField] private GameObject zombiesObj;
    [SerializeField] private GameObject GameOver;

    [SerializeField] private float sunsTimer;
    [SerializeField] private float sunsTime;
    [SerializeField] private float zombiesTimer;
    [SerializeField] private float zombiesTime;
    [SerializeField] private float zombieStartCoolDown;
    [SerializeField] public float[] plantsTimer;
    [SerializeField] public float[] plantsTime;
    public float timerToWin;

    public bool isDay = true;

    private Vector3 sunsPos;
    [SerializeField] private GameObject[] zombiesPos;

    [SerializeField] private bool esOleada;
    public bool isStart;
    public bool gameOver;

    private void Start()
    {
        sunsTimer = sunsTime;
        zombiesTimer = zombiesTime;
        for (int i = 0; i < plantsTimer.Length; i++)
        {
            plantsTimer[i] = 0;
        }
    }

    private void Update()
    {
        if (isStart==true&&gameOver==false)
        {
            if (Time.time >= zombieStartCoolDown)
            {
                zombiesTimer -= Time.deltaTime;

                if (esOleada == false && zombiesTimer <= 0)
                {
                    int zombieProbability = Random.Range(0, 10);

                    if (zombieProbability >= 5)
                    {
                        int zombiePosition = Random.Range(0, zombiesPos.Length);
                        Instantiate(zombiesObj, zombiesPos[zombiePosition].transform.position, zombiesObj.transform.rotation);
                    }

                    zombiesTimer = zombiesTime;
                }
            }

            sunsText.text = suns + " soles peruanos";

            sunsTimer -= Time.deltaTime;

            if (sunsTimer <= 0 && isDay == true)
            {
                int sunProbability = Random.Range(0, 7);

                if (sunProbability >= 5)
                {
                    sunsPos = new Vector3(Random.Range(-8, 8), 4.88f, -6.21f);

                    Instantiate(sunsObj, sunsPos, sunsObj.transform.rotation);
                }

                sunsTimer = sunsTime;
            }

            for (int i = 0; i < plantsTimer.Length; i++)
            {
                plantsTimer[i] -= Time.deltaTime;
            }


            timerToWin-=Time.deltaTime;

            timerText.text="Timer:"+Mathf.FloorToInt(timerToWin);

            if(timerToWin <= 0)
            {
                SceneManager.LoadScene(1);
            }
        }
        else if(gameOver==true)
        {
            GameOver.SetActive(true);
        }
        
    }

    public void ButtonPeashoot()
    {
        if (suns >= 100 && plantsTimer[0]<=0)
        {
            peashooter=true;
            sunflower = false;
            martiaArts = false;
            icePea = false;
        }
        else
        {
            peashooter = false;
        }
    }

    public void ButtonPeaIce()
    {
        if (suns >= 150 && plantsTimer[1]<=0)
        {
            peashooter = false;
            sunflower = false;
            martiaArts = false;
            icePea = true;
        }
        else
        {
            icePea=false;
        }
    }

    public void ButtonBoxer()
    {
        if (suns >= 100 && plantsTimer[2]<=0)
        {
            peashooter = false;
            sunflower = false;
            martiaArts = true;
            icePea = false;
        }
        else
        {
            martiaArts=false;
        }
    }

    public void ButtonSunflower()
    {
        if (suns >= 50 && plantsTimer[3]<=0)
        {
            peashooter = false;
            sunflower = true;
            martiaArts = false;
            icePea = false;
        }
        else
        {
            sunflower=false;
        }
    }

}
