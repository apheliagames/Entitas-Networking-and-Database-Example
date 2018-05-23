using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ApheliaGames.Backend
{
    public class GameController : MonoBehaviour
    {
        Feature _systems;
        [SerializeField]
        bool SaveEntitiesToDatabase;
        MongoDBController mongoDBController;
        
        // Use this for initialization
        void Start()
        {
            if (SaveEntitiesToDatabase)
            {
                mongoDBController = FindObjectOfType<MongoDBController>();
                mongoDBController.enabled = true;
                _systems = new PersistingNetworkGameFeature(Contexts.sharedInstance);
            }
                
            else _systems = new NetworkOnlyGameFeature(Contexts.sharedInstance);
            _systems.Initialize();
        }

        // Update is called once per frame
        void Update()
        {            
            _systems.Execute();
        }
    }
}
