using Mafi;
using Mafi.Unity.Ui;
using Mafi.Unity.UiToolkit.Component;
using System;

namespace BetterLife.RoadsAndSigns
{
    [GlobalDependency(RegistrationMode.AsEverything)]
    public class myEntityPlacer
    {
        private readonly blLayoutEntityToolbox m_toolbox;
        public myEntityPlacer(UiContext uiContext, NewInstanceOf<blLayoutEntityToolbox> toolbox)
        {
            this.m_toolbox = toolbox.Instance;
            //this.m_toolbox.SetOnRotate(new Action(this.rotate));
            //this.m_toolbox.SetOnFlip(new Action(this.flip));
            //this.m_toolbox.SetOnUp(new Func<bool?>(this.cursorUp));
            //this.m_toolbox.SetOnDown(new Func<bool?>(this.cursorDown));
            //this.m_toolbox.SetOnToggleZipperPlacement(new Action(this.toggleZipperPlacement));

        }
        public void Deactivate(bool playSound = false)
        {
            //if (!this.IsActive)
            //{
            //    Log.Warning("LayoutEntityPlacer is already deactivated.");
            //    return;
            //}
            //this.m_owner = Option<object>.None;
            //this.m_historyOffsetFromEnd = 0;
            //this.m_accScrollOffset = 0f;
            //this.m_buildModesStripsActivator.DeactivateDec();
            //if (this.m_entityPreviews.IsNotEmpty || playSound)
            //{
            //    this.m_unselectEntitySound.Play();
            //}
            //Action valueOrNull = this.m_onCancelled.ValueOrNull;
            //if (valueOrNull != null)
            //{
            //    valueOrNull();
            //}
            //this.m_onCancelled = Option<Action>.None;
            //this.m_onEntityPlaced = Option<Action>.None;
            //this.m_helper.Deactivate();
            this.m_toolbox.Hide<blLayoutEntityToolbox>();
            //this.clearPreviews();
            //this.clearPortHighlights();
            //this.m_cursor.Hide();
            //this.m_pricePopup.Hide<DockedBuyPricePopup>();
            //this.m_pricePopup.Label(LocStrFormatted.Empty);
            //this.m_warningPopup.Hide<HudLabelPopup>();
            //this.m_cursorMessage.Hide();
            //this.m_terrainCursor.Deactivate();
            //this.m_towerAreasAndDesignatorsActivator.DeactivateIfActive();
            //this.m_logisticsZonesRenderer.DecShowAll();
            //this.m_treeDesignationActivator.DeactivateIfActive();
            //this.m_oceanAreasActivator.DeactivateIfActive();
            //this.m_resVisActivator.HideAll();
            //this.m_liftPlacementHelper.Deactivate();
            //this.m_trainTracksPreviewGraphManager.Deactivate();
        }

        public void Activate(object owner, Action onEntityPlaced = null, Action onCancel = null)
        {
            //if (this.m_owner.HasValue)
            //{
            //    Log.Warning("LayoutEntityPlacer is already activated by '" + this.m_owner.Value.GetType().Name + "'.");
            //    return;
            //}
            //this.m_owner = owner;
            //this.m_onEntityPlaced = onEntityPlaced;
            //this.m_onCancelled = onCancel;
            //this.clearPreviews();
            this.m_toolbox.Show<blLayoutEntityToolbox>();
            //this.m_cursor.Show();
            //this.m_terrainCursor.Activate();
            //this.m_liftPlacementHelper.Activate();
            //this.m_trainTracksPreviewGraphManager.Activate();
            //this.m_buildModesStripsActivator.ActivateInc();
            //this.m_logisticsZonesRenderer.IncShowAll();
        }

        //        public void ApplyTransform(TileTransform oldTransform)
        //        {
        //            if (this.m_singleEntityMode && this.m_entityPreviews.Count == 1)
        //            {
        //                IStaticEntityPreviewDirect staticEntityPreviewDirect = this.m_entityPreviews.First.Key as IStaticEntityPreviewDirect;
        //                if (staticEntityPreviewDirect != null && !(this.m_entityPreviews.First.Key.EntityProto is EntityWithTrainTrackBaseProto))
        //                {
        //                    staticEntityPreviewDirect.SetTransform(this.m_helper.Transform);
        //                    goto IL_0223;
        //                }
        //            }
        //            RelTile3i relTile3i = this.m_helper.Transform.Position - oldTransform.Position;
        //            Rotation90 rotation = this.m_helper.Transform.Rotation - oldTransform.Rotation;
        //            bool flag = this.m_helper.Transform.IsReflected ^ oldTransform.IsReflected;
        //            Tile2i xy = oldTransform.Position.Xy;
        //            foreach (KeyValuePair<IStaticEntityPreview, EntityConfigData> keyValuePair in this.m_entityPreviews)
        //            {
        //                keyValuePair.Key.ApplyTransformDelta(relTile3i, rotation, flag, xy);
        //            }
        //            this.m_trainTracksPreviewGraphManager.ApplyTransformDelta(relTile3i, rotation, flag, xy);
        //            if (this.m_surfacesToAdd.IsNotEmpty)
        //            {
        //                for (int i = 0; i < this.m_surfacesToAdd.Count; i++)
        //                {
        //                    this.m_surfacesToAdd[i] = this.m_surfacesToAdd[i].ApplyTransformDelta(relTile3i, rotation, flag, xy);
        //                }
        //                Tile3i tile3i = Tile3i.MaxValue;
        //                Tile2i tile2i = Tile2i.MinValue;
        //                foreach (TileSurfaceCopyPasteData tileSurfaceCopyPasteData in this.m_surfacesToAdd)
        //                {
        //                    tile3i = tile3i.Min(tileSurfaceCopyPasteData.Position.ExtendZ(0));
        //                    tile2i = tile2i.Max(tileSurfaceCopyPasteData.Position);
        //                }
        //                this.m_surfacePlacementArea = new RectangleTerrainArea2i(tile3i.Xy, tile2i - tile3i.Xy + RelTile2i.One);
        //                if (flag || rotation.AngleIndex != 0)
        //                {
        //                    this.updateSurfacePreview();
        //                    this.m_terrainRenderer.SetSurfacePastePreviewData(this.m_surfacePlacementArea, this.m_surfacePreviewData, true);
        //                }
        //                else
        //                {
        //                    this.m_terrainRenderer.SetSurfacePastePreviewData(this.m_surfacePlacementArea, this.m_surfacePreviewData, false);
        //                }
        //            }
        //        IL_0223:
        //            this.updateLastTransformStore();
        //        }

