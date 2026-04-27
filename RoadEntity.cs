using Mafi;
using Mafi.Collections;
using Mafi.Collections.ImmutableCollections;
using Mafi.Collections.ReadonlyCollections;
using Mafi.Core.Entities;
using Mafi.Core.Entities.Static;
using Mafi.Core.Entities.Static.Layout;
using Mafi.Core.Roads;
using Mafi.Core.Syncers;
using Mafi.Core.Terrain;
using Mafi.Core.Trains;
using Mafi.Localization;
using Mafi.Unity;
using Mafi.Unity.Ui;
using Mafi.Unity.Ui.Library.Inspectors;
using Mafi.Unity.UiStatic.Inspectors.Vehicles;
using Mafi.Unity.UiToolkit.Component;
using Mafi.Unity.UiToolkit.Library;
using System;
using System.Collections.Generic;
using System.Threading;
using Color = UnityEngine.Color;

namespace BetterLife
{

[GlobalDependency(RegistrationMode.AsAllInterfaces, false, false)]
internal class roadsEntranceInspector : BaseInspector<blRoadEntranceEntity>
{
    private readonly MultiLineOverlayRendererHelper m_groundLineRenderer;
    private readonly MultiLineOverlayRendererHelper m_groundLineRenderer2;
    private void UpdateVisualLanes(RoadsManager roadsManager, bool currentOnly)
    {
        RelTile1f relTile1f = new RelTile1f(0.5.ToFix32());
        ReadOnlyArraySlice<RoadsManager.NodeData> roadGraphNodesRaw = roadsManager.GetRoadGraphNodesRaw();
        Tile2f[] array = new Tile2f[roadGraphNodesRaw.Length];
        RoadGraphNodeKey startKey;
        RoadGraphNodeKey endKey;
        Set<IRoadGraphEntity> roadGraphEntities = new Set<IRoadGraphEntity>();
        foreach (KeyValuePair<RoadGraphNodeKey, int> keyValuePair in roadsManager.RoadGraphNodes)
        {
            RoadGraphNodeKey roadGraphNodeKey = keyValuePair.Key;
            RelTile2f relTile2f = new RelTile2f(keyValuePair.Key.Direction.Direction.Vector2f);
            RoadsManager.NodeData nodeData = roadGraphNodesRaw[keyValuePair.Value];
            roadGraphNodeKey = keyValuePair.Key;
            Tile2f tile2f = keyValuePair.Key.Position2f + relTile2f.DivBy4Fast;
            array[keyValuePair.Value] = tile2f;
        }
        foreach (Pair<int, int> pairs in roadsManager.EnumerateRoadGraphEdges())
        {
            Tile2f pairFirst = array[pairs.First];
            Tile2f pairSecond = array[pairs.Second];

            Tile3f from = new Tile3f(pairFirst.X, pairFirst.Y, 1);
            Tile3f to = new Tile3f(pairSecond.X, pairSecond.Y, 1);

            m_groundLineRenderer2.AddLine(from, to, 0.2f, Color.cyan);
        }

        Lyst<IRoadGraphEntity> connectedEntities = new Lyst<IRoadGraphEntity>();
        roadsManager.GetImmediateRoadConnectedEntities(Entity, connectedEntities);

        if (connectedEntities.Count > 0)
        {
            foreach (IRoadGraphEntity entity in connectedEntities)
            {
                Log.Info($"This Entity: {Entity.Id}-{Entity.DefaultTitle.Value.ToString()} -> Entity connected: {entity.DefaultTitle.Value.ToString()} {entity.Id.Value.ToString()}");
            }
        }
        foreach (GraphTerrainConnection graphTerrainConnection in roadsManager.GraphTerrainConnections.Values)
        {
            Tile3f from = new Tile3f(graphTerrainConnection.TerrainTile.CenterTile2f.X, graphTerrainConnection.TerrainTile.CenterTile2f.Y, graphTerrainConnection.Entity.Position3f.Z);
            Tile3f to = new Tile3f(array[graphTerrainConnection.RoadNodeId].X, array[graphTerrainConnection.RoadNodeId].Y, graphTerrainConnection.Entity.Position3f.Z);
            if (currentOnly)
            {
                if (graphTerrainConnection.Entity == Entity)
                {
                    if (graphTerrainConnection.IsFromTerrainToRoad)
                    {
                        m_groundLineRenderer2.AddLine(from, to, 0.3f, Color.green);
                    }
                    else
                    {
                        m_groundLineRenderer2.AddLine(from, to, 0.3f, Color.red);
                    }
                }
            }
            else
            {
                if (graphTerrainConnection.IsFromTerrainToRoad)
                {
                    m_groundLineRenderer2.AddLine(from, to, 0.3f, Color.green);
                }
                else
                {
                    m_groundLineRenderer2.AddLine(from, to, 0.3f, Color.red);
                }
            }
        }
        if (currentOnly)
        {
            for (int i = 0; i < Entity.RoadLanesCount; i++)
            {
                RoadLaneTrajectory lane = Entity.GetTransformedRoadLane(i);
                RelTile3f from = lane.LaneCenterSamples.First;
                RelTile3f to = lane.LaneCenterSamples.Last;
                ImmutableArray<KeyValuePair<Tile2i, HeightTilesF>> heightTiles = Entity.Prototype.Layout.GetVehicleSurfaceHeights(Entity.Transform);
                Entity.GetLaneNodes(i, out startKey, out endKey);

                Tile2i heightTileFrom = new Tile2i(startKey.Position.X.ToIntCeiled(), startKey.Position.Y.ToIntCeiled());
                Tile2i heightTileTo = new Tile2i(endKey.Position.X.ToIntCeiled(), endKey.Position.Y.ToIntCeiled());
                Fix32 fromHeight = heightTiles.FirstOrDefault(kvp => kvp.Key == heightTileFrom).Value.Value;
                Fix32 toHeight = heightTiles.FirstOrDefault(kvp => kvp.Key == heightTileTo).Value.Value;

                Tile3f lineFrom = new Tile3f(startKey.Position.X.ToIntCeiled(), startKey.Position.Y.ToIntCeiled(), fromHeight);
                Tile3f lineTo = new Tile3f(endKey.Position.X.ToIntCeiled(), endKey.Position.Y.ToIntCeiled(), toHeight);

                m_groundLineRenderer.AddLine(lineFrom, lineTo, 1.0f, new Color(255, 127, 0));
            }
        }
        else
        {
            foreach (IRoadGraphEntity item in Context.EntitiesManager.GetAllEntitiesOfType<IRoadGraphEntity>())
            {

                for (int i = 0; i < item.RoadLanesCount; i++)
                {
                    RoadLaneTrajectory lane = item.GetTransformedRoadLane(i);
                    RelTile3f from = lane.LaneCenterSamples.First;
                    RelTile3f to = lane.LaneCenterSamples.Last;
                    ImmutableArray<KeyValuePair<Tile2i, HeightTilesF>> heightTiles = item.Prototype.Layout.GetVehicleSurfaceHeights(item.Transform);
                    item.GetLaneNodes(i, out startKey, out endKey);

                    Tile2i heightTileFrom = new Tile2i(startKey.Position.X.ToIntCeiled(), startKey.Position.Y.ToIntCeiled());
                    Tile2i heightTileTo = new Tile2i(endKey.Position.X.ToIntCeiled(), endKey.Position.Y.ToIntCeiled());
                    Fix32 fromHeight = heightTiles.FirstOrDefault(kvp => kvp.Key == heightTileFrom).Value.Value;
                    Fix32 toHeight = heightTiles.FirstOrDefault(kvp => kvp.Key == heightTileTo).Value.Value;

                    Tile3f lineFrom = new Tile3f(startKey.Position.X.ToIntCeiled(), startKey.Position.Y.ToIntCeiled(), fromHeight);
                    Tile3f lineTo = new Tile3f(endKey.Position.X.ToIntCeiled(), endKey.Position.Y.ToIntCeiled(), toHeight);

                    m_groundLineRenderer.AddLine(lineFrom, lineTo, 1.0f, new Color(255, 127, 0));

                }
            }
        }
    }
        public roadsEntranceInspector(UiContext context, RoadsManager roadsManager, EntitiesManager entitiesManager, TerrainManager terrainManager) : base(context)
        {

            base.OnDeactivatedEvent += delegate
            {
                m_groundLineRenderer.ClearLines();
                m_groundLineRenderer2.ClearLines();
                base.OnDeactivated();
            };
            base.OnDetachedEvent += delegate
            {
                m_groundLineRenderer.ClearLines();
                m_groundLineRenderer2.ClearLines();
            };

            base.OnOpenStart += delegate
            {
                UpdateVisualLanes(roadsManager, true);
            };

            if (this.m_groundLineRenderer == null)
                this.m_groundLineRenderer = new MultiLineOverlayRendererHelper(context.LinesFactory);
            if (this.m_groundLineRenderer2 == null)
                this.m_groundLineRenderer2 = new MultiLineOverlayRendererHelper(context.LinesFactory);
            Label aLabel = new Label().FontBold();
            Label bLabel = new Label().FontBold();
            Label cLabel = new Label().FontBold();
            ButtonText aButton = new ButtonText(new LocStrFormatted("Show All Lanes"), delegate
            {
                if (roadsManager.TerrainGraphConnections.Count > 0)
                {
                    UpdateVisualLanes(roadsManager, false);
                }
            });
            WindowSize(400.px(), Px.Auto);
            AddPanelWithHeader(aLabel)
            .Title(new Mafi.Localization.LocStrFormatted("Working..."));
            bLabel.Add(aButton);
            aLabel.Add(bLabel);
            aLabel.Add(cLabel);
            m_groundLineRenderer.ClearLines();
            m_groundLineRenderer2.ClearLines();
            if (Entity != null)
            {
                Set<IRoadGraphEntity> roadGraphEntities = new Set<IRoadGraphEntity>();
                roadsManager.GetAllRoadConnectedEntities(Entity, roadGraphEntities);
                this.Observe(() => roadGraphEntities.Count)
                    .Do(roadconn =>
                    {
                        cLabel.Value($"Road connections: {roadconn:F0}".AsLoc());
                    });
            }
            if (roadsManager.TerrainGraphConnections.Count > 0)
            {
                this.Observe(() => roadsManager.TerrainGraphConnections.Count)
                    .Do(terraincon =>
                    {
                        aLabel.Value($"TerrainGraph Connections: {terraincon:F0}".AsLoc());
                    });
            }
            this.Observe(() => roadsManager.RoadGraphNodesCount)
                .Do(terraincon2 =>
                {
                    bLabel.Value($"RoadGraph Nodes: {terraincon2:F0}".AsLoc());
                });

        }
    }


    [GlobalDependency(RegistrationMode.AsAllInterfaces, false, false)]
    internal class roadsInspector : BaseInspector<blRoadEntity>
    {
        //private readonly LineOverlayRendererHelper m_goalLineRenderer;
        private readonly MultiLineOverlayRendererHelper m_groundLineRenderer;
        private readonly MultiLineOverlayRendererHelper m_groundLineRenderer2;
        private void UpdateVisualLanes(RoadsManager roadsManager, bool currentOnly)
        {
            RelTile1f relTile1f = new RelTile1f(0.5.ToFix32());
            ReadOnlyArraySlice<RoadsManager.NodeData> roadGraphNodesRaw = roadsManager.GetRoadGraphNodesRaw();
            Tile2f[] array = new Tile2f[roadGraphNodesRaw.Length];
            RoadGraphNodeKey startKey;
            RoadGraphNodeKey endKey;
            Set<IRoadGraphEntity> roadGraphEntities = new Set<IRoadGraphEntity>();

            foreach (KeyValuePair<RoadGraphNodeKey, int> keyValuePair in roadsManager.RoadGraphNodes)
            {
                RoadGraphNodeKey roadGraphNodeKey = keyValuePair.Key;
                RelTile2f relTile2f = new RelTile2f(keyValuePair.Key.Direction.Direction.Vector2f);
                RoadsManager.NodeData nodeData = roadGraphNodesRaw[keyValuePair.Value];
                roadGraphNodeKey = keyValuePair.Key;
                Tile2f tile2f = keyValuePair.Key.Position2f + relTile2f.DivBy4Fast;
                array[keyValuePair.Value] = tile2f;
            }
            foreach (Pair<int, int> pairs in roadsManager.EnumerateRoadGraphEdges())
            {
                Tile2f pairFirst = array[pairs.First];
                Tile2f pairSecond = array[pairs.Second];

                Tile3f from = new Tile3f(pairFirst.X, pairFirst.Y, 1);
                Tile3f to = new Tile3f(pairSecond.X, pairSecond.Y, 1);

                m_groundLineRenderer2.AddLine(from, to, 0.2f, Color.cyan);
            }

            Lyst<IRoadGraphEntity> connectedEntities = new Lyst<IRoadGraphEntity>();
            roadsManager.GetImmediateRoadConnectedEntities(Entity, connectedEntities);

            if (connectedEntities.Count > 0)
            {
                foreach (IRoadGraphEntity entity in connectedEntities)
                {

                    Log.Info($"This Entity: {Entity.Id}-{Entity.DefaultTitle.Value.ToString()} -> Entity connected: {entity.DefaultTitle.Value.ToString()} {entity.Id.Value.ToString()}");
                }
            }

            foreach (GraphTerrainConnection graphTerrainConnection in roadsManager.GraphTerrainConnections.Values)
            {
                Tile3f from = new Tile3f(graphTerrainConnection.TerrainTile.CenterTile2f.X, graphTerrainConnection.TerrainTile.CenterTile2f.Y, graphTerrainConnection.Entity.Position3f.Z);
                Tile3f to = new Tile3f(array[graphTerrainConnection.RoadNodeId].X, array[graphTerrainConnection.RoadNodeId].Y, graphTerrainConnection.Entity.Position3f.Z);
                if (currentOnly)
                {
                    if (graphTerrainConnection.Entity == Entity)
                    {
                        if (graphTerrainConnection.IsFromTerrainToRoad)
                        {
                            m_groundLineRenderer2.AddLine(from, to, 0.3f, Color.green);
                        }
                        else
                        {
                            m_groundLineRenderer2.AddLine(from, to, 0.3f, Color.red);
                        }
                    }
                }
                else
                {
                    if (graphTerrainConnection.IsFromTerrainToRoad)
                    {
                        m_groundLineRenderer2.AddLine(from, to, 0.3f, Color.green);
                    }
                    else
                    {
                        m_groundLineRenderer2.AddLine(from, to, 0.3f, Color.red);
                    }
                }
            }
            if (currentOnly)
            {
                for (int i = 0; i < Entity.RoadLanesCount; i++)
                {
                    RoadLaneTrajectory lane = Entity.GetTransformedRoadLane(i);
                    RelTile3f from = lane.LaneCenterSamples.First;
                    RelTile3f to = lane.LaneCenterSamples.Last;
                    ImmutableArray<KeyValuePair<Tile2i, HeightTilesF>> heightTiles = Entity.Prototype.Layout.GetVehicleSurfaceHeights(Entity.Transform);
                    Entity.GetLaneNodes(i, out startKey, out endKey);

                    Tile2i heightTileFrom = new Tile2i(startKey.Position.X.ToIntCeiled(), startKey.Position.Y.ToIntCeiled());
                    Tile2i heightTileTo = new Tile2i(endKey.Position.X.ToIntCeiled(), endKey.Position.Y.ToIntCeiled());
                    Fix32 fromHeight = heightTiles.FirstOrDefault(kvp => kvp.Key == heightTileFrom).Value.Value;
                    Fix32 toHeight = heightTiles.FirstOrDefault(kvp => kvp.Key == heightTileTo).Value.Value;

                    Tile3f lineFrom = new Tile3f(startKey.Position.X.ToIntCeiled(), startKey.Position.Y.ToIntCeiled(), fromHeight);
                    Tile3f lineTo = new Tile3f(endKey.Position.X.ToIntCeiled(), endKey.Position.Y.ToIntCeiled(), toHeight);

                    m_groundLineRenderer.AddLine(lineFrom, lineTo, 1f, new Color(255, 127, 0));
                }
            }
            else
            {
                foreach (IRoadGraphEntity item in Context.EntitiesManager.GetAllEntitiesOfType<IRoadGraphEntity>())
                {

                    for (int i = 0; i < item.RoadLanesCount; i++)
                    {
                        RoadLaneTrajectory lane = item.GetTransformedRoadLane(i);
                        RelTile3f from = lane.LaneCenterSamples.First;
                        RelTile3f to = lane.LaneCenterSamples.Last;
                        ImmutableArray<KeyValuePair<Tile2i, HeightTilesF>> heightTiles = item.Prototype.Layout.GetVehicleSurfaceHeights(item.Transform);
                        item.GetLaneNodes(i, out startKey, out endKey);

                        Tile2i heightTileFrom = new Tile2i(startKey.Position.X.ToIntCeiled(), startKey.Position.Y.ToIntCeiled());
                        Tile2i heightTileTo = new Tile2i(endKey.Position.X.ToIntCeiled(), endKey.Position.Y.ToIntCeiled());
                        Fix32 fromHeight = heightTiles.FirstOrDefault(kvp => kvp.Key == heightTileFrom).Value.Value;
                        Fix32 toHeight = heightTiles.FirstOrDefault(kvp => kvp.Key == heightTileTo).Value.Value;

                        Tile3f lineFrom = new Tile3f(startKey.Position.X.ToIntCeiled(), startKey.Position.Y.ToIntCeiled(), fromHeight);
                        Tile3f lineTo = new Tile3f(endKey.Position.X.ToIntCeiled(), endKey.Position.Y.ToIntCeiled(), toHeight);

                        m_groundLineRenderer.AddLine(lineFrom, lineTo, 1f, new Color(255, 127, 0));

                        roadsManager.GetAllRoadConnectedEntities(item, roadGraphEntities);

                        Log.Info($"Current connected roads to ({item.DefaultTitle.ToString()}): {roadGraphEntities.Count}");

                    }
                    //foreach (Pair<int, int> enumerateRoadGraphEdge in roadsManager.EnumerateRoadGraphEdges())

                    //    drawing.DrawArrow(tile2fArray[enumerateRoadGraphEdge.First], tile2fArray[enumerateRoadGraphEdge.Second], color1, headSize);

                }
            }
        }

