using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Enviroment
{
    public class LevelBuilder
    {
        private readonly Vector2 _startPlayerOne;
        private readonly Vector2 _startPlayerTwo;
        private readonly Tilemap _tilemap;
        private readonly Tile _defaultTile; // In case of tiles are missing from files, this will be placed instead
        private readonly GameObject _defaultObject; // In cade of objects are missing from files, this will be placed instead
        private readonly Dictionary<string, Tile> _tiles;
        private readonly Dictionary<string, GameObject>  _objectCache;

        public LevelBuilder(Vector2 startPlayerOne, Vector2 startPlayerTwo, Tilemap tilemap, List<Tile> tiles, List<GameObject> objects, GameObject defaultObject, Tile defaultTile)
        {
            _startPlayerOne = startPlayerOne;
            _startPlayerTwo = startPlayerTwo;
            _tilemap = tilemap;
            CacheTiles(tiles);
            CacheObjects(objects);
        }

        private void CacheTiles(List<Tile> tiles)
        {
            if(tiles == null) return;
            foreach (var tile in tiles)
            {
                _tiles.TryAdd(tile.name, tile);
            }
        }

        private void CacheObjects(List<GameObject> objects)
        {
            if (objects == null) return;
            foreach (var obj in objects)
                _objectCache.TryAdd(obj.name, obj);
        }

        private void PlaceTiles(List<TileData> tiles)
        {
            if (tiles == null) return;
            foreach (var tileData in tiles)
            {
                var tilePos = new Vector3Int(tileData.x, tileData.y, 0);
                if (_tiles.TryGetValue(tileData.tileName, out var currTile))
                    _tilemap.SetTile(tilePos, currTile);
                else
                    _tilemap.SetTile(tilePos,  _defaultTile);
            }
        }

        private List<GameObject> PlaceObjects(List<GameObjectData> objects)
        {
            var gameObjects = new List<GameObject>();
            foreach (var objectData in objects)
            {
                var pos = new Vector3(objectData.xPos, objectData.yPos, objectData.zPos);
                var rotation = Quaternion.Euler(objectData.xRot, objectData.yRot, objectData.zRot);
                var localScale = new Vector3(objectData.scale, objectData.scale, objectData.scale);

                var prefabToInstantiate = _objectCache.GetValueOrDefault(objectData.prefabName, _defaultObject);

                if (prefabToInstantiate == null) continue;
                var newObject = Object.Instantiate(prefabToInstantiate, pos, rotation);
                newObject.transform.localScale = localScale;
                gameObjects.Add(newObject);
            }
            return gameObjects;
        }
    }
}