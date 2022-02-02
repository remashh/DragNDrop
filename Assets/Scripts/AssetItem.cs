using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Item")]
    public class AssetItem : ScriptableObject, Item
    {
        [SerializeField]
        private Sprite uiIcon;


        public Sprite UIIcon { get; }
    }
