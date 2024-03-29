﻿using FrostAura.Libraries.Components.Shared.Interfaces.Versioning;
using FrostAura.Libraries.Components.Shared.Models.Configuration;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;

namespace FrostAura.Libraries.Components.Shared.Abstractions
{
    /// <summary>
    /// FrostAura base component for core and shared functionality.
    /// </summary>
    public abstract class BaseComponent<TComponentType> : ComponentBase, IRequiresVersioning
    {
        /// <summary>
        /// Unique component instance identifier.
        /// </summary>
        [Parameter]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        /// <summary>
        /// The current version of the component.
        /// </summary>
        public abstract Version Version { get; }
        /// <summary>
        /// Whether to enable demo defaults for this component.
        /// </summary>
        [Parameter]
        public bool EnableDemoMode { get; set; }
        /// <summary>
        /// Navigation manager.
        /// </summary>
        [Inject]
        protected NavigationManager NavigationManager { get; set; }
        /// <summary>
        /// Instance logger.
        /// </summary>
        [Inject]
        protected ILogger<TComponentType> Logger { get; set; }
        /// <summary>
        /// JavaScript runtime engine.
        /// </summary>
        [Inject]
        protected IJSRuntime JsRuntime { get; set; }

        /// <summary>
        /// Navigate to a relative path safely.
        /// </summary>
        /// <param name="relativePath">The relative path to navigate to. Example: "/components"</param>
        protected void SafelyNavigateTo(string relativePath)
        {
            var fullAddress = Path.Combine(FrostAuraApplicationConfiguration.AppBaseUrl, relativePath);

            NavigationManager.NavigateTo(fullAddress);
        }
    }
}

