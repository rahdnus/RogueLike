using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="Moves",menuName="SO/Moves")]
public class AttackMoves : ScriptableObject
{
   public Attack[] attacks;

   public int GetIndex(string name)
   {
      int index=-1;
      for(int i=0;i<attacks.Length;i++)
         {
            if(attacks[i].animationName.CompareTo(name)==0)
            {
               index=i;
               break;
            }
         }
      return index;
   }
}
[System.Serializable]
public class Attack
{
   public string animationName;
   public int damageValue;
}
