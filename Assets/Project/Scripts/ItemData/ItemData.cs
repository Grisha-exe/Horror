using System;
using UnityEngine;

namespace Scripts
{
    [Serializable]
    public class ItemData
    {
        public string ItemIndex;
        public string ItemName;
        [TextArea(1,10)] public string ItemDescription;
        public Sprite ItemIcon;
        public GameObject ItemModelPrefab;
        public int ItemCount = 1;
    }
}