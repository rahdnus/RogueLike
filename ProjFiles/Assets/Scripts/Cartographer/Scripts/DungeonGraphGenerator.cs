using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cartographer;

namespace Cartographer
{
    public class DungeonGraphGenerator
    {
        private static DungeonGraphGenerator instance;
        public static DungeonGraphGenerator Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DungeonGraphGenerator();
                }
                return instance;
            }
        }
        public DungeonGraph generateDungeonGraph(int seed)
        {
            Random.InitState(seed);

            int numofNodes=Random.Range(5,20);
            DungeonGraph graph=new DungeonGraph();
            
            Node currentNode;
            graph.startNode=new Node(Cell.Type.Start);
            Debug.Log(numofNodes);
            currentNode=graph.startNode;
            numofNodes--;
            while(numofNodes!=1)
            {
                int numofbranches=Random.Range(0,3);//temp

                currentNode.branchNodes=new BranchNode[numofbranches];
                for(int i=0;i<numofbranches;i++)
                {
                      int branchcelltype=Random.Range(0,4);//temp
                        if(branchcelltype==0)
                            currentNode.branchNodes[i]=new BranchNode(Cell.Type.Corridor);
                        else
                            currentNode.branchNodes[i]=new BranchNode(Cell.Type.Arena);
                }
                
                int celltype=Random.Range(0,4);
                if(celltype==0)
                    currentNode.nextNode=new Node(Cell.Type.Corridor);
                else
                    currentNode.nextNode=new Node(Cell.Type.Arena);
                
                currentNode=currentNode.nextNode;  

                numofNodes--;

                /* for loop for each branch node */
            }
            currentNode.nextNode=new Node(Cell.Type.End);
            return graph;
        }
    }
}
