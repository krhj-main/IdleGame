using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class DamagePopup : MonoBehaviour
{
    public enum Case
    {
        Player,
        Monster,
    }
    public Case fontCase;
    public GameObject canvas;
    GameObject Player;
    GameObject Monster;

    // Start is called before the first frame update
    void Start()
    {
        Text tmp_text;
        switch (fontCase)
        {
            case Case.Player:
                Player = GameObject.FindGameObjectWithTag("Player");
                tmp_text = GetComponent<Text>();
                tmp_text.text = Player.GetComponent<PlayerController>().att.ToAttackString();



                tmp_text.DOFade(0f, 1.0f);
                // (목표페이드 상태값, 변화시간)
                tmp_text.DOColor(Color.red, 1.0f);
                // (목표 색깔값, 변화시간)

                transform.DOPunchScale(Vector3.one, 1);
                transform.DOMove(transform.position + Vector3.up * 2, 1).OnComplete(() => { Destroy(canvas); });
                break;
            case Case.Monster:
                Monster = GameObject.FindGameObjectWithTag("Monster");
                tmp_text = GetComponent<Text>();
                tmp_text.text = Monster.GetComponent<Monster>().MobDamage.ToAttackString();


                tmp_text.DOFade(0f, 1.0f);
                // (목표페이드 상태값, 변화시간)
                tmp_text.DOColor(Color.red, 1.0f);
                // (목표 색깔값, 변화시간)

                transform.DOPunchScale(Vector3.one, 1);
                transform.DOMove(transform.position + Vector3.up * 2, 1).OnComplete(() => { Destroy(canvas); });
                break;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
