using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monster : MonoBehaviour
{
    public int HP = 100;
    int oriHP;

    Animator anim;
    public Vector2 StartPosition;
    public GameObject money;
    //public ItemFx moneyPrefab;
    Transform target;
    // Start is called before the first frame update
    void Start()
    {
        oriHP = HP;
        anim = GetComponent<Animator>();
        target = GameObject.Find("Gold").transform;
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
    }

    public void Damage(int att)
    {
        HP -= att;

        if (HP <= 0)
        {
            int randCount = Random.Range(5,10);
            for (int i = 0; i < randCount; ++i)
            {
                Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);

                GameObject itemFx = Instantiate(money, screenPos, Quaternion.identity);

                itemFx.transform.SetParent(GameObject.Find("Canvas").transform);

                itemFx.GetComponent<ItemFx>().Explosion(screenPos, target.position, 150f);
            }

            gameObject.SetActive(false);
            transform.position = StartPosition;
            HP = 100;
            GameManager.Instance.isPlay = true;
        }
    }
}
