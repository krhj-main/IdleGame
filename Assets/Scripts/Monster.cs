using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monster : MonoBehaviour
{
    public long HP;
    long oriHP;

    public long MobDamage;

    Animator anim;
    public Vector2 StartPosition;
    public GameObject money;
    GameObject Player;
    //public ItemFx moneyPrefab;
    Transform target;
    float CurTime;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        oriHP = HP;
        anim = GetComponent<Animator>();
        target = GameObject.Find("Gold").transform;
        CurTime = 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.isPlay)
        {
            transform.Translate(Vector2.left * Time.deltaTime * GameManager.Instance.gameSpeed);

            if (transform.position.x <= -10)
            {
                gameObject.SetActive(false);
                transform.position = StartPosition;
            }
        }
        else
        {
            if (CurTime >= 1.5f)
            {
                float dis = Vector3.Distance(Player.transform.position, transform.position);
                if (dis < 3)
                {
                    anim.SetBool("isAttack", true);
                    Player.GetComponent<PlayerController>().TakeDamage(MobDamage);
                    CurTime = 0;
                }
            }
            CurTime += Time.deltaTime;
        }
    }

    public void Damage(long att)
    {
        HP -= att;

        if (HP <= 0)
        {
            int randCount = Random.Range(5, 10);
            for (int i = 0; i < randCount; ++i)
            {
                Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);

                GameObject itemFx = Instantiate(money, screenPos, Quaternion.identity);

                itemFx.transform.SetParent(GameObject.Find("Canvas").transform);

                itemFx.GetComponent<ItemFx>().Explosion(screenPos, target.position, 150f);
            }

            gameObject.SetActive(false);
            transform.position = StartPosition;
            HP = oriHP;
            GameManager.Instance.isPlay = true;
            GameManager.Instance.UpdateMoney(1000000000);
        }
        else
        {
            DamageOn font = GetComponent<DamageOn>();
            font.DamageText();
        }
    }
}
