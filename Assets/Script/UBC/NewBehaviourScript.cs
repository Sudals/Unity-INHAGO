using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject Test;
    public int x=0;
    void Start()
    {
        Test.transform.position = new Vector3(x, Test.transform.position.y, Test.transform.position.z);
       
    }


    void Update()
    {
        
    }
}
