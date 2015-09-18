using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Services.Interfaces;
using UnityEngine;

namespace Assets.Services.Implementations
{
   public class MovePaddleService : IMovePaddleService
    {
       public Vector3 GetNewPosition(float currentXposition, float currentPaddleSpeed)
       {
            float xPos = currentXposition + (Input.GetAxis("Horizontal") * currentPaddleSpeed);
            return new Vector3(Mathf.Clamp(xPos, -8f, 8f), -9.5f, 0f);
        }
    }
}
