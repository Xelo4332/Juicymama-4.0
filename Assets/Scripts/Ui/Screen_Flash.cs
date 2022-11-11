using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Av Simon
public class Screen_Flash : MonoBehaviour
{
    private SpriteRenderer sprite;
    [SerializeField]
    private float duration;
    private float durationCounter;
    [SerializeField]
   public  bool flash = false;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //G�r s� att sk�rmen flashar n�r man trycker p� J
        if (Input.GetKeyDown(KeyCode.J))
        {
            flash = true;
        }
        
        //�terst�ller durationCounter och g�r boolen flash till false 
        if (flash)
        {
            durationCounter = duration;
            flash = false;
        }

        //N�r duration �r st�rre �n noll s� blir objectet r�tt. Objectets Alpha beror p� % tid kvar av durationCounter
        if (durationCounter > 0)
        {
            durationCounter -= Time.deltaTime;
            sprite.color = new Color(255, 0, 0, durationCounter / duration);


        }
        //G�r objectet osynligt
        else
        {
            sprite.color = new Color(255, 0, 0, 0);

        }
        

       
       
    }
        
}

