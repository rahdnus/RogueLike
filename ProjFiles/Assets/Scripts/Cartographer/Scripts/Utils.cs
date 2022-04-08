using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cartographer
{
public class Utils 
{
 private static Utils instance=null;

  public static Utils Instance
  {
      get{
          if(instance==null)
          {
            instance=new Utils();
          }
        return instance;
      }
  }
  public Direction getOppositeDirection(Direction inputDirection)
  {
       switch(inputDirection)
        {
            case Direction.North:
                return Direction.South;
            case Direction.East:
                return Direction.West;                
            case Direction.West:
                return Direction.East;
            case Direction.South:
                return Direction.North;
            case Direction.undefined:
                return Direction.undefined;
            default:
                return Direction.undefined;
            
        }
  }
}
}

