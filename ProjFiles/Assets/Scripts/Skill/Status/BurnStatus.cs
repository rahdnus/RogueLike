using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnStatus : StatusEffect
{
  public override void Enact()
  {
      int value=targetactor.CalculateDamage(10);
      targetactor.Modifiyhealth(value);
      Debug.Log("Burn");
  }
}