        public roadsInspector(UiContext context, RoadsManager roadsManager, EntitiesManager entitiesManager) : base(context)
        {
            base.OnDeactivatedEvent += delegate
            {
                m_groundLineRenderer.ClearLines();
                m_groundLineRenderer2.ClearLines();
                base.OnDeactivated();
            };
            base.OnDetachedEvent += delegate
            {
                m_groundLineRenderer.ClearLines();
                m_groundLineRenderer2.ClearLines();
            };
            base.OnOpenStart += delegate
            {
                if (roadsManager.TerrainGraphConnections.Count > 0)
                {
                    UpdateVisualLanes(roadsManager, true);
                }
            };
            if (this.m_groundLineRenderer == null)
                this.m_groundLineRenderer = new MultiLineOverlayRendererHelper(context.LinesFactory);
            if (this.m_groundLineRenderer2 == null)
                this.m_groundLineRenderer2 = new MultiLineOverlayRendererHelper(context.LinesFactory);
            Label aLabel = new Label().FontBold();
            Label bLabel = new Label().FontBold();
            Label cLabel = new Label().FontBold();
            ButtonText aButton = new ButtonText(new LocStrFormatted("Show All Lanes"), delegate
            {
                m_groundLineRenderer.ClearLines();
                m_groundLineRenderer2.ClearLines();
                if (roadsManager.TerrainGraphConnections.Count > 0)
                {
                    UpdateVisualLanes(roadsManager, false);
                }
            });

            WindowSize(400.px(), Px.Auto);
            AddPanelWithHeader(aLabel)
            .Title(new Mafi.Localization.LocStrFormatted("Working..."));
            aLabel.Add(aButton);
            aLabel.Add(bLabel);
            aLabel.Add(cLabel);
            m_groundLineRenderer.ClearLines();
            m_groundLineRenderer2.ClearLines();
            if (Entity != null)
            {
                Set<IRoadGraphEntity> roadGraphEntities = new Set<IRoadGraphEntity>();
                roadsManager.GetAllRoadConnectedEntities(Entity, roadGraphEntities);
                this.Observe(() => roadGraphEntities.Count)
                    .Do(roadconn =>
                    {
                        cLabel.Value($"Road connections: {roadconn:F0}".AsLoc());
                    });
            }
            this.Observe(() => roadsManager.TerrainGraphConnections.Count)
            .Do(terraincon =>
                {
                    aLabel.Value($"TerrainGraph Connections: {terraincon:F0}".AsLoc());
                });

            this.Observe(() => roadsManager.RoadGraphNodesCount)
                .Do(terraincon2 =>
                {
                    bLabel.Value($"RoadGraph Nodes: {terraincon2:F0}".AsLoc());
                });
        }

    }
    internal static class ConstructionCubesHelper
    {
        private static readonly ThreadLocal<Lyst<Vector2i>> s_coordsCache;

        private static readonly ThreadLocal<Dict<Vector2i, OccupiedColumn>> s_columnsCache;

        private static readonly ThreadLocal<Lyst<KeyValuePair<Vector2i, OccupiedColumn>>> s_finalColumnsCache;

        public static ImmutableArray<KeyValuePair<Vector2i, OccupiedColumn>> ComputeOptimizedConstructionCubeColumns(ImmutableArray<OccupiedTileRelative> occupiedTiles, int optimizeThreshold = 100, int limitVerticalSizeTo = int.MaxValue)
        {
            if (occupiedTiles.IsEmpty)
            {
                return ImmutableArray<KeyValuePair<Vector2i, OccupiedColumn>>.Empty;
            }

            int num = 0;
            ThicknessTilesI thicknessTilesI = ThicknessTilesI.MaxValue;
            Dict<Vector2i, OccupiedColumn> dict = s_columnsCache.Value.ClearAndReturn();
            Lyst<Vector2i> lyst = s_coordsCache.Value.ClearAndReturn();
            for (int i = 0; i < occupiedTiles.Length; i++)
            {
                OccupiedTileRelative occupiedTileRelative = occupiedTiles[i];
                if ((occupiedTileRelative.Constraint & LayoutTileConstraint.NoConstructionCubes) == 0)
                {
                    num += limitVerticalSizeTo.Min(occupiedTileRelative.VerticalSize.Value);
                    Vector2i key = new Vector2i(occupiedTileRelative.RelativeX, occupiedTileRelative.RelativeY);
                    int num2 = occupiedTileRelative.RelativeFrom + limitVerticalSizeTo.Min(occupiedTileRelative.VerticalSizeRaw);
                    bool exists;
                    ref OccupiedColumn refValue = ref dict.GetRefValue(key, out exists);
                    if (exists)
                    {
                        refValue = new OccupiedColumn(refValue.From.Min(occupiedTileRelative.RelativeFrom), num2.Max(refValue.ToExcl), 1, refValue.IdForXySorting);
                    }
                    else
                    {
                        refValue = new OccupiedColumn(occupiedTileRelative.RelativeFrom, num2, 1, i);
                    }

                    if (occupiedTileRelative.FromHeightRel < thicknessTilesI)
                    {
                        thicknessTilesI = occupiedTileRelative.FromHeightRel;
                    }

                    if (((occupiedTileRelative.RelativeX | occupiedTileRelative.RelativeY) & 1) == 0)
                    {
                        lyst.Add(new Vector2i(occupiedTileRelative.RelativeX, occupiedTileRelative.RelativeY));
                    }
                }
            }

            Lyst<KeyValuePair<Vector2i, OccupiedColumn>> finalColumns = s_finalColumnsCache.Value.ClearAndReturn();
            if (num > optimizeThreshold)
            {
                Dict<Vector2i, OccupiedColumn> dict2 = new Dict<Vector2i, OccupiedColumn>();
                Lyst<Vector2i> lyst2 = new Lyst<Vector2i>();
                optimizeSquareColumns(lyst, 1, dict, dict2, 3, lyst2);
                finalColumns.AddRange(dict);
                dict.Clear();
                if (dict2.Count > optimizeThreshold)
                {
                    Dict<Vector2i, OccupiedColumn> dict3 = dict;
                    optimizeSquareColumns(lyst2, 2, dict2, dict3, -1, null);
                    finalColumns.AddRange(dict3);
                }

                finalColumns.AddRange(dict2);
            }
            else
            {
                finalColumns.AddRange(dict);
            }

            return finalColumns.ToImmutableArray();
            void optimizeSquareColumns(Lyst<Vector2i> coords, int scale, Dict<Vector2i, OccupiedColumn> srcColumns, Dict<Vector2i, OccupiedColumn> resultSquareColumns, int furtherProcessingCoordsMask, Lyst<Vector2i> coordsForFurtherProcessing)
            {
                Lyst<Vector2i>.Enumerator enumerator = coords.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    Vector2i current = enumerator.Current;
                    if (srcColumns.TryGetValue(current, out var value) && srcColumns.TryGetValue(current.AddX(scale), out var value2) && srcColumns.TryGetValue(current.AddY(scale), out var value3) && srcColumns.TryGetValue(current.AddXy(scale), out var value4))
                    {
                        int num3 = value.From.Max(value2.From).Max(value3.From).Max(value4.From);
                        int num4 = value.ToExcl.Min(value2.ToExcl).Min(value3.ToExcl).Min(value4.ToExcl);
                        if (num3 < num4)
                        {
                            cutColumnToHeightRange(current, value, num3, num4);
                            cutColumnToHeightRange(current.AddX(scale), value2, num3, num4);
                            cutColumnToHeightRange(current.AddY(scale), value3, num3, num4);
                            cutColumnToHeightRange(current.AddXy(scale), value4, num3, num4);
                            resultSquareColumns.Add(current, new OccupiedColumn(num3, num4, 2 * scale, value.IdForXySorting.Min(value2.IdForXySorting).Min(value3.IdForXySorting).Min(value4.IdForXySorting)));
                            if (((current.X | current.Y) & furtherProcessingCoordsMask) == 0)
                            {
                                coordsForFurtherProcessing?.Add(current);
                            }
                        }
                    }
                }

                void cutColumnToHeightRange(Vector2i coord, OccupiedColumn c, int minH, int maxHexcl)
                {
                    if (c.From < minH)
                    {
                        finalColumns.Add(coord, new OccupiedColumn(c.From, minH, c.Scale, c.IdForXySorting));
                    }

                    if (c.ToExcl > maxHexcl)
                    {
                        finalColumns.Add(coord, new OccupiedColumn(maxHexcl, c.ToExcl, c.Scale, c.IdForXySorting));
                    }

                    srcColumns.Remove(coord);
                }
            }
        }

        public static ImmutableArray<ConstrCubeSpec> ConvertColumnsToCubes(Tile3i centerTile, ImmutableArray<KeyValuePair<Vector2i, OccupiedColumn>> columns, bool generateGroundLevelSeparately, out int totalCubesVolume, Option<TerrainManager> terrainManager = default(Option<TerrainManager>))
        {
            Lyst<KeyValuePair<int, ConstrCubeSpec>> lyst = new Lyst<KeyValuePair<int, ConstrCubeSpec>>(columns.Length);
            totalCubesVolume = 0;
            int num = int.MaxValue;
            ImmutableArray<KeyValuePair<Vector2i, OccupiedColumn>>.Enumerator enumerator = columns.GetEnumerator();
            while (enumerator.MoveNext())
            {
                KeyValuePair<Vector2i, OccupiedColumn> current = enumerator.Current;
                if (current.Value.From < num)
                {
                    num = current.Value.From;
                }
            }

            ImmutableArray<KeyValuePair<Vector2i, OccupiedColumn>>.Enumerator enumerator2 = columns.GetEnumerator();
            while (enumerator2.MoveNext())
            {
                KeyValuePair<Vector2i, OccupiedColumn> current2 = enumerator2.Current;
                int i = current2.Value.From;
                int toExcl = current2.Value.ToExcl;
                Tile2i tile = centerTile.Xy + new RelTile2i(current2.Key);
                int num2 = int.MinValue;
                int num3;
                if (terrainManager.HasValue)
                {
                    num2 = terrainManager.Value.GetHeight(tile).TilesHeightFloored.Value - centerTile.Height.Value;
                    num3 = num2.Max(current2.Value.From);
                }
                else
                {
                    num3 = num;
                }

                if (generateGroundLevelSeparately && i < 1)
                {
                    toExcl = toExcl.Min(1);
                    for (int num4 = current2.Value.Scale; num4 > 0; num4--)
                    {
                        for (; i + num4 <= toExcl; i += num4)
                        {
                            if (!terrainManager.HasValue || i + num4 > num2)
                            {
                                byte transitionHeightTiles = (byte)(i - num3 + num4).Min(255);
                                totalCubesVolume += current2.Value.Scale * current2.Value.Scale * num4;
                                lyst.Add(current2.Value.IdForXySorting, new ConstrCubeSpec(tile.AsSlim, (centerTile.Height + new ThicknessTilesI(i)).AsSlim, (byte)current2.Value.Scale, (byte)current2.Value.Scale, (byte)num4, transitionHeightTiles));
                            }
                        }
                    }

                    if (current2.Value.ToExcl <= 1)
                    {
                        continue;
                    }

                    toExcl = current2.Value.ToExcl;
                }

                for (int num5 = current2.Value.Scale; num5 > 0; num5--)
                {
                    for (; i + num5 <= toExcl; i += num5)
                    {
                        if (!terrainManager.HasValue || i + num5 > num2)
                        {
                            byte transitionHeightTiles2 = (byte)(i - num3 + num5).Min(255);
                            totalCubesVolume += current2.Value.Scale * current2.Value.Scale * num5;
                            lyst.Add(current2.Value.IdForXySorting, new ConstrCubeSpec(tile.AsSlim, (centerTile.Height + new ThicknessTilesI(i)).AsSlim, (byte)current2.Value.Scale, (byte)current2.Value.Scale, (byte)num5, transitionHeightTiles2));
                        }
                    }
                }
            }

            lyst.Sort(delegate (KeyValuePair<int, ConstrCubeSpec> a, KeyValuePair<int, ConstrCubeSpec> b)
            {
                if (a.Value.Height < b.Value.Height)
                {
                    return -1;
                }

                if (a.Value.Height > b.Value.Height)
                {
                    return 1;
                }

                if (a.Key < b.Key)
                {
                    return -1;
                }

                return (a.Key > b.Key) ? 1 : 0;
            });
            return lyst.ToImmutableArray((KeyValuePair<int, ConstrCubeSpec> x) => x.Value);
        }

        static ConstructionCubesHelper()
        {
            s_coordsCache = new ThreadLocal<Lyst<Vector2i>>(() => new Lyst<Vector2i>());
            s_columnsCache = new ThreadLocal<Dict<Vector2i, OccupiedColumn>>(() => new Dict<Vector2i, OccupiedColumn>());
            s_finalColumnsCache = new ThreadLocal<Lyst<KeyValuePair<Vector2i, OccupiedColumn>>>(() => new Lyst<KeyValuePair<Vector2i, OccupiedColumn>>());
        }
    }

}