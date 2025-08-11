using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Project.Scripts
{
    [Serializable]
    public class ItemData
    {
        public string ItemIndex;
        public string ItemName;
        [TextArea(1,10)]public string ItemDescription;
        public Sprite ItemIcon;
        public GameObject ItemModelPrefab;
    }
}