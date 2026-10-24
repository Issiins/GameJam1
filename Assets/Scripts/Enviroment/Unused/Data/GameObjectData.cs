using System;
using UnityEngine;

namespace Enviroment
{
    [Serializable]
    public class GameObjectData
    {
        public float xPos { get; private set; }
        public float yPos { get; private set; }
        public float zPos { get; private set; }
        public float xRot { get; private set; }
        public float yRot { get; private set; }
        public float zRot { get; private set; }
        public float scale { get; private set; }
        public string prefabName { get; private set; }

        public GameObjectData(float xPos, float yPos, float zPos, float xRot, float yRot, float zRot, float scale, string prefabName)
        {
            this.xPos = xPos;
            this.yPos = yPos;
            this.zPos = zPos;
            this.xRot = xRot;
            this.yRot = yRot;
            this.zRot = zRot;
            this.scale = scale;
            this.prefabName = prefabName;
        }
    }
}