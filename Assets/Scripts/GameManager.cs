using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public float gameSpeed = 3;
    public bool isPlay = true;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlay)
        {
            gameSpeed = 3;
        }
        else
        {
            gameSpeed = 0;
        }
    }
}
