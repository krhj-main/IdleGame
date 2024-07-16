using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    public long att = 10;
    Animator anim;
    float CurTime = 0;

    GameObject Mob = null;


    public float HP = 100;
    public float MaxHP = 100;
    public Image hp_bar;
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
    public void TakeDamage(long _damage)
    {
        HP -= _damage;
        DamageOn font = GetComponent<DamageOn>();
        font.DamageText();
        if (HP <= 0)
        {
            Time.timeScale = 0;
            Debug.Log("플레이어 사망 \n 게임 정지");
        }
        hp_bar.fillAmount = HP / MaxHP;
    }


}
