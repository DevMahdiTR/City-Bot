using System.Collections.Generic;
using UnityEngine;

namespace PoolingSystem
{
    [System.Serializable]
    public  class ObjectsToPool
    {
        public string tag;
        public int size;
        public GameObject obj;
        [HideInInspector]public Queue<GameObject> queueObject = new Queue<GameObject>();
    }
    public class GoodPoolingSystem : MonoBehaviour
    {
        public static GoodPoolingSystem Instance;
    
        [SerializeField] private List<ObjectsToPool> obj = new List<ObjectsToPool>();
        [SerializeField] private Dictionary<string, ObjectsToPool> dicObjToPool = new Dictionary<string,ObjectsToPool>();

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            InstantiateObjectToPool();
        }
      /*  private void Test()
        {
            if (Input.GetMouseButton(0))
            {
                foreach (var o in obj)
                {
                    GetOutOfPool(o.tag, new Vector3(Random.Range(-6, 6), Random.Range(-6, 6)));
                }
            }
        
        }*/

        public void AddToPool(string listTag,GameObject objectToPool)
        {
            if (!dicObjToPool.ContainsKey(listTag))
            {
                return;
            } 
            objectToPool.SetActive(false);
            dicObjToPool[listTag].queueObject.Enqueue(objectToPool);
        }

        public GameObject GetOutOfPool(string listTag)
        {
            if (!dicObjToPool.ContainsKey(listTag))
            {
                print(listTag+" Does not Exist !!! Check Your Tags !!!");
                return null;
            }
            var objToPool =  dicObjToPool[listTag].queueObject.Dequeue();
            objToPool.SetActive(true);
            /*objToPool.transform.position = positionOfTheObject;
            objToPool.transform.rotation = rotationOfTheObejct;*/
            return objToPool;
        }

        private void InstantiateObjectToPool()
        {
            foreach (var o in obj)
            {
                var objectHolder = new GameObject(o.tag+" Holder");
                for (var j = 0; j < o.size ;j++)
                {
                    var objToQueue = Instantiate(o.obj, objectHolder.transform, true);
                    objToQueue.SetActive(false);
                    o.queueObject.Enqueue(objToQueue);
                }

                dicObjToPool.Add(o.tag,o);
            }
        }

   
    
    }
}