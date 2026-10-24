using System;
using System.Collections.Generic;
using UnityEngine;

namespace Enviroment
{
    [Serializable]
    public class LevelData
    {
        public List<GameObjectData> objects { get; private set; }
        public List<TileData> tiles { get; private set; }
        public SpawnPoint spawnPosOne {get; private set;}
        public SpawnPoint spawnPosTwo {get; private set;}
        public float boundsX {get; private set;}
        public float boundsY {get; private set;}
        public LevelData(List<GameObjectData> objects, List<TileData> tiles, SpawnPoint spawnPosOne, SpawnPoint spawnPosTwo, float boundsX, float boundsY)
        {
            this.objects = objects;
            this.tiles = tiles;
            this.spawnPosOne = spawnPosOne;
            this.spawnPosTwo = spawnPosTwo;
            this.boundsX = boundsX;
            this.boundsY = boundsY;
        }
    }
}