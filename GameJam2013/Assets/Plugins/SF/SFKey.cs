/**********************************************************************

Filename    :	SFKey.cs
Content     :	Wrapper for Scaleform Key Input
Created     :   
Authors     :   Ankur Mohan

Copyright   :   Copyright 2012 Autodesk, Inc. All Rights reserved.

Use of this software is subject to the terms of the Autodesk license
agreement provided at the time of installation or download, or which
otherwise accompanies this software in either electronic or hard copy form.
 
***********************************************************************/

using UnityEngine;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Scaleform
{
    
public class SFKeyModifiers
{
    public SFKeyModifiers() { /* States = 0; */ }
    public enum Modifiers
    {
        Key_ShiftPressed 	= 0x01,
        Key_CtrlPressed 	= 0x02,
        Key_AltPressed 		= 0x04,
        Key_CapsToggled 	= 0x08,
        Key_NumToggled 		= 0x10,
        Key_ScrollToggled 	= 0x20,
        Key_ExtendedKey 	= 0x40, // set when right shift, alt or ctrl is pressed

        Initialized_Bit 	= 0x80,
        Initialized_Mask 	= 0xFF
    };
		
    // System.Byte States; // Unused.
};

public class SFKey
{
    public	enum Code
        {
            // Key::None indicates that no key was specified.
            None = 0,

            // A through Z and numbers 0 through 9.
            A = 65,
            B,
            C,
            D,
            E,
            F,
            G,
            H,
            I,
            J,
            K,
            L,
            M,
            N,
            O,
            P,
            Q,
            R,
            S,
            T,
            U,
            V,
            W,
            X,
            Y,
            Z,
            Num0 = 48,
            Num1,
            Num2,
            Num3,
            Num4,
            Num5,
            Num6,
            Num7,
            Num8,
            Num9,

            // Numeric keypad.
            KP_0 = 96,
            KP_1,
            KP_2,
            KP_3,
            KP_4,
            KP_5,
            KP_6,
            KP_7,
            KP_8,
            KP_9,
            KP_Multiply,
            KP_Add,
            KP_Enter,
            KP_Subtract,
            KP_Decimal,
            KP_Divide,

            // Function keys.
            F1 = 112,
            F2,
            F3,
            F4,
            F5,
            F6,
            F7,
            F8,
            F9,
            F10,
            F11,
            F12,
            F13,
            F14,
            F15,

            // Other keys.
            Backspace = 8,
            Tab,
            Clear = 12,
            Return,
            Shift = 16,
            Control,
            Alt,
            Pause,
            CapsLock = 20, // Toggle
            Escape = 27,
            Space = 32,
            PageUp,
            PageDown,
            End = 35,
            Home,
            Left,
            Up,
            Right,
            Down,
            Insert = 45,
            Delete,
            Help,
            NumLock = 144, // Toggle
            ScrollLock = 145, // Toggle

            Semicolon = 186,
            Equal = 187,
            Comma = 188, // Platform specific?
            Minus = 189,
            Period = 190, // Platform specific?
            Slash = 191,
            Bar = 192,
            BracketLeft = 219,
            Backslash = 220,
            BracketRight = 221,
            Quote = 222,

            OEM_AX = 0xE1,  //  'AX' key on Japanese AX kbd
            OEM_102 = 0xE2,  //  "<>" or "\|" on RT 102-key kbd.
            ICO_HELP = 0xE3,  //  Help key on ICO
            ICO_00 = 0xE4,  //  00 key on ICO

            // Total number of keys.
            KeyCount
        };
    public static Dictionary<UnityEngine.KeyCode, SFKey.Code> SFKeyDictionary;

    public static void CreateKeyDictionary()
    {
        SFKeyDictionary	= new Dictionary<UnityEngine.KeyCode, SFKey.Code>();
        SFKeyDictionary.Add(UnityEngine.KeyCode.A, Code.A);
        SFKeyDictionary.Add(UnityEngine.KeyCode.B, Code.B);
        SFKeyDictionary.Add(UnityEngine.KeyCode.C, Code.C);
        SFKeyDictionary.Add(UnityEngine.KeyCode.D, Code.D);
        SFKeyDictionary.Add(UnityEngine.KeyCode.E, Code.E);
        SFKeyDictionary.Add(UnityEngine.KeyCode.F, Code.F);
        SFKeyDictionary.Add(UnityEngine.KeyCode.G, Code.G);
        SFKeyDictionary.Add(UnityEngine.KeyCode.H, Code.H);
        SFKeyDictionary.Add(UnityEngine.KeyCode.I, Code.I);
        SFKeyDictionary.Add(UnityEngine.KeyCode.J, Code.J);
        SFKeyDictionary.Add(UnityEngine.KeyCode.K, Code.K);
        SFKeyDictionary.Add(UnityEngine.KeyCode.L, Code.L);
        SFKeyDictionary.Add(UnityEngine.KeyCode.M, Code.M);
        SFKeyDictionary.Add(UnityEngine.KeyCode.N, Code.N);
        SFKeyDictionary.Add(UnityEngine.KeyCode.O, Code.O);
        SFKeyDictionary.Add(UnityEngine.KeyCode.P, Code.P);
        SFKeyDictionary.Add(UnityEngine.KeyCode.Q, Code.Q);
        SFKeyDictionary.Add(UnityEngine.KeyCode.R, Code.R);
        SFKeyDictionary.Add(UnityEngine.KeyCode.S, Code.S);
        SFKeyDictionary.Add(UnityEngine.KeyCode.T, Code.T);
        SFKeyDictionary.Add(UnityEngine.KeyCode.U, Code.U);
        SFKeyDictionary.Add(UnityEngine.KeyCode.V, Code.V);
        SFKeyDictionary.Add(UnityEngine.KeyCode.W, Code.W);
        SFKeyDictionary.Add(UnityEngine.KeyCode.X, Code.X);
        SFKeyDictionary.Add(UnityEngine.KeyCode.Y, Code.Y);
        SFKeyDictionary.Add(UnityEngine.KeyCode.Z, Code.Z);
        SFKeyDictionary.Add(UnityEngine.KeyCode.Backspace, Code.Backspace);
        SFKeyDictionary.Add(UnityEngine.KeyCode.Space, Code.Space);
        SFKeyDictionary.Add(UnityEngine.KeyCode.Return, Code.Return);
        SFKeyDictionary.Add(UnityEngine.KeyCode.CapsLock, Code.CapsLock);
        SFKeyDictionary.Add(UnityEngine.KeyCode.Comma, Code.Comma);
        SFKeyDictionary.Add(UnityEngine.KeyCode.Semicolon, Code.Semicolon);
        SFKeyDictionary.Add(UnityEngine.KeyCode.Period, Code.Period);
        
    }

    public static Code GetSFKeyCode(UnityEngine.KeyCode unityKeyCode)
    {
        if (SFKeyDictionary.ContainsKey(unityKeyCode))
        {
            return SFKeyDictionary[unityKeyCode];
        }
        else
        {
            return Code.None;
        }
    }

    public static SFKeyModifiers.Modifiers GetSFModifiers(UnityEngine.EventModifiers unityModifier)
    {
        if (unityModifier == UnityEngine.EventModifiers.Alt)
        {
            return SFKeyModifiers.Modifiers.Key_AltPressed;
        }
        if (unityModifier == UnityEngine.EventModifiers.Control)
        {
            return SFKeyModifiers.Modifiers.Key_CtrlPressed;
        }
        if (unityModifier == UnityEngine.EventModifiers.CapsLock)
        {
            return SFKeyModifiers.Modifiers.Key_CapsToggled;
        }
        if (unityModifier == UnityEngine.EventModifiers.Shift)
        {
            return SFKeyModifiers.Modifiers.Key_ShiftPressed;
        }
        if (unityModifier == UnityEngine.EventModifiers.Numeric)
        {
            return SFKeyModifiers.Modifiers.Key_NumToggled;
        }
        return 0;
    }
}

} // namespace Scaleform;
