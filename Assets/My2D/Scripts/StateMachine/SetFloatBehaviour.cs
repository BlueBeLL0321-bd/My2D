using UnityEngine;

namespace My2D
{
    // Float형 타입 파라미터 변수를 관리하는 클래스
    // 상태(상태 머신)에 들어갈 때와 나올 때의 값을 설정해 준다
    public class SetFloatBehaviour : StateMachineBehaviour
    {
        #region Variables
        // 값을 설정할 파라미터 이름
        public string floatName;

        // 작동하는 상태 들어갈 때, 나올 때 체크
        public bool updateOnStateEnter;
        public bool updateOnStateExit;

        // 작동하는 상태 머신 들어갈 때, 나올 때 체크
        public bool updateOnStateMachineEnter;
        public bool updateOnStateMachineExit;

        // 들어갈 때와 나올 때의 값 설정
        public float valueEnter;
        public float valueExit;
        #endregion

        // OnStateEnter is called before OnStateEnter is called on any state inside this state machine
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (updateOnStateEnter)
            {
                animator.SetFloat(floatName, valueEnter);
            }
        }

        // OnStateUpdate is called before OnStateUpdate is called on any state inside this state machine
        //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        //{
        //    
        //}

        // OnStateExit is called before OnStateExit is called on any state inside this state machine
        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (updateOnStateExit)
            {
                animator.SetFloat(floatName, valueExit);
            }
        }

        // OnStateMove is called before OnStateMove is called on any state inside this state machine
        //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        //{
        //    
        //}

        // OnStateIK is called before OnStateIK is called on any state inside this state machine
        //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        //{
        //    
        //}

        // OnStateMachineEnter is called when entering a state machine via its Entry Node
        override public void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
        {
            if (updateOnStateMachineEnter)
            {
                animator.SetFloat(floatName, valueEnter);
            }
        }

        // OnStateMachineExit is called when exiting a state machine via its Exit Node
        override public void OnStateMachineExit(Animator animator, int stateMachinePathHash)
        {
            if (updateOnStateMachineExit)
            {
                animator.SetFloat(floatName, valueExit);
            }
        }
    }
}