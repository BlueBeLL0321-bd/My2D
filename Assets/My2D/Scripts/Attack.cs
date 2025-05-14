using UnityEngine;

namespace My2D
{
    // 공격 시 충돌체에게 대미지를 준다
    public class Attack : MonoBehaviour
    {
        #region Variables
        // 공격력
        [SerializeField]
        private float attackDamage = 10f;

        // 넉백 효과 - 뒤로 이동
        [SerializeField]
        private Vector2 knockback = Vector2.zero;
        #endregion


        #region Unity Event Method
        private void OnTriggerEnter2D(Collider2D collision)
        {
            // collision에서 Damageable 컴포넌트를 찾아서 TakeDamage 주기
            Damageable damageable = collision.GetComponent<Damageable>();

            if(damageable != null)
            {
               // 공격하는 캐릭터의 방향에 따라 밀리는 방향 설정
               Vector2 deliveredKnockback = this.transform.parent.parent.localScale.x > 0 ? knockback : new Vector2(-knockback.x, knockback.y);

               bool isHit = damageable.TakeDamage(attackDamage, deliveredKnockback);
            }
        }
        #endregion

    }
}