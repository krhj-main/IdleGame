using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class DamagePopup : MonoBehaviour
{
    public GameObject canvas;
    GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        
        Player = GameObject.FindGameObjectWithTag("Player");
        Text tmp_text = GetComponent<Text>();
        tmp_text.text = Player.GetComponent<PlayerController>().att.ToAttackString();



        tmp_text.DOFade(0f, 1.0f);
        // (��ǥ���̵� ���°�, ��ȭ�ð�)
        tmp_text.DOColor(Color.red, 1.0f);
        // (��ǥ ����, ��ȭ�ð�)

        transform.DOPunchScale(Vector3.one, 1);
        transform.DOMove(transform.position + Vector3.up * 2, 1).OnComplete(() => { Destroy(canvas); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
