using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cartographer{
public class DungeonGenerator:MonoBehaviour
{
    [SerializeField] int graphSeed;
    private static DungeonGenerator instance;
    public static DungeonGenerator Instance{
        get{
            if(instance==null)
            {
                instance=new DungeonGenerator();
            }
            return instance;
        }
    }
    [SerializeField] DungeonSO dungeonSO;
    public void Awake()
    {
        generateDungeon();
    }
    public void generateDungeon()
    {
        //Instantiate Graph
      
        DungeonGraph graph=DungeonGraphGenerator.Instance.generateDungeonGraph(graphSeed);

        graph.display();
        
        //instantiate empty Dungeon
        
        GameObject DungeonObject=new GameObject("Dungeon");
        Dungeon dungeon=DungeonObject.AddComponent<Dungeon>();
        
        Node currentNode=graph.startNode;
        Vector3 position=Vector3.zero;
        while(currentNode!=null)
        {
            Cell cellprefab=dungeonSO.getCellofType(currentNode.type);

            /* 
             TODO(Node)  
                ->check if the cellprefab has required gate direction 
                    ->try again on conflict
                ->Intanstiate->AddCell->Offset
                ->Check bounds
                    ->try again on conflict
             */

            //OLD GameObject cellGameObject=GameObject.Instantiate(cellprefab.gameObject,position,Quaternion.identity,dungeon.transform);
            //OLD dungeon.AddCell(cellGameObject.GetComponent<Cell>());
            
            /*
            TODO(BranchNode)
             ->next start filling gates with branchnodes 
             ->Offset them accordingly
             ->Check bounds
                    -> try again on conflict
            */

            currentNode=currentNode.nextNode;
        }
     


        
        //first place dungeonSO.startcellPrefab at origin
        
        //OLD GameObject startCellObject=GameObject.Instantiate(dungeonSO.StartCellPrefab.gameObject,Vector3.zero,Quaternion.identity,dungeon.transform);

        //OLD dungeon.AddCell(    
        // startCellObject.GetComponent<Cell>()
        // );

        /* OLD
        Gate firstGate=dungeon.mycells[0].gates[1];

        Direction direction=firstGate.direction;
        Direction requiredDirection=Utils.Instance.getOppositeDirection(direction);
        
        Vector3 nextPosition=firstGate.transform.position;
       
        Cell newCell=dungeonSO.EndCellPrefab.GetComponent<Cell>();
       
        foreach(Gate gate in newCell.gates)
         {
             if(gate.direction==requiredDirection)
             {
                GameObject cellObject=GameObject.Instantiate(dungeonSO.EndCellPrefab.gameObject,Vector3.zero,Quaternion.identity,dungeon.transform);
                Cell cell=cellObject.GetComponent<Cell>();
                dungeon.AddCell(cell);

                Vector3 offset=newCell.transform.position-gate.transform.position;
                cellObject.transform.position=nextPosition+offset;
                break;
             }
         }   */


        /* get gate and assign intermediate cell using gate direction*/
        /* offset position using bounds */
        /*Get intermediate cells thru pacing graph and connect based on GateDirection
        Reject current cell if it encroaches on previously placed cells,Seal the gate if no new cell is compatible
        Prioritize POI cells they must be there.*/
    }
}

}