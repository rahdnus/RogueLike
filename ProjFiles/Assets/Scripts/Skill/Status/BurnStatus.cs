using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnStatus : StatusEffect
{
  public override void Enact()
  {
      targetactor.brain.BeingAttacked(attackDirecton.none,10);
  }
}
