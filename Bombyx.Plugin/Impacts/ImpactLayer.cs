﻿using System;
using Grasshopper.Kernel;

namespace Bombyx.Plugin.Impacts
{
    public class ImpactLayer : GH_Component
    {
        public ImpactLayer()
          : base("Layer impact",
                 "Layer impact",
                 "Calculates impacts of PE, GWP, UBP",
                 "Bombyx",
                 "Impacts")
        {
        }

        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddNumberParameter("PEnr(Emb)", "PEnr(Emb kWh oil-eq)", "Number value", GH_ParamAccess.item, 0d);
            pManager.AddNumberParameter("PEnr(EoL)", "PEnr(EoL kWh oil-eq)", "Number value", GH_ParamAccess.item, 0d);
            pManager.AddNumberParameter("GWP(Emb)", "GWP(Emb kg CO\x2082-eq)", "Number value", GH_ParamAccess.item, 0d);
            pManager.AddNumberParameter("GWP(EoL)", "GWP(EoL kg CO\x2082-eq)", "Number value", GH_ParamAccess.item, 0d);
            pManager.AddNumberParameter("UBP(Emb)", "UBP(Emb)", "Number value", GH_ParamAccess.item, 0d);
            pManager.AddNumberParameter("UBP(EoL)", "UBP(EoL)", "Number value", GH_ParamAccess.item, 0d);
            pManager.AddNumberParameter("Density", "Density (kg/m\xB3)", "Number value", GH_ParamAccess.item);
            pManager.AddNumberParameter("Thickness (meters)", "Thickness (m)", "Number value", GH_ParamAccess.item);

            pManager[0].Optional = true;
            pManager[1].Optional = true;
            pManager[2].Optional = true;
            pManager[3].Optional = true;
            pManager[4].Optional = true;
            pManager[5].Optional = true;
        }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddNumberParameter("PEnr(Emb)", "PEnr(Emb kWh oil-eq)", "Number value", GH_ParamAccess.item);
            pManager.AddNumberParameter("PEnr(EoL)", "PEnr(EoL kWh oil-eq)", "Number value", GH_ParamAccess.item);
            pManager.AddNumberParameter("GWP(Emb)", "GWP(Emb kg CO\x2082-eq)", "Number value", GH_ParamAccess.item);
            pManager.AddNumberParameter("GWP(EoL)", "GWP(EoL kg CO\x2082-eq)", "Number value", GH_ParamAccess.item);
            pManager.AddNumberParameter("UBP(Emb)", "UBP(Emb)", "Number value", GH_ParamAccess.item);
            pManager.AddNumberParameter("UBP(EoL)", "UBP(EoL)", "Number value", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            var PEnrEmb = 0d;
            if (!DA.GetData(0, ref PEnrEmb)) { return; }
            var PEnrEoL = 0d;
            if (!DA.GetData(1, ref PEnrEoL)) { return; }
            var GWPEmb = 0d;
            if (!DA.GetData(2, ref GWPEmb)) { return; }
            var GWPEoL = 0d;
            if (!DA.GetData(3, ref GWPEoL)) { return; }
            var UBPEmb = 0d;
            if (!DA.GetData(4, ref UBPEmb)) { return; }
            var UBPEoL = 0d;
            if (!DA.GetData(5, ref UBPEoL)) { return; }
            var Density = 0d;
            if (!DA.GetData(6, ref Density)) { return; }
            var Thickness = 0d;
            if (!DA.GetData(7, ref Thickness)) { return; }

            var AreaDensity = 0d;

            if(Density == 0)
            {
                AreaDensity = Thickness;
            }
            else
            {
                AreaDensity = Density * Thickness;
            }


            DA.SetData("PEnr(Emb)", AreaDensity * PEnrEmb);
            DA.SetData("PEnr(EoL)", AreaDensity * PEnrEoL);
            DA.SetData("GWP(Emb)", AreaDensity * GWPEmb);
            DA.SetData("GWP(EoL)", AreaDensity * GWPEoL);
            DA.SetData("UBP(Emb)", AreaDensity * UBPEmb);
            DA.SetData("UBP(EoL)", AreaDensity * UBPEoL);
        }

        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                return Icons.impactLayer;
            }
        }

        public override Guid ComponentGuid
        {
            get { return new Guid("0e2d021d-4899-4b4b-bdd7-062f1ff3066b"); }
        }
    }
}