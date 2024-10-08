using System;
using UnityEngine;

namespace Codebase.Core
{
    public partial class GameplayEvents
    {
        public static event Action<Vector2, bool> OnMovement;

        public static void SendOnMovement(Vector2 axisValue, bool canMove)
        {
            OnMovement?.Invoke(axisValue, canMove);
        }

        public static event Action OnJump;

        public static void SendOnJump()
        {
            OnJump?.Invoke();
        }

        public static event Action OnAbsorbPerformed;
        public static void SendOnAbsorbPerformed()
        {
            OnAbsorbPerformed?.Invoke();
        }

        public static event Action OnDashPerformed;
        public static void SendOnDashPerformed()
        {
            OnDashPerformed?.Invoke();
        }

        public static event Action OnShortAttackPerformed;
        public static void SendOnShortAttackPerformed()
        {
            OnShortAttackPerformed?.Invoke();
        }

        public static event Action OnLongAttackPerformed;
        public static void SendOnLongAttackPerformed()
        {
            OnLongAttackPerformed?.Invoke();
        }

        public static event Action OnGameOver;
        public static void SendOnGameOver()
        {
            OnGameOver?.Invoke();
        }
    }
}

