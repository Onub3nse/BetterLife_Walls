using BetterLife.Prototypes;
using HarmonyLib;
using Mafi;
using Mafi.Base;
using Mafi.Collections;
using Mafi.Core.Entities;
using Mafi.Core.Entities.Static;
using Mafi.Core.Entities.Static.Layout;
using Mafi.Core.Game;
using Mafi.Core.Input;
using Mafi.Core.Mods;
using Mafi.Core.PathFinding;
using Mafi.Core.Ports.Io;
using Mafi.Core.Prototypes;
using Mafi.Localization;
using Mafi.Numerics;
using Mafi.Unity.InputControl;
using Mafi.Unity.InputControl.Factory;
using Mafi.Unity.Ui;
using Mafi.Unity.Ui.Controllers.LayoutEntityPlacing;
using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
//using static UnityEngine.UI.Image;
namespace BetterLife_Walls
{
    public sealed class BetterLife_Walls : IDisposable, IMod, IModConfig
    {
        private ModManifest manifest;

        public ModManifest Manifest
        {
            get
            {
                return this.manifest;
            }
        }
        public void ChangeConfigs(Lyst<IConfig> configs)
        {
        }
        public void EarlyInit(DependencyResolver resolver)
        {
        }


        public void Dispose()
        {
        }
        public void MigrateJsonConfig(VersionSlim savedVersion, Dict<string, object> savedValues)
        {
        }
        public Option<IConfig> ModConfig { get; }

        public static Version ModVersion
        {
            get
            {
                return typeof(BetterLife_Walls).Assembly.GetName().Version;
            }
        }
        public string Name
        {
            get
            {
                return typeof(BetterLife_Walls).Assembly.GetName().Name;
            }
        }

        // Token: 0x17000002 RID: 2
        // (get) Token: 0x0600000E RID: 14 RVA: 0x00002240 File Offset: 0x00000440
        public int Version
        {
            get
            {
                return typeof(BetterLife_Walls).Assembly.GetName().Version.Major * 100 + typeof(BetterLife_Walls).Assembly.GetName().Version.Minor * 10 + typeof(BetterLife_Walls).Assembly.GetName().Version.Build;
            }
        }


        public ModJsonConfig JsonConfig
        {
            get
            {
                return new ModJsonConfig(this);
            }
        }

        public BetterLife_Walls(ModManifest modManifest)

        {
            this.manifest = modManifest;
        }
         
        public bool IsUiOnly => false;
         
        public void RegisterPrototypes(ProtoRegistrator registrator)
        {
            ProtosDb prototypesDb = registrator.PrototypesDb;

            ToolbarCategoryProto toolbarParent = new ToolbarCategoryProto(BetterLIDs.ToolBars.toolWallsParent, Proto.CreateStr(BetterLIDs.ToolBars.toolWallsParent, "Retaining Walls"), 110f, "Assets/BetterLife/IconsWalls/Toolbar_Walls/toolbar_Walls.png", false,"", null, null, null);
            ToolbarCategoryProto toolbarLegacy = new ToolbarCategoryProto(BetterLIDs.ToolBars.toolWallLegacy, Proto.CreateStr(BetterLIDs.ToolBars.toolWallLegacy, "Legacy", null, null), 110f, "Assets/BetterLife/IconsWalls/Toolbar_Walls/toolbar_legacywalls.png", false, "", null, null, toolbarParent);
            ToolbarCategoryProto toolbarExtended = new ToolbarCategoryProto(BetterLIDs.ToolBars.toolWallExtended, Proto.CreateStr(BetterLIDs.ToolBars.toolWallExtended, "Extended", null, null), 110f, "Assets/BetterLife/IconsWalls/Toolbar_Walls/toolbar_extendedwalls.png", false, "", null, null, toolbarParent);
            ToolbarCategoryProto toolbarSeaWalls = new ToolbarCategoryProto(BetterLIDs.ToolBars.toolWallSeaWalls, Proto.CreateStr(BetterLIDs.ToolBars.toolWallSeaWalls, "Sea Walls", null, null), 110f, "TODO", false, "", null, null, toolbarParent);
            prototypesDb.Add<ToolbarCategoryProto>(toolbarParent, false);
            prototypesDb.Add<ToolbarCategoryProto>(toolbarLegacy, false);
            prototypesDb.Add<ToolbarCategoryProto>(toolbarExtended, false);
            prototypesDb.Add<ToolbarCategoryProto>(toolbarSeaWalls, false);

            registrator.RegisterData<retainingWalls>();

            registrator.RegisterDataWithInterface<IResearchNodesData>();
             
        }
        public bool GameWasLoaded;
        private bool disposedValue;

        public void RegisterDependencies(DependencyResolverBuilder depBuilder, ProtosDb protosDb, bool gameWasLoaded)

        {
 
 


        }

        public void Initialize(DependencyResolver resolver, bool gameWasLoaded)
        {

        }


        private void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }


        void IDisposable.Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }

}
