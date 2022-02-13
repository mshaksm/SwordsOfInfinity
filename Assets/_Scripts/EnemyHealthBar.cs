using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public float enemyHealth;
    public float enemyMaxHealth;
    public GameObject healthBarUI;
    public Slider slider;
    public GameManager gm;
    public bool dead = false;
    //private GameObject target;




    // Start is called before the first frame update
    void Start()
    {
        //find object GameManager
        gm = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //set slider value to enemy health
        slider.value = GetComponent<StatusC>().health;
    
    }

}

