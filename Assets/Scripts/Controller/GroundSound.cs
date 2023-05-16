using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSound : MonoBehaviour
{
    public AK.Wwise.Event StepSoundEvent;
    public AK.Wwise.Switch GroundSwitch;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        GroundSwitch.SetValue(gameObject);

        StepSoundEvent.Post(gameObject);
    }
}
