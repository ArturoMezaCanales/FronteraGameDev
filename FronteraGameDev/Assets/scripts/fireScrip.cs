using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireScrip : MonoBehaviour
{
    private float TIMER = 10;
    private float timer = 0.1f;

    
    public int fires;

    // Start is called before the first frame update
    void Start()
    {
        fires = gameObject.transform.childCount;
        
        //hEdge[0] = gameObject.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if(timer <= 0 )
        {
            for(int i = 0; i<fires; i++)
            {
                gameObject.transform.GetChild(i).localPosition = Vector3.zero;
            }
            for(int i = 0; i<fires; i++)
            {
                gameObject.transform.GetChild(i).localPosition = new Vector3(Random.Range(-.5f, .5f), Random.Range(-10.0f, 10.0f),-5);
            }
            timer = TIMER;
        }
    }
}
