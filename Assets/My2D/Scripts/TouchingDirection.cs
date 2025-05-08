using UnityEngine;

namespace My2D
{
    // Collider Cast를 이용하여 바닥, 천장, 벽 체크
    public class TouchingDirection : MonoBehaviour
    {
        #region Variables
        public Animator animator;
        private CapsuleCollider2D touchingCollider;

        // 캐스팅 범위
        [SerializeField] private float groundDistance = 0.05f; // 그라운드 체크 범위
        [SerializeField] private float ceilingDistance = 0.05f; // 천장 체크 범위
        [SerializeField] private float wallDistance = 0.05f; // 벽 체크 범위

        // 캐스팅 필터 조건 설정
        [SerializeField] private ContactFilter2D contactFilter;

        // 캐스팅된 RaycastHit2D 리스트(배열)
        private RaycastHit2D[] groundHits = new RaycastHit2D[5];
        private RaycastHit2D[] ceilingHits = new RaycastHit2D[5];
        private RaycastHit2D[] wallHits = new RaycastHit2D[5];

        // Cast 체크
        [SerializeField] private bool isGround; // 그라운드
        [SerializeField] private bool isCeiling; // 천장
        [SerializeField] private bool isWall; // 벽
        #endregion

        #region Property
        public bool IsGround
        {
            get
            {
                return isGround;
            }
            set
            {
                isGround = value;
                animator.SetBool(AnimationString.isGround, value);
            }
        }
        public bool IsCeiling
        {
            get
            {
                return isCeiling;
            }
            set
            {
                isCeiling = value;
                animator.SetBool(AnimationString.isCeiling, value);
            }
        }
        public bool IsWall
        {
            get
            {
                return isWall;
            }
            set
            {
                isWall = value;
                animator.SetBool(AnimationString.isWall, value);
            }
        }
        private Vector2 WallCheckDirection => (this.transform.localScale.x > 0) ? Vector2.right : Vector2.left;
        #endregion

        private void Awake()
        {
            // 참조
            touchingCollider = this.GetComponent<CapsuleCollider2D>();
        }

        private void FixedUpdate()
        {
            // 바닥 체크
            IsGround = touchingCollider.Cast(Vector2.down, contactFilter, groundHits, groundDistance) > 0;

            // 천장 체크
            IsCeiling = touchingCollider.Cast(Vector2.up, contactFilter, ceilingHits, ceilingDistance) > 0;

            // 벽 체크
            IsWall = touchingCollider.Cast(WallCheckDirection, contactFilter, wallHits, wallDistance) > 0;
        }
    }
}

