using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public static int CityScore = 0;

    [SerializeField]
    public bool isInteractive;

    private SpriteRenderer spr;

    private void Awake()
    {
        spr = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (CityScore >= 0)
        {
            Debug.Log(CityScore);
        }

        if (isInteractive)
        {
            GameObject haloPrefab =  Resources.Load<GameObject>("Prefabs/Halo");
            GameObject haloObj = Instantiate(haloPrefab);
            haloObj.transform.parent = this.transform;
            haloObj.transform.localPosition = new Vector3(0, -0.42f, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
