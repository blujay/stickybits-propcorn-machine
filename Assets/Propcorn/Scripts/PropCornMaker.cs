using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PropCornMaker : MonoBehaviour
{

    public Transform cornSpawnPoint;
    public GameObject cornPrefab;
    public GameObject[] propPrefabs;
    public int totalCorns;


    private void OnEnable()
    {
        MakeCorn();
    }

    public void MakeCorn()
    {
        
        GameObject propCorns = new GameObject();
        propCorns.name = "propCorns";
        propCorns.transform.position = cornSpawnPoint.transform.position;
        for (int i = 0; i < totalCorns; i++)
        {
            GameObject cornKernel = PhotonNetwork.Instantiate(cornPrefab.name, cornSpawnPoint.position, transform.rotation, 0);
            cornKernel.transform.position = propCorns.transform.position;
            cornKernel.name = "propCorn" + i;
            cornKernel.gameObject.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 0.7f, 1f, 0.5f, 1f);
            cornKernel.transform.parent = propCorns.transform;
            GameObject newProp = PhotonNetwork.Instantiate(propPrefabs[Random.Range(0, propPrefabs.Length)].name, cornSpawnPoint.position, transform.rotation, 0);
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





