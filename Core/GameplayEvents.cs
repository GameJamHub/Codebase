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
    }
}

