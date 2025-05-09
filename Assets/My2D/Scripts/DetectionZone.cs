using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace My2D
{
    // Detection Zone에 들어오는 콜라이더를 감지하는 클래스
    public class DetectionZone : MonoBehaviour
    {
        #region Variables
        // Detection Zone에 들어온 콜라이더들을 저장하는 리스트 - 현재 Zone 안에 있는 콜라이더 목록
        public List<Collider2D> detectedColliders = new List<Collider2D>();
        #endregion

        #region Unity Event Method
        private void OnTriggerEnter2D(Collider2D collision)
        {
            // 충돌체가 존에 들어오면 리스트에 추가
            detectedColliders.Add(collision);
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            // 충돌체가 존에서 나가면 리스트에서 제거
            detectedColliders.Remove(collision);
        }
        #endregion
    }
}

