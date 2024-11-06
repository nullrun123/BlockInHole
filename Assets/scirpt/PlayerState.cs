using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
   
    public static int count;
    public static int Lives;
    public int startLives = 3;
    void Start()
    {  
        count = 0;
        Lives = startLives;

    }
 

}
