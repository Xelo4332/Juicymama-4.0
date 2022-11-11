using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if (Input.GetKeyDown(KeyCode.J))
        {
            flash = true;
        }
        
        if (flash)
        {
            durationCounter = duration;
            flash = false;
        }

        if (durationCounter > 0)
        {
            durationCounter -= Time.deltaTime;
            sprite.color = new Color(255, 255, 255, durationCounter / duration);


        }
        else
        {
            sprite.color = new Color(255, 255, 255, (0));

        }
        

       
       
    }
        
}

