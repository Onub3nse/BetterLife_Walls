using BetterLife;
using BetterLife.RoadsAndSigns;
using Mafi;
using Mafi.Core;
using Mafi.Core.Prototypes;
using Mafi.Unity;
using Mafi.Unity.Entities;
using Mafi.Unity.Entities.Static;
using System;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;

[GlobalDependency(RegistrationMode.AsAllInterfaces)]
public class blZipperMbFactory : IEntityMbFactory<blZipper>, IFactory<blZipper, EntityMb>
{

    private readonly ProtoModelFactory modelFactory;
    private readonly AssetsDb m_assetsDb;
    private readonly ProtosDb m_protoDb;

    public blZipperMbFactory(ProtoModelFactory mFactory, AssetsDb assetsDb, ProtosDb protosDb)
    {
        modelFactory = mFactory;
        m_assetsDb = assetsDb;
        m_protoDb = protosDb;
    }

    public EntityMb Create(blZipper balancerEnt)
    {
        Assert.That(balancerEnt).IsNotNull();
        GameObject gameObject = modelFactory.CreateModelFor(balancerEnt.Prototype);
        blZipperMb trMb = gameObject.AddComponent<blZipperMb>();
        trMb.Initialize(balancerEnt, m_assetsDb, m_protoDb);
        //Log.Info("MB for transport created...");
        return trMb;
    }
}
public static class insideGOUtility
{
    /// <summary>
    /// Finds the first material with the specified name from MeshRenderer components in a GameObject and its children.
    /// </summary>
    /// <param name="parent">The root GameObject to start the search from.</param>
    /// <param name="materialName">The name of the material to find.</param>
    /// <param name="includeInactive">Whether to include MeshRenderers on inactive GameObjects.</param>
    /// <returns>The first matching Material, or null if not found.</returns>

    public static Material FindMaterialByName(this GameObject parent, string materialName, bool includeInactive = false)
    {

        MeshRenderer[] renderers = parent.GetComponentsInChildren<MeshRenderer>(includeInactive);
        //Log.Info($"FindMaterialByName: Found {renderers.Length} MeshRenderers in {parent.name}.");



        string searchNameLower = materialName.Trim().ToLower();
        foreach (MeshRenderer renderer in renderers)
        {
            if (renderer != null && renderer.materials != null)
            {
                //      Log.Info($"FindMaterialByName: Processing MeshRenderer on {renderer.gameObject.name} with {renderer.sharedMaterials.Length} materials.");

                foreach (Material material in renderer.materials)
                {
                    if (material != null && material.name != null)
                    {
                        // Handle Unity's potential "(Instance)" suffix and trim whitespace
                        string materialNameLower = material.name.Replace("(Instance)", "").Trim().ToLower();
                        //            Log.Info($"FindMaterialByName: Checking material '{material.name}' (normalized: '{materialNameLower}') against search '{searchNameLower}'.");

                        if (materialNameLower.Contains(searchNameLower))
                        {
                            //              Log.Info($"FindMaterialByName: Matched material '{material.name}' on GameObject '{renderer.gameObject.name}'.");
                            return material;
                        }
                    }
                    else
                    {
                        //        Log.Info($"FindMaterialByName: Skipping null material or null material name in {renderer.gameObject.name}.");
                    }
                }
            }
            else
            {
                //    Log.Info($"FindMaterialByName: Skipping null MeshRenderer or sharedMaterials in {renderer?.gameObject.name ?? "null"}.");
            }
        }
        // Log.Info($"FindMaterialByName: Found {materials.Count} matching materials for '{materialName}'.");
        return null;
    }
    /// <summary>
    /// Finds the first component on a GameObject with the specified name in a GameObject and its children.
    /// </summary>
    /// <param name="parent">The root GameObject to start the search from.</param>
    /// <param name="gameObjectName">The name of the GameObject containing the component to find.</param>
    /// <param name="includeInactive">Whether to include components on inactive GameObjects.</param>
    /// <returns>The first matching Component, or null if not found.</returns>
    public static Component FindComponentByName(this GameObject parent, string gameObjectName, bool includeInactive = false)
    {
        // Validate input
        if (parent == null || string.IsNullOrEmpty(gameObjectName))
        {
            //Log.Info("FindComponentByName: Invalid input - null parent or empty GameObject name.");
            return null;
        }

        // Get all components of any type in the parent and its children
        Component[] components = parent.GetComponentsInChildren<Component>(includeInactive);
        //Log.Info($"FindComponentByName: Found {components.Length} components in {parent.name}.");

        string searchNameLower = gameObjectName.Trim().ToLower();
        foreach (Component component in components)
        {
            if (component != null)
            {
                // Get the GameObject's name and normalize it
                string goNameLower = component.gameObject.name.Trim().ToLower();
                //Log.Info($"FindComponentByName: Checking GameObject '{component.gameObject.name}' (normalized: '{goNameLower}') against search '{searchNameLower}'.");

                if (goNameLower.Contains(searchNameLower))
                {
                    //Log.Info($"FindComponentByName: Matched component '{component.GetType().Name}' on GameObject '{component.gameObject.name}'.");
                    return component;
                }
            }
            else
            {
                //Log.Info("FindComponentByName: Skipping null component.");
            }
        }

        //Log.Info($"FindComponentByName: No matching component found for GameObject name '{gameObjectName}'.");
        return null;
    }
}

