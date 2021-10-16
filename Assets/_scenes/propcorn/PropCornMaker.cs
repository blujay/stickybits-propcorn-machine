using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PropCornMaker : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform cornSpawnPoint;
    public GameObject cornPrefab;
    public GameObject[] propPrefabs;
    public int totalCorns;


    void Start()
    {
        MakeCorn();
    }

    public void MakeCorn()
    {
        GameObject propCorns = new GameObject();
        propCorns.name = "propCorns";
        for (int i = 0; i < totalCorns; i++)
        {
            
            GameObject cornKernel = Instantiate(cornPrefab, cornSpawnPoint.transform.position, transform.rotation, propCorns.transform);
            cornKernel.name = "propCorn" + i;
            GameObject newProp = PhotonNetwork.Instantiate(propPrefabs[Random.Range(0, propPrefabs.Length)].name, cornSpawnPoint.position, transform.rotation, 0);
            //GameObject newProp = Instantiate(propPrefabs[Random.Range(0, propPrefabs.Length)], cornKernel.transform.position, transform.rotation);
            newProp.transform.parent = cornKernel.transform;
            cornKernel.AddComponent<PropCorn>();
            HideProp(newProp);
            
        }
    }

    
    public void HideProp(GameObject prop)
    {
        prop.gameObject.SetActive(false);
    }
}

//todo
// instantiate photon pun version of corns and prefabs from resources folder. 
// 





