using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScroll : MonoBehaviour
{
    public Vector3 oriPos;

    // Start is called before the first frame update
    void Start()
    {
        oriPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.isPlay)
        {
            if (transform.position.x <= 8f)
            {
                transform.position = oriPos;
            }
        }

        transform.Translate(Vector3.left * GameManager.Instance.gameSpeed * Time.deltaTime);
    }
}