public class blZipperMb : StaticEntityMb, IDestroyableEntityMb, IEntityMb, IEntityMbWithRenderUpdate, IEntityMbWithSyncUpdate
{
    //private GameObject insideGo;
    private Material gameObjectMaterial;
    private ColorRgba currentColor = ColorRgba.Magenta;

    //private AssetsDb m_assetsDb;
    //private ProtosDb m_protoDb;
    private blZipper thisEntity;
    private ProductQuantity lastProduct;
    private bool isInitialized;
    public Color emissionColor = Color.red;
    public float emissionStrength = 1.0f;
    private Option<TextMeshPro> m_signTextMeshA;
    private Option<TextMeshPro> m_signTextMeshB;
    private Transform tubez1;
    private Transform tubez2;
    private Transform tubez3;
    private Transform tubez4;

    private Transform tubex1;
    private Transform tubex2;
    private Transform tubex3;
    private Transform tubex4;

    private Transform vertube1;
    private Transform vertube2;
    private Transform vertube3;
    private Transform vertube4;

    //private bool tubez1Found = false;
    //private bool tubez2Found = false;
    //private bool tubex1Found = false;
    //private bool tubex2Found = false;
    //private GameObject insideGo;
    private bool txtFrontFound = false;
    private bool txtBackFound = false;
    public float currentEmissionStrength = 0.5f;
    public KeyValuePair<ColorRgba, float> newMyColor = new KeyValuePair<ColorRgba, float>(ColorRgba.Magenta, 1.0f);
    public int frameLimiter = 0;
    public AssetsDb m_assetsDb;
    public ProtosDb m_protoDb;

    public blZipperMb()
    : base()
    {
    }


