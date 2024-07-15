using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ItemFx : MonoBehaviour
{
    public void Explosion(Vector2 from, Vector2 to, float explo_range)
    {
        // 동전 이동효과 DoTween 소스
        // 함수 호출 시 입력된 인자를 이 스크립트가 적용된 오브젝트 위치에 대입

        transform.position = from;

        //시퀀스 만들기
        // 참조하고 사용할 시퀀스를 만듬
        Sequence sequence = DOTween.Sequence();

        // 지정된 트윈을 시퀀스 끝에 추가
        // 오브젝트 컴포넌트에 연결해 이동을 일정시가동안 변화한다
        // 목표값, 변환시간, 변화형태
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