        //        private void rotate()
        //        {
        //            TileTransform transform = this.m_helper.Transform;
        //            if (!this.m_helper.SetRotation(this.m_helper.LastSetRotation.RotatedMinus90))
        //            {
        //                return;
        //            }
        //            this.ApplyTransform(transform);
        //            this.m_rotateSound.Play();
        //        }
        //        private void flip()
        //        {
        //            if (!this.m_isFlipAllowed)
        //            {
        //                this.m_invalidSound.Play();
        //                return;
        //            }
        //            float y = this.m_cameraController.EyeDirectionEulerAngles.y;
        //            bool flag = ((y > 45f && y < 135f) || (y > 225f && y < 315f)) != this.m_helper.LastSetRotation.Is90Or270Deg;
        //            if (Input.GetKey(KeyCode.LeftShift))
        //            {
        //                flag = !flag;
        //            }
        //            TileTransform transform = this.m_helper.Transform;
        //            if (!this.m_helper.SetReflection(!this.m_helper.LastSetReflection))
        //            {
        //                return;
        //            }
        //            if (flag)
        //            {
        //                this.m_helper.SetRotation(this.m_helper.LastSetRotation + Rotation90.Deg180);
        //            }
        //            this.ApplyTransform(transform);
        //            this.m_rotateSound.Play();
        //        }
        //        private bool? cursorUp()
        //        {
        //            if (this.m_terrainCursor.RelativeHeight < this.m_allowedHeightRange.To)
        //            {
        //                this.m_terrainCursor.RelativeHeight += ThicknessTilesI.One;
        //                return new bool?(true);
        //            }
        //            if (this.m_placementPhase == EntityPlacementPhase.Final && this.m_phase2RelativeHeight + this.m_lastHeightDelta < this.m_allowedHeightRange.To)
        //            {
        //                this.m_terrainCursor.RelativeHeight += ThicknessTilesI.One;
        //                return new bool?(true);
        //            }
        //            bool flag = true;
        //            foreach (KeyValuePair<IStaticEntityPreview, EntityConfigData> keyValuePair in this.m_entityPreviews)
        //            {
        //                if (keyValuePair.Key.ValidationResult == null)
        //                {
        //                    return null;
        //                }
        //                if (keyValuePair.Key.ValidationResult.Value.IsSuccess && keyValuePair.Key.CanMoveUpDownIfValid())
        //                {
        //                    flag = false;
        //                    break;
        //                }
        //            }
        //            if (!flag)
        //            {
        //                this.m_terrainCursor.RelativeHeight += ThicknessTilesI.One;
        //                return new bool?(true);
        //            }
        //            return new bool?(false);
        //        }
        //        private bool? cursorDown()
        //        {
        //            if (this.m_terrainCursor.RelativeHeight > this.m_allowedHeightRange.From)
        //            {
        //                this.m_terrainCursor.RelativeHeight -= ThicknessTilesI.One;
        //                return new bool?(true);
        //            }
        //            bool flag = true;
        //            foreach (KeyValuePair<IStaticEntityPreview, EntityConfigData> keyValuePair in this.m_entityPreviews)
        //            {
        //                if (keyValuePair.Key.ValidationResult == null)
        //                {
        //                    return null;
        //                }
        //                if (keyValuePair.Key.ValidationResult.Value.IsSuccess && keyValuePair.Key.CanMoveUpDownIfValid())
        //                {
        //                    flag = false;
        //                    break;
        //                }
        //            }
        //            if (!flag)
        //            {
        //                this.m_terrainCursor.RelativeHeight -= ThicknessTilesI.One;
        //                return new bool?(true);
        //            }
        //            return new bool?(false);
        //        }
        //        private void toggleZipperPlacement()
        //        {
        ////            Log.Error("Not implemented toggle zipper placement");
        //        }


    }
}
