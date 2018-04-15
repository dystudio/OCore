﻿using Microsoft.AspNetCore.Mvc.ApplicationModels;
using XCore.Environment.Extensions;
using XCore.Environment.Extensions.Features;

namespace XCore.Mvc
{
    /// <summary>
    /// Adds an area route constraint using the name of the module.
    /// </summary>
    public class ModularApplicationModelProvider : IApplicationModelProvider
    {
        private readonly ITypeFeatureProvider _provider;

        public ModularApplicationModelProvider(ITypeFeatureProvider provider)
        {
            _provider = provider;
        }

        public int Order
        {
            get
            {
                return 1000;
            }
        }

        public void OnProvidersExecuted(ApplicationModelProviderContext context)
        {
            // This code is called only once per tenant during the construction of routes
            foreach (var controller in context.Result.Controllers)
            {
                var controllerType = controller.ControllerType.AsType();
                var blueprint = _provider.GetFeatureForDependency(controllerType);
                if (blueprint != null)
                {
                    controller.RouteValues.Add("area", blueprint.Extension.Id);
                }
            }
        }

        public void OnProvidersExecuting(ApplicationModelProviderContext context)
        {
        }
    }
}
