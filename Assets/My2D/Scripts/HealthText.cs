using UnityEngine;
using TMPro;

namespace My2D
{
    // Damage가 위쪽으로 이동한다
    // Damage 페이드 아웃 효과, 페이드 아웃 효과 후 킬
    public class HealthText : MonoBehaviour
    {
        #region Variables
        // 이동
        private RectTransform textTransform;
        [SerializeField] private float moveSpeed = 10f;

        // 페이드 아웃 효과
        private TextMeshProUGUI healthText;
        [SerializeField] private float fadeTime = 1f;
        private float fadeCountdown = 0f;

        private Color startColor;
        #endregion

        #region Unity Event Method
        private void Awake()
        {
            // 참조
            textTransform = this.GetComponent<RectTransform>();
            healthText = this.GetComponent<TextMeshProUGUI>();

            // 초기화
            startColor = healthText.color;
        }

        private void Update()
        {
            // 이동
            textTransform.position += Vector3.up * Time.deltaTime * moveSpeed;

            // fade out 타이머
            fadeCountdown += Time.deltaTime;    // 0 -> fadeTime : (1 - fadeCountdown)

            float newAlpha = startColor.a * (1 - fadeCountdown / fadeTime);
            healthText.color = new Color(startColor.r, startColor.g, startColor.b, newAlpha);

            if (fadeCountdown >= fadeTime)
            {
                Destroy(this.gameObject);
            }
        }
        #endregion
    }
}