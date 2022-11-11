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
        //Gör så att skärmen flashar när man trycker på J
        if (Input.GetKeyDown(KeyCode.J))
        {
            flash = true;
        }
        
        //Återställer durationCounter och gör boolen flash till false 
        if (flash)
        {
            durationCounter = duration;
            flash = false;
        }

        //När duration är större än noll så blir objectet rött. Objectets Alpha beror på % tid kvar av durationCounter
        if (durationCounter > 0)
        {
            durationCounter -= Time.deltaTime;
            sprite.color = new Color(255, 0, 0, durationCounter / duration);


        }
        //Gör objectet osynligt
        else
        {
            sprite.color = new Color(255, 0, 0, 0);

        }
        

       
       
    }
        
}

