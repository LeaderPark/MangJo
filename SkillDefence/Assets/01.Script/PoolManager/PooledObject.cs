using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PooledObject
{
    #region 풀된 오브젝트 관리
    // 객체를 검색할 때 사용할 이름
    public string poolItemName = string.Empty;
    //오브젝트 풀에 저장할 프리팹
    public GameObject prefab = null;
    //초기화할 때 생성할 객체의 수
    public int poolCount = 0;
    //생성한 객체들을 저장할 리스트
    [SerializeField]
    private List<GameObject> poolList = new List<GameObject>();

    //처음 실행 할때 생성 및 리스트에 추가
    public void Initialize(Transform parent = null){
        for(int ix = 0; ix < poolCount; ++ix){
            poolList.Add(CreateItem(parent));
        }
    }

    //사용한 오브젝트를 다시 풀메니져로 반환하는 함수
    public void PushToPool(GameObject item,Transform parent = null) {
        item.transform.SetParent(parent);
        item.SetActive(false);
        poolList.Add(item);
    }

    //객체가 필요할 때 풀메니져에 요청하는 함수
    public GameObject PopFromPool(Transform parent = null) {
        if(poolList.Count == 0)
        poolList.Add(CreateItem(parent));
        GameObject item = poolList[0];
        poolList.RemoveAt(0);
        return item;
    }

    //지정된 게임의 오브젝트를 미리 생성하는 함수
    private GameObject CreateItem(Transform parent = null) {
        GameObject item = Object.Instantiate(prefab) as GameObject;
        item.name = poolItemName;
        item.transform.SetParent(parent);
        item.SetActive(false);
        return item;
    }
    #endregion

}
