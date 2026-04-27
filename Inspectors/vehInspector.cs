//using UnityEngine.UIElements;
using BetterLife.RoadsAndSigns;
using Mafi;
using Mafi.Collections;
using Mafi.Core;
using Mafi.Core.Syncers;
using Mafi.Localization;
using Mafi.Unity.Ui;
using Mafi.Unity.Ui.Library.Inspectors;
using Mafi.Unity.UiToolkit.Component;
using Mafi.Unity.UiToolkit.Library;
using System;

namespace BetterLife.Inspectors
{


    //internal class transPORTInspector : BaseInspector<btBalancer>
    //{
    //    public transPORTInspector(UiContext context) : base(context)
    //    {
    //        Label inputBufLabel = new Label().FontBold();
    //        Label outputBufLabel = new Label().FontBold();
    //        WindowSize(400.px(), Px.Auto);
    //        AddPanelWithHeader(inputBufLabel)
    //            .Title("transPORT".AsLoc());


    //        AddPanel(outputBufLabel);
    //        Mafi.Core.Products.ProductProto outProduct = Entity.ProvidedProduct.Value;
    //        this.Observe(() => Entity.m_quantityInInputBuffer)
    //           .Do(inpBuf => inputBufLabel.Value($"Product Input: {inpBuf:F0} ".AsLoc()));
    //        this.Observe(() => Entity.m_quantityInOutputBuffer)
    //           .Do(outBuf => outputBufLabel.Value($"Product Output: {outBuf:F0} ".AsLoc()));

    //    }
    //}

    //[GlobalDependency(RegistrationMode.AsAllInterfaces, false, false)]
    //internal class transpInspector : BaseInspector<btBalancer>
    //{
    //    public transpInspector(UiContext context) : base(context)
    //    {
    //        this.HeaderPanel.RemoveFromHierarchy();
    //        BufferWithMultipleProductsUi bufferWithMultipleProductsUi = new BufferWithMultipleProductsUi(false);
    //        base.AddPanelWithHeader(new UiComponent[] { bufferWithMultipleProductsUi }).Title(Tr.TransportedProducts);
    //        Lyst<ProductQuantity> productsCache = new Lyst<ProductQuantity>();
    //        this.ObserveIndexable(delegate
    //        {
    //            this.Entity.GetAllBufferedProducts(productsCache.ClearAndReturn());
    //            return productsCache;
    //        }).Observe<Quantity>(() => base.Entity.MaxBufferSize).DoOnSync(new Action<Lyst<ProductQuantity>, Quantity>(bufferWithMultipleProductsUi.SetProducts));
    //        bufferWithMultipleProductsUi.AddQuickRemoveButton(context.InputScheduler, () => (Mafi.Core.Entities.Static.IEntityWithQuickRemove)base.Entity);
    //    }
    //}
}

