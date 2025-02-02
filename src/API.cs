
using System;
using System.Diagnostics;
using Game.Interface;
using TMPro;
using UnityEngine;
using static Home.Services.InputService;

namespace DockItemLib.API;

public class CustomDockItem
    {
        public string name;
        public string label;
        public string localizationKey;
        public Sprite sprite;
        public HotKey.HotKeyType hotKeyType;
        public Action listener;
        public Func<bool> condition;

        public HudDockItem dockItem;

        public CustomDockItem(string name, string label, Sprite sprite, HotKey.HotKeyType hotKeyType, Action listener, Func<bool> condition) {
            this.name = name;
            this.label = label;
            this.localizationKey = "";
            this.sprite = sprite;
            this.hotKeyType = hotKeyType;
            this.listener = listener;
            this.condition = condition;

            DockItemCore.customDockItems.Add(this);
        }

        public CustomDockItem(string name, string label, string localizationKey, Sprite sprite, HotKey.HotKeyType hotKeyType, Action listener) {
            this.name = name;
            this.label = label;
            this.localizationKey = localizationKey;
            this.sprite = sprite;
            this.hotKeyType = hotKeyType;
            this.listener = listener;
            this.condition = () => {
                return true;
            };

            DockItemCore.customDockItems.Add(this);
        }

        public CustomDockItem(string name, string label, string localizationKey, Sprite sprite, HotKey.HotKeyType hotKeyType, Action listener, Func<bool> condition) {
            this.name = name;
            this.label = label;
            this.localizationKey = localizationKey;
            this.sprite = sprite;
            this.hotKeyType = hotKeyType;
            this.listener = listener;
            this.condition = condition;

            DockItemCore.customDockItems.Add(this);
        }
    }