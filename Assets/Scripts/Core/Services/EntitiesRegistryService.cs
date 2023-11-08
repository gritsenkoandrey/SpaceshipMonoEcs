﻿using System.Collections.Generic;

namespace Core.Services
{
    public sealed class EntitiesRegistryService
    {
        private readonly ComponentRegistryService _componentRegistryService;
        private readonly List<bool> _entities;
        public IReadOnlyList<bool> Entities => _entities;

        public EntitiesRegistryService(ComponentRegistryService componentRegistryService)
        {
            _componentRegistryService = componentRegistryService;
            _entities = new List<bool>();
        }
        
        public int RegisterEntity()
        {
            int id;
            int count = _entities.Count;

            for (id = 0; id < count; id++)
            {
                if (!_entities[id])
                {
                    _entities[id] = true;
                    
                    return id;
                }
            }

            id = count;
            
            _entities.Add(true);
            _componentRegistryService.AddComponent();

            return id;
        }

        public void UnregisterEntity(int index)
        {
            _entities[index] = false;
            _componentRegistryService.RemoveComponent(index);
        }
    }
}