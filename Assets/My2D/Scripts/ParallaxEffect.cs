using UnityEditor.U2D.Aseprite;
using UnityEngine;

namespace My2D
{
    // 시차에 의해 배경이 이동하는 거리 구하기
    public class ParallaxEffect : MonoBehaviour
    {
        #region Variables
        // 플레이어 오브젝트
        public Transform followTarget;
        // 카메라 오브젝트
        public Camera cam;

        // 시차 적용 배경의 처음 시작 위치(이동하기 전)
        private Vector2 startingPosition;
        // 시차 적용 배경의 처음 z 위치 값
        private float startingZ;
        #endregion

        #region Property
        // 카메라 시작 지점으로부터 이동 거리
        Vector2 camMoveSinceStart => startingPosition - (Vector2)cam.transform.position;

        // 플레이어와 배경 사이의 거리
        float zDistanceFromTarget => transform.position.z - followTarget.position.z;

        // 배경 위치에 따른 플레이어와의 거리
        float clippingPlane => cam.transform.position.z + ((zDistanceFromTarget > 0) ? cam.farClipPlane : cam.nearClipPlane);

        // 플레이어 이동에 따른 배경 이동 거리 비율
        float parallaxFactor => Mathf.Abs(zDistanceFromTarget) / clippingPlane;
        #endregion


        #region Unity Event Method
        private void Start()
        {
            // 초기화 (배경 시작 위치 저장)
            startingPosition = this.transform.position;
            startingZ = this.transform.position.z;
        }

        private void Update()
        {
            // 플레이어 이동에 따른 배경의 새로운 위치 구하기
            Vector2 newPosition = startingPosition + camMoveSinceStart * parallaxFactor;

            // 배경의 위치 세팅
            this.transform.position = new Vector3(newPosition.x, newPosition.y, startingZ);
        }
        #endregion
    }
}