// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;
using Cartographer.Attribute;

namespace Cartographer{
    public class DungeonGraph
    {   
        public Node startNode;

        [ReadAs(Type.Debugger)]
        public void display()
        {
            Node currentNode=startNode;
            while(currentNode!=null)
            {
                Debug.Log(currentNode.type);
                
                string names="";
                if (currentNode.branchNodes != null)
                {
                    foreach (BranchNode branch in currentNode.branchNodes)
                    {
                        names += branch.type.ToString() + "->";
                    }
                    Debug.Log("Branches: " + names);
                }
                currentNode=currentNode.nextNode;
            }
        }  
      
    }
    public class Node{
        public Cell.Type type;
        public BranchNode[] branchNodes;//0->1->2->3
        public Node nextNode;
        public Node(Cell.Type type)
        {
            this.type=type;
        }       
    }
    public class BranchNode{
        public BranchNode(Cell.Type type)
        {
            this.type=type;
        }
        public Cell.Type type;
    }

    namespace Attribute
    {
        [System.AttributeUsage(System.AttributeTargets.Method)]
        class ReadAsAttribute : System.Attribute
        {
         
            Type type;
            public ReadAsAttribute(Type type)
            {
                this.type=type;
            }
        }
           public enum Type
            {
                undefined,Debugger
            }
    }
  
}

