﻿#pragma checksum "..\..\AddEditWindowTable1.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "730553922E330986C4954362CEF13113AA80F7653A6BCCEA4AE2046066A0654C"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Chronicles;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Chronicles {
    
    
    /// <summary>
    /// AddEditWindowTable1
    /// </summary>
    public partial class AddEditWindowTable1 : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\AddEditWindowTable1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TxtName;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\AddEditWindowTable1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TxtSurname;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\AddEditWindowTable1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TxtPatronymic;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\AddEditWindowTable1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CmbGender;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\AddEditWindowTable1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TxtPhone;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\AddEditWindowTable1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TxtAddress;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\AddEditWindowTable1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnSave;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Chronicles;component/addeditwindowtable1.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AddEditWindowTable1.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.TxtName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.TxtSurname = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.TxtPatronymic = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.CmbGender = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.TxtPhone = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.TxtAddress = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.BtnSave = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\AddEditWindowTable1.xaml"
            this.BtnSave.Click += new System.Windows.RoutedEventHandler(this.BtnSave_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

