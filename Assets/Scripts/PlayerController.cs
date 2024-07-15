using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int att = 10;
    Animator anim;
    float CurTime = 0;

    GameObject Mob = null;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        CurTime = Time.time;    
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.isPlay)
        {
            anim.SetBool("isAttack", false);
        }
        else
        {
            if (CurTime + 0.5f < Time.time)
            {
                CurTime = Time.time;
                anim.SetBool("isAttack",true);
                Mob.GetComponent<Monster>().Damage(att);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D _col)
    {
        if (_col.CompareTag("Monster"))
        {
            GameManager.Instance.isPlay = false;
            Mob = _col.gameObject;
        }

    }
}
