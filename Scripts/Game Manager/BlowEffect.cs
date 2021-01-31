using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlowEffect : MonoBehaviour
{
    [SerializeField] private Light2D light;

    [SerializeField] private float sizeAdded;
    [SerializeField] private float timeTaken,alphaTaker;
    private float timer;

    private void FixedUpdate()
    {
        AddSizeAndDestroy();
    }
    private void AddSizeAndDestroy()
    {

            if(light.size<= 100)
                light.size += sizeAdded;
            if(light.color.a>=0)
                light.color.a-=alphaTaker;

        if(light.color.a<=0)
        {
            Destroy(gameObject);
        }
        
        
    }


}
