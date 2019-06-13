//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2011 , Rising TECH, Ltd. 
//-----------------------------------------------------------------

using System;

namespace Rising.Utilities
{
    /// <summary>
    /// EnumDescription
    /// 枚举状态的说明。
    /// 
    /// 修改纪录
    /// 
    ///		2011.10.13 版本：1.0 JiRiGaLa 创建。
    ///		
    /// 版本：1.0
    /// 
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2011.10.13</date>
    /// </author> 
    /// </summary>    
    public class EnumDescription : Attribute { public string Text { get { return _text; } } private string _text; public EnumDescription(string text) { _text = text; } }
}