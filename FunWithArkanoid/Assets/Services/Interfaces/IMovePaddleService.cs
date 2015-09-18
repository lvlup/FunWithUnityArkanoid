using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Services.Interfaces
{
   public interface IMovePaddleService
   {
       Vector3 GetNewPosition(float currentXposition, float currentPaddleSpeed);
   }
}
