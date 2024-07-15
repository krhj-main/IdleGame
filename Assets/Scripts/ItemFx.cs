using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ItemFx : MonoBehaviour
{
    public void Explosion(Vector2 from, Vector2 to, float explo_range)
    {
        // ���� �̵�ȿ�� DoTween �ҽ�
        // �Լ� ȣ�� �� �Էµ� ���ڸ� �� ��ũ��Ʈ�� ����� ������Ʈ ��ġ�� ����

        transform.position = from;

        //������ �����
        // �����ϰ� ����� �������� ����
        Sequence sequence = DOTween.Sequence();

        // ������ Ʈ���� ������ ���� �߰�
        // ������Ʈ ������Ʈ�� ������ �̵��� �����ð����� ��ȭ�Ѵ�
        // ��ǥ��, ��ȯ�ð�, ��ȭ����
        sequence.Append(transform.DOMove(from + Random.insideUnitCircle * explo_range, 0.25f).SetEase(Ease.OutCubic));

        sequence.Append(transform.DOMove(to,0.5f).SetEase(Ease.InCubic));

        sequence.AppendCallback(() => 
        { 
            Destroy(gameObject); 
        });
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
