using UnityEngine;
using UnityEngine.Events;

namespace My2D
{
    // 캐릭터에서 사용하는 이벤트 함수 정의
    public class CharacterEvents
    {
        // 캐릭터 대미지 이벤트 함수 정의
        public static UnityAction<GameObject, float> characterDamaged;
        // 힐 이벤트 함수 정의
        public static UnityAction<GameObject, float> characterHealed;
    }
}