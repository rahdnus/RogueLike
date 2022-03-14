using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LInearTubeGen : MonoBehaviour
{
    [SerializeField]int num;
        [SerializeField]GameObject Tube;
    [SerializeField]GameObject DownTubeR,DownTubeL;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 pos=new Vector3(0,0,0);
        for(int i=0;i<num;i++)
        {
            for (int j = 0; j < num; j++)
            {
                GameObject game;
                if (j != 0 && (j != num - 1))
                    game = Instantiate(Tube, pos, Tube.transform.rotation);
                else
                {
                    if (i % 2 == 0)
                    {
                        if (j == 0)
                            game = Instantiate(DownTubeL, pos, DownTubeL.transform.rotation);

                        if (j == num - 1)
                            game = Instantiate(DownTubeR, pos, DownTubeR.transform.rotation);
                    }
                    else if (i % 2 != 0)
                    {
                        if (j == 0)
                            game = Instantiate(DownTubeR, pos, DownTubeR.transform.rotation);

                        if (j == num - 1)
                            game = Instantiate(DownTubeL, pos, DownTubeL.transform.rotation);
                    }
                }

                pos += new Vector3(0, 0, 5);


            }
            pos = new Vector3(0, pos.y - 9, 0);

        }
            
    }


}
