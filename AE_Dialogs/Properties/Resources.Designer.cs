﻿//------------------------------------------------------------------------------
// <auto-generated>
//     このコードはツールによって生成されました。
//     ランタイム バージョン:4.0.30319.42000
//
//     このファイルへの変更は、以下の状況下で不正な動作の原因になったり、
//     コードが再生成されるときに損失したりします。
// </auto-generated>
//------------------------------------------------------------------------------

namespace bryful_due.Properties {
    using System;
    
    
    /// <summary>
    ///   ローカライズされた文字列などを検索するための、厳密に型指定されたリソース クラスです。
    /// </summary>
    // このクラスは StronglyTypedResourceBuilder クラスが ResGen
    // または Visual Studio のようなツールを使用して自動生成されました。
    // メンバーを追加または削除するには、.ResX ファイルを編集して、/str オプションと共に
    // ResGen を実行し直すか、または VS プロジェクトをビルドし直します。
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   このクラスで使用されているキャッシュされた ResourceManager インスタンスを返します。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("bryful_due.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   すべてについて、現在のスレッドの CurrentUICulture プロパティをオーバーライドします
        ///   現在のスレッドの CurrentUICulture プロパティをオーバーライドします。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   //-------------------------------------------------------------------------
        ///$data
        /////-------------------------------------------------------------------------
        ///var $objName = new Window(&quot;$windowType&quot;, &quot;$title&quot;, $bounds $option);
        /////-------------------------------------------------------------------------
        ///$build
        /////-------------------------------------------------------------------------
        ///$center$objName.center(); 
        ///$objName.show();
        /////----------------------------------------------------------------------- [残りの文字列は切り詰められました]&quot;; に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string BaseDialog {
            get {
                return ResourceManager.GetString("BaseDialog", resourceCulture);
            }
        }
        
        /// <summary>
        ///   function $funcName()
        ///{
        ///	//-------------------------------------------------------------------------
        ///$data
        ///	//-------------------------------------------------------------------------
        ///	$var$this$objName = new Window(&quot;$windowType&quot;, &quot;$title&quot;, $bounds $option);
        ///	//-------------------------------------------------------------------------
        ///$build
        ///	//-------------------------------------------------------------------------
        ///	this.show = function()
        ///	{
        ///		$center$this$objName.center(); 
        ///		return $this$objNa [残りの文字列は切り詰められました]&quot;; に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string BaseDialogInFunc {
            get {
                return ResourceManager.GetString("BaseDialogInFunc", resourceCulture);
            }
        }
        
        /// <summary>
        ///   //-------------------------------------------------------------------------
        ///$data
        /////-------------------------------------------------------------------------
        ///var $objName = ( this instanceof Panel) ? me : new Window(&quot;palette&quot;, &quot;$title&quot;, $bounds $option);
        /////-------------------------------------------------------------------------
        ///$build
        /////-------------------------------------------------------------------------
        ///if ( ( this instanceof Panel) == false){
        ///	$center$objName.center(); 
        ///	$objName.show();
        ///} [残りの文字列は切り詰められました]&quot;; に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string BaseFloatingPalette {
            get {
                return ResourceManager.GetString("BaseFloatingPalette", resourceCulture);
            }
        }
        
        /// <summary>
        ///   (function(me){
        ///$data
        ///	//-------------------------------------------------------------------------
        ///	var $objName = ( me instanceof Panel) ? me : new Window(&quot;palette&quot;, &quot;$title&quot;, $bounds $option);
        ///	//-------------------------------------------------------------------------
        ///$build
        ///	//-------------------------------------------------------------------------
        ///	if ( ( me instanceof Panel) == false){
        ///		$center$objName.center(); 
        ///		$objName.show();
        ///	}
        ///	//---------------------------------------------------- [残りの文字列は切り詰められました]&quot;; に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string BaseFloatingPaletteInFunc {
            get {
                return ResourceManager.GetString("BaseFloatingPaletteInFunc", resourceCulture);
            }
        }
    }
}
