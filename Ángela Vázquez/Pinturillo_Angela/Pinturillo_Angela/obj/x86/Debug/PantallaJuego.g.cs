﻿#pragma checksum "D:\GIT\DesarrolloDeInterfaces\Pinturillo_Angela\Pinturillo_Angela\PantallaJuego.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "7A55D676216604F4E8DA26DB4FB46516"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Pinturillo_Angela
{
    partial class PantallaJuego : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private static class XamlBindingSetters
        {
            public static void Set_Windows_UI_Xaml_Controls_InkToolbar_TargetInkCanvas(global::Windows.UI.Xaml.Controls.InkToolbar obj, global::Windows.UI.Xaml.Controls.InkCanvas value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::Windows.UI.Xaml.Controls.InkCanvas) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::Windows.UI.Xaml.Controls.InkCanvas), targetNullValue);
                }
                obj.TargetInkCanvas = value;
            }
        };

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private class PantallaJuego_obj1_Bindings :
            global::Windows.UI.Xaml.Markup.IDataTemplateComponent,
            global::Windows.UI.Xaml.Markup.IXamlBindScopeDiagnostics,
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            IPantallaJuego_Bindings
        {
            private global::Pinturillo_Angela.PantallaJuego dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);

            // Fields for each control that has bindings.
            private global::Windows.UI.Xaml.Controls.InkToolbar obj11;

            // Static fields for each binding's enabled/disabled state
            private static bool isobj11TargetInkCanvasDisabled = false;

            public PantallaJuego_obj1_Bindings()
            {
            }

            public void Disable(int lineNumber, int columnNumber)
            {
                if (lineNumber == 162 && columnNumber == 11)
                {
                    isobj11TargetInkCanvasDisabled = true;
                }
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 11: // PantallaJuego.xaml line 159
                        this.obj11 = (global::Windows.UI.Xaml.Controls.InkToolbar)target;
                        break;
                    default:
                        break;
                }
            }

            // IDataTemplateComponent

            public void ProcessBindings(global::System.Object item, int itemIndex, int phase, out int nextPhase)
            {
                throw new global::System.NotImplementedException();
            }

            public void Recycle()
            {
                throw new global::System.NotImplementedException();
            }

            // IPantallaJuego_Bindings

            public void Initialize()
            {
                if (!this.initialized)
                {
                    this.Update();
                }
            }
            
            public void Update()
            {
                this.Update_(this.dataRoot, NOT_PHASED);
                this.initialized = true;
            }

            public void StopTracking()
            {
            }

            public void DisconnectUnloadedObject(int connectionId)
            {
                throw new global::System.ArgumentException("No unloadable elements to disconnect.");
            }

            public bool SetDataRoot(global::System.Object newDataRoot)
            {
                if (newDataRoot != null)
                {
                    this.dataRoot = (global::Pinturillo_Angela.PantallaJuego)newDataRoot;
                    return true;
                }
                return false;
            }

            public void Loading(global::Windows.UI.Xaml.FrameworkElement src, object data)
            {
                this.Initialize();
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::Pinturillo_Angela.PantallaJuego obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_inkCanvas(obj.inkCanvas, phase);
                    }
                }
            }
            private void Update_inkCanvas(global::Windows.UI.Xaml.Controls.InkCanvas obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // PantallaJuego.xaml line 159
                    if (!isobj11TargetInkCanvasDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_InkToolbar_TargetInkCanvas(this.obj11, obj, null);
                    }
                }
            }
        }
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // PantallaJuego.xaml line 13
                {
                    this.borderStackPanel = (global::Windows.UI.Xaml.Controls.Border)(target);
                }
                break;
            case 3: // PantallaJuego.xaml line 76
                {
                    this.borderCanvas = (global::Windows.UI.Xaml.Controls.Border)(target);
                }
                break;
            case 4: // PantallaJuego.xaml line 172
                {
                    this.chatMensajes = (global::Windows.UI.Xaml.Controls.ListView)(target);
                }
                break;
            case 5: // PantallaJuego.xaml line 220
                {
                    this.inputMensajes = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 6: // PantallaJuego.xaml line 232
                {
                    this.btnSend = (global::Windows.UI.Xaml.Controls.Button)(target);
                }
                break;
            case 7: // PantallaJuego.xaml line 244
                {
                    this.backArrow = (global::Windows.UI.Xaml.Shapes.Path)(target);
                    ((global::Windows.UI.Xaml.Shapes.Path)this.backArrow).RightTapped += this.BackArrow_RightTapped;
                }
                break;
            case 9: // PantallaJuego.xaml line 104
                {
                    this.palabra = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 10: // PantallaJuego.xaml line 149
                {
                    this.inkCanvas = (global::Windows.UI.Xaml.Controls.InkCanvas)(target);
                }
                break;
            case 11: // PantallaJuego.xaml line 159
                {
                    this.inkToolbar = (global::Windows.UI.Xaml.Controls.InkToolbar)(target);
                }
                break;
            case 12: // PantallaJuego.xaml line 24
                {
                    this.stkpanelListados = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 13: // PantallaJuego.xaml line 31
                {
                    this.listadoSalas = (global::Windows.UI.Xaml.Controls.ListView)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            switch(connectionId)
            {
            case 1: // PantallaJuego.xaml line 1
                {                    
                    global::Windows.UI.Xaml.Controls.Page element1 = (global::Windows.UI.Xaml.Controls.Page)target;
                    PantallaJuego_obj1_Bindings bindings = new PantallaJuego_obj1_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot(this);
                    this.Bindings = bindings;
                    element1.Loading += bindings.Loading;
                    global::Windows.UI.Xaml.Markup.XamlBindingHelper.SetDataTemplateComponent(element1, bindings);
                }
                break;
            }
            return returnValue;
        }
    }
}

