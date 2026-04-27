using Mafi;
using Mafi.Collections;
using Mafi.Collections.ImmutableCollections;
using Mafi.Core.Entities;
using Mafi.Core.Roads;
using Mafi.Curves;
using System.Collections.Generic;
using System.Linq;

namespace BetterLife.Utility;


public static class entityUtil
{
    public static void TryGetClosestRoadGraph(EntitiesManager entitiesManager, Tile2f centerPosition, out IRoadGraphEntity closestEntity, out Fix64 minDistance)
    {

        minDistance = Fix64.MaxValue; // Track the smallest distance
        closestEntity = null;
        IEnumerable<IRoadGraphEntity> m_foundEntities = entitiesManager.GetAllEntitiesOfType<IRoadGraphEntity>();
        if (m_foundEntities.Count() == 0)
        { closestEntity = null; minDistance = 0; return; }
        foreach (IRoadGraphEntity entity in m_foundEntities)
        {
            Fix32 relativeX = (centerPosition.X - entity.Position2f.X);
            Fix32 relativeY = (centerPosition.Y - entity.Position2f.Y);
            Fix64 distancesqr = centerPosition.DistanceSqrTo(entity.Position2f);
            if (distancesqr < minDistance)
            {
                minDistance = distancesqr;
                closestEntity = entity;
            }
        }
    }
}

public static class roadsUtil
{
    public struct mLaneData
    {
        public CubicBezierCurve2f LaneTrajectory = new CubicBezierCurve2f();
        public RoadLaneType laneType1;
        public RoadLaneType laneType2;
        public CubicBezierCurve2f heightCurve = new CubicBezierCurve2f();
        public terrainGraph[] terrainTiles;

        public mLaneData(CubicBezierCurve2f vLaneTrajectory,
            RoadLaneType vlanetype1, RoadLaneType vlanetype2, terrainGraph[] vTerrainTiles, CubicBezierCurve2f vHeightCurve)
        {
            LaneTrajectory = vLaneTrajectory;
            laneType1 = vlanetype1;
            laneType2 = vlanetype2;
            heightCurve = vHeightCurve;
            terrainTiles = vTerrainTiles;
        }
    }
    public struct terrainGraph
    {
        public int laneIndex;
        public RelTile2f position;
        public bool isAtStart;

        public terrainGraph(int laneIndex, RelTile2f position, bool isAtStart)
        {
            this.laneIndex = laneIndex;
            this.position = position;
            this.isAtStart = isAtStart;
        }
    }

    public static bool CreateLanes(roadsUtil.mLaneData[] thisLane, out ImmutableArray<RoadLaneSpec> laneSpecs, out ImmutableArray<RoadLaneTrajectory> laneTrajectory, out ImmutableArray<RoadLaneMetadata> laneMetaData, out ImmutableArray<LaneTerrainConnectionSpec> laneTerrainConnection, out bool result)
    {
        CubicBezierCurve2f heightCurve = new CubicBezierCurve2f(); // or use a default constructor


        ImmutableArray<RoadLaneSpec> immutableArray = ImmutableArray<RoadLaneSpec>.Empty;
        ImmutableArray<LaneTerrainConnectionSpec> terrainConnections = ImmutableArray<LaneTerrainConnectionSpec>.Empty;

        // Use List<T> for mutable collections, then convert to ImmutableArray
        Lyst<RoadLaneSpec> laneSpecs2 = new Lyst<RoadLaneSpec>();
        laneSpecs = ImmutableArray.Empty;
        Lyst<LaneTerrainConnectionSpec> laneTerrainConnectionSpecs = new Lyst<LaneTerrainConnectionSpec>();

        foreach (roadsUtil.mLaneData lanedata in thisLane)
        {
            double scaledFirstLaneY = lanedata.LaneTrajectory.ControlPoints[0].Y.ToDouble();
            heightCurve = lanedata.heightCurve;


            if (lanedata.terrainTiles.Length > 0)
            {

                foreach (var item in lanedata.terrainTiles)
                {
                    if (item.position.X != -100)
                    {
                        // Add terrain connection
                        laneTerrainConnectionSpecs.Add(new LaneTerrainConnectionSpec(
                            new RelTile2i(item.position.X.ToIntCeiled(), item.position.Y.ToIntCeiled()),
                            //new RelTile2i(lanedata.LaneTrajectory.ControlPoints[0].X.ToIntCeiled(), lanedata.LaneTrajectory.ControlPoints[0].Y.ToIntCeiled()),
                            item.laneIndex,
                            isAtLaneStart: item.isAtStart
                        ));
                    }

                }
            }


            laneSpecs2.Add(new RoadLaneSpec(
                lanedata.LaneTrajectory,
                RelTile1f.Zero,
                heightCurve,
                lanedata.laneType1,
                lanedata.laneType2
            ));
        }
        immutableArray = ImmutableArray.CreateRange(laneSpecs2);
        terrainConnections = ImmutableArray.CreateRange(laneTerrainConnectionSpecs);

        if (!blRoadEntityProto.TryCreateLanes(immutableArray, out var lanesData, out var trajData, out var error, 30))
        {
            laneTrajectory = null;
            laneSpecs = null;
            laneMetaData = null;
            laneTerrainConnection = null;
            Log.Info("Failed to create road lanes: " + error);
            result = false;
            return false;
        }
        laneSpecs = ImmutableArray.CreateRange(laneSpecs2);
        laneMetaData = ImmutableArray.CreateRange<RoadLaneMetadata>(lanesData.ToArray());
        laneTrajectory = ImmutableArray.CreateRange<RoadLaneTrajectory>(trajData.ToArray());
        laneTerrainConnection = ImmutableArray.CreateRange<LaneTerrainConnectionSpec>(laneTerrainConnectionSpecs);
        result = true;
        return true;
    }
}
