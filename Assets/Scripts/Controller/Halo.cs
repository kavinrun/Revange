using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Halo : MonoBehaviour
{
    [SerializeField]
    private bool interactivePressed = false;

    public void Init()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interactive"))
        {
            interactivePressed = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (interactivePressed)
        {
            Debug.Log("调用对应Callback");
            interactivePressed = false;
        }
    }
}
