﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Composition;
using System.Numerics;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

namespace CompositionSampleGallery.Samples.LightInterop
{
    public class AmbLight : XamlLight
    {
        private static readonly string Id = typeof(AmbLight).FullName;

        protected override void OnConnected(UIElement newElement)
        {
            Compositor compositor = Window.Current.Compositor;

            // Create AmbientLight and set its properties
            AmbientLight ambientLight = compositor.CreateAmbientLight();
            ambientLight.Color = Colors.White;

            // Associate CompositionLight with XamlLight
            CompositionLight = ambientLight;

            // Add UIElement to the Light's Targets
            AmbLight.AddTargetElement(GetId(), newElement);
        }

        protected override void OnDisconnected(UIElement oldElement)
        {
            // Dispose Light when it is removed from the tree
            AmbLight.RemoveTargetElement(GetId(), oldElement);
            CompositionLight.Dispose();
        }

        protected override string GetId()
        {
            return Id;
        }  
    }
}