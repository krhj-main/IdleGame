using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public float gameSpeed = 3;
    public bool isPlay = true;

    public long Money = 10000000000;
    public Text MoneyText;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        //MoneyText.text = string.Format("{0:n0}",Money);
        UpdateMoney(0);
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
    public void UpdateMoney(long _money)
    {
        Money += _money;
        StartCoroutine(Count(Money, Money - _money));
    }

    IEnumerator Count(float target, float current)
    {
        float duration = 0.5f;
        float offset = (target - current) / duration;

        while(current < target)
        {
            current += offset * Time.deltaTime;

            //MoneyText.text = string.Format("{0:n0}",(int)current);
            MoneyText.text = Money.ToAttackString();
            yield return null;
        }

        current = target;

        //MoneyText.text = string.Format("{0:n0}",(int)current);
        MoneyText.text = Money.ToAttackString();
    }
}