    public void Initialize(blZipper btBalancerEntity, AssetsDb assetsDb, ProtosDb protosDb)
    {
        Assert.That(btBalancerEntity).IsNotNull();
        Initialize(btBalancerEntity);
        thisEntity = btBalancerEntity;
        m_assetsDb = assetsDb;
        m_protoDb = protosDb;
        lastProduct = ProductQuantity.None;
        frameLimiter = 0;


        Component txtA = gameObject.FindComponentByName("txtFront", true);
        Component txtB = gameObject.FindComponentByName("txtBack", true);

        Component tubez1g = gameObject.FindComponentByName("tubez1", true);
        Component tubez2g = gameObject.FindComponentByName("tubez2", true);
        Component tubez3g = gameObject.FindComponentByName("tubez3", true);
        Component tubez4g = gameObject.FindComponentByName("tubez4", true);

        Component tubex1g = gameObject.FindComponentByName("tubex1", true);
        Component tubex2g = gameObject.FindComponentByName("tubex2", true);
        Component tubex3g = gameObject.FindComponentByName("tubex3", true);
        Component tubex4g = gameObject.FindComponentByName("tubex4", true);

        Component vtube1g = gameObject.FindComponentByName("vertube1", true);
        Component vtube2g = gameObject.FindComponentByName("vertube2", true);
        Component vtube3g = gameObject.FindComponentByName("vertube3", true);
        Component vtube4g = gameObject.FindComponentByName("vertube4", true);

        if (tubez1g) tubez1 = tubez1g.GetComponent<Transform>();
        if (tubez2g) tubez2 = tubez2g.GetComponent<Transform>();
        if (tubez3g) tubez3 = tubez3g.GetComponent<Transform>();
        if (tubez4g) tubez4 = tubez4g.GetComponent<Transform>();

        if (tubex1g) tubex1 = tubex1g.GetComponent<Transform>();
        if (tubex2g) tubex2 = tubex2g.GetComponent<Transform>();
        if (tubex3g) tubex3 = tubex3g.GetComponent<Transform>();
        if (tubex4g) tubex4 = tubex4g.GetComponent<Transform>();

        if (vtube1g) vertube1 = vtube1g.GetComponent<Transform>();
        if (vtube2g) vertube2 = vtube2g.GetComponent<Transform>();
        if (vtube3g) vertube3 = vtube3g.GetComponent<Transform>();
        if (vtube4g) vertube4 = vtube4g.GetComponent<Transform>();



        if (txtA != null)
        {
            m_signTextMeshA = txtA.GetComponent<TextMeshPro>();
            txtFrontFound = true;
            orgTxtScale1 = m_signTextMeshA.Value.transform.localScale;
        }
        else
        {
            //Log.Info("Error, fix that, couldn't access txtFront gameobject...");
        }
        if (txtB != null)
        {
            m_signTextMeshB = txtB.GetComponent<TextMeshPro>();
            txtBackFound = true;
            orgTxtScale2 = m_signTextMeshB.Value.transform.localScale;
        }
        else
        {
            //Log.Info("Error, fix that, couldn't access txtBack gameobject...");
        }


        //Component[] components = gameObject.transform.GetComponentsInChildren<Renderer>();

        //foreach (Renderer comp in components)
        //{
        //    Material[] materials = comp.materials;
        //    foreach (Material material in materials) 
        //    {
        //        //Log.Info($"{material.name}");
        //    }
        //}

        gameObjectMaterial = gameObject.FindMaterialByName("color", false);

        if (gameObjectMaterial != null)
        {
            // Log.Info("gameObjectMaterial retrieved successfully.");
        }
        else
        {
            //Log.Info("Child 'color' found, but it has no Renderer component in prefab: ");
        }


        isInitialized = true;
        //Log.Info("isInitialized.. true");
        Assert.That(thisEntity).IsNotNull("thisEntity must be set after Initialize.");
    }
    private int everyFrames = 0;
    private string txtToShow;
    private float tubez1RotationSpeed = 4f;
    private Vector3 orgTxtScale1;
    private Vector3 orgTxtScale2;
    public void SyncUpdate(GameTime time)
    {



        if (thisEntity.currentThroughput > 0.Percent())
        {
            if (tubex1)
            {
                tubez1RotationSpeed = (float)thisEntity.currentThroughput.RawValue / 10;
                //Log.Info("Setting new speed!!!");
            }

        }

        if (tubez1) tubez1.Rotate(Vector3.forward, tubez1RotationSpeed);
        if (tubez2) tubez2.Rotate(Vector3.back, tubez1RotationSpeed);
        if (tubez3) tubez3.Rotate(Vector3.forward, tubez1RotationSpeed);
        if (tubez4) tubez4.Rotate(Vector3.back, tubez1RotationSpeed);

        if (tubex1) tubex1.Rotate(Vector3.left, tubez1RotationSpeed);
        if (tubex2) tubex2.Rotate(Vector3.right, tubez1RotationSpeed);
        if (tubex3) tubex3.Rotate(Vector3.left, tubez1RotationSpeed);
        if (tubex4) tubex4.Rotate(Vector3.right, tubez1RotationSpeed);

        if (vertube1) vertube1.Rotate(tubez1RotationSpeed, 0, 0);
        if (vertube2) vertube2.Rotate(tubez1RotationSpeed, 0, 0);
        if (vertube3) vertube3.Rotate(tubez1RotationSpeed, 0, 0);
        if (vertube4) vertube4.Rotate(tubez1RotationSpeed, 0, 0);

        if (txtFrontFound == true && txtBackFound == true)
        {
            if (everyFrames < 5)
            {
                everyFrames += 1;
                return;
            }
            everyFrames = 0;

            if (thisEntity.currentProduct.IsNotEmpty)
            {
                lastProduct = thisEntity.currentProduct;
                txtToShow = lastProduct.Product.Strings.Name.ToString();
            }
            else
            {
                txtToShow = lastProduct.IsNotEmpty ? lastProduct.Product.Strings.Name.ToString() : "Waiting for product";
            }
            string txt = txtToShow;
            TextInfo txtInfo = CultureInfo.CurrentCulture.TextInfo;
            m_signTextMeshA.Value.text = txtInfo.ToTitleCase(txt.ToLower());
            m_signTextMeshB.Value.text = txtInfo.ToTitleCase(txt.ToLower());
            if (thisEntity.Transform.IsReflected)
            {
                m_signTextMeshA.Value.transform.localScale = new Vector3(-orgTxtScale1.x, orgTxtScale1.y, orgTxtScale1.z);
                m_signTextMeshB.Value.transform.localScale = new Vector3(-orgTxtScale2.x, orgTxtScale2.y, orgTxtScale2.z);
            }
            //if (thisEntity.Prototype.isFlipped)
            //{
            //    m_signTextMeshA.Value.transform.localScale = new Vector3(-orgTxtScale1.x, orgTxtScale1.y, orgTxtScale1.z);
            //    m_signTextMeshB.Value.transform.localScale = new Vector3(-orgTxtScale2.x, orgTxtScale2.y, orgTxtScale2.z);
            //}

        }
    }
    public void RenderUpdate(GameTime time)
    {
        if (time.IsGamePaused || !isInitialized) return;
        frameLimiter += 1;
        if (frameLimiter < 2) return;
        frameLimiter = 0;
        try
        {
            if (thisEntity == null)
            {
                //Log.Info("thisEntity is null in SyncUpdate.");
                return;
            }
            //Log.Info("getting main texture...");
            if (gameObjectMaterial == null)
            {
                // Log.Info("gameObjectMaterial is null, cannot access mainTexture.");
                return;
            }
            //Texture pMaterial = gameObjectMaterial.mainTexture;
            //Log.Info("checking color...");

            if (thisEntity.newMyColor.Value > 0.0f)
            {
                currentEmissionStrength = thisEntity.newMyColor.Value - 0.75f;
                thisEntity.newMyColor = new KeyValuePair<ColorRgba, float>(thisEntity.newMyColor.Key, currentEmissionStrength);
                //   Log.Info($"Material with color found {gameObjectMaterial.Length.ToString()}");

                gameObjectMaterial.SetColor("_Color", thisEntity.newMyColor.Key.ToColor() * Mathf.LinearToGammaSpace(currentEmissionStrength));
                gameObjectMaterial.SetColor("_EmissiveColor", thisEntity.newMyColor.Key.ToColor() * Mathf.LinearToGammaSpace(thisEntity.newMyColor.Value));

            }
            //if (currentColor != thisEntity.newMyColor.Key)
            //{
            //    gameObjectMaterial.SetColor("_Color", thisEntity.myColor.ToColor() * Mathf.LinearToGammaSpace(thisEntity.newMyColor.Value));
            //    gameObjectMaterial.SetColor("_EmissiveColor", thisEntity.myColor.ToColor() * Mathf.LinearToGammaSpace(thisEntity.newMyColor.Value));
            //    if (thisEntity.newMyColor.Value > 0.7f)
            //    {
            //        currentEmissionStrength = thisEntity.newMyColor.Value;
            //    }
            //    currentColor = thisEntity.myColor;

            //}

            //gameObjectMaterial.color = thisEntity.myColor.ToColor();
            //Log.Info("color changed in mb...");

        }
        catch (Exception e)
        {
            Log.Info($"MB->{e.Message} {e.Source} {e.InnerException} {e.TargetSite}");
        }
    }
}
