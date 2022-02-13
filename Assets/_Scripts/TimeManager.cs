using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    //private float velocity;
    //private bool isFrozen;
    //private bool timeSpeed = false;
    
    private NavMeshAgent nm;
    public Animator anim;

    [Header("Ability 1")]
    public Image abilitySlowMo;
    public float cooldown = 1;
    public bool isCooldown = false;
    // set key input in inspector
    public KeyCode ability1;

    [Header("Ability 2")]
    public Image abilityPause;
    public float cooldown2 = 1;
    public bool isCooldown2 = false;
    // set key input in inspector
    public KeyCode ability2;

    [Header("Ability 3")]
    public Image abilityRwd;
    public float cooldown3 = 1;
    public bool isCooldown3 = false;
    // set input key in inspector
    public KeyCode ability3;

    [Header("Ability 4")]
    public Image abilityFwd;
    public float cooldown4 = 1;
    public bool isCooldown4 = false;
    // set input key in inspector
    public KeyCode ability4;

    // Start is called before the first frame update
    void Start()
    {
        //Image fill amount is to 0
        abilitySlowMo.fillAmount = 0;
        abilityPause.fillAmount = 0;
        abilityRwd.fillAmount = 0;
        abilityFwd.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Check if ability button are pressed
        Ability1();
        Ability2();
        Ability3();
        Ability4();

        //Game speed reduced and check iscooldown is false and key is pressed
        if (Input.GetKeyDown(KeyCode.F1) && !isCooldown)
        {
            SlowDownTime();
            StartCoroutine(Delay1());
        }
        //Game paused and check iscooldown2 false and key is pressed
        if (Input.GetKeyDown(KeyCode.F2) && !isCooldown2)
        {
            PauseTime();
            StartCoroutine(Delay2());

        }
        // Game speed increased and check iscooldown4 is false and key is pressed
        if (Input.GetKeyDown(KeyCode.F4) && !isCooldown4)
        {
            SpeedUpTime();
            StartCoroutine(Delay4());
        }
    }

    //wait for seconds before executing method
    IEnumerator Delay1()
    {
        yield return new WaitForSeconds(2);
        NormalTime();
    }
    IEnumerator Delay2()
    {
        yield return new WaitForSeconds(5);
        UnPauseTime();
    }
    IEnumerator Delay3()
    {
        yield return new WaitForSeconds(5);
        UnPauseTime();
    }
    IEnumerator Delay4()
    {
        yield return new WaitForSeconds(5);
        NormalTime();
    }


    private void SpeedUpTime()
    {
        //increase game speed
        Time.timeScale = 1.5f;
    }

    private void SlowDownTime()
    {
        //Reduce game speed
        Time.timeScale = 0.5f;
    }

    private void PauseTime()
    {
        //ai agent is position is stopped and stop animation 
        nm = GetComponent<NavMeshAgent>();
        nm.isStopped = true;
        anim.GetComponent<Animator>();
        anim.enabled = false;
        anim.speed = 0f;

    }

    private void UnPauseTime()
    {
        //ai agent position resume and play animation
        nm = GetComponent<NavMeshAgent>();
        nm.isStopped = false;
        anim.GetComponent<Animator>();
        anim.enabled = true;
        anim.speed = 1f;

    }

    private void NormalTime()
    {
        //Game speed set to normal
        Time.timeScale = 1f;
    }
    void Ability1()
    {
        //check if input key is pressed and iscooldown is false
        if (Input.GetKey(ability1) && isCooldown == false)
        {
            //set iscooldown to true and image fill amount set to 1
            isCooldown = true;
            abilitySlowMo.fillAmount = 1;
        }

        if (isCooldown)
        {
            //image fill amount is reduced based on cooldown
            abilitySlowMo.fillAmount -= 1 / cooldown * Time.deltaTime;

            if (abilitySlowMo.fillAmount <= 0)
            {
                //once fill amount reaches 0 set is cooldown to false
                abilitySlowMo.fillAmount = 0;
                isCooldown = false;
            }
        }

    }
    void Ability2()
    {
        //check if input key is pressed and iscooldown2 is false
        if (Input.GetKey(ability2) && isCooldown2 == false)
        {
            //set iscooldown2 to true and image fill amount set to 1
            isCooldown2 = true;
            abilityPause.fillAmount = 1;
        }

        if (isCooldown2)
        {
            //image fill amount is reduced based on cooldown2
            abilityPause.fillAmount -= 1 / cooldown2 * Time.deltaTime;

            if (abilityPause.fillAmount <= 0)
            {
                //once fill amount reaches 0 set is cooldown2 to false
                abilityPause.fillAmount = 0;
                isCooldown2 = false;
            }
        }

    }
    void Ability3()
    {
        //check if input key is pressed and iscooldown3 is false
        if (Input.GetKey(ability3) && isCooldown3 == false)
        {
            //set iscooldown3 to true and image fill amount set to 1
            isCooldown3 = true;
            abilityRwd.fillAmount = 1;
        }

        if (isCooldown3)
        {
            //image fill amount is reduced based on cooldown3
            abilityRwd.fillAmount -= 1 / cooldown3 * Time.deltaTime;

            if (abilityRwd.fillAmount <= 0)
            {
                //once fill amount reaches 0 set is cooldown3 to false
                abilityRwd.fillAmount = 0;
                isCooldown3 = false;
            }
        }

    }
    void Ability4()
    {
        //check if input key is pressed and iscooldown4 is false
        if (Input.GetKey(ability4) && isCooldown4 == false)
        {
            //set iscooldown4 to true and image fill amount set to 1
            isCooldown4 = true;
            abilityFwd.fillAmount = 1;
        }

        if (isCooldown4)
        {
            //image fill amount is reduced based on cooldown4
            abilityFwd.fillAmount -= 1 / cooldown4 * Time.deltaTime;

            if (abilityFwd.fillAmount <= 0)
            {
                //once fill amount reaches 0 set is cooldown4 to false
                abilityFwd.fillAmount = 0;
                isCooldown4 = false;
            }
        }

    }
}
