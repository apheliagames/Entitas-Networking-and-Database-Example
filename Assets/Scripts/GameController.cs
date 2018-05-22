using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ApheliaGames.Backend
{
    public class GameController : MonoBehaviour
    {
        GameFeature _systems;
        
        // Use this for initialization
        void Start()
        {            
            _systems = new GameFeature(Contexts.sharedInstance);
            _systems.Initialize();
        }

        // Update is called once per frame
        void Update()
        {            
            _systems.Execute();
        }
    }
}
