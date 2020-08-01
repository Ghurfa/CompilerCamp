﻿using SymbolsTable.Nodes;
using SymbolsTable.TypeInfos;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace SymbolsTable.ItemInfos
{
    public class LibraryMethod : Method
    {
        public MethodInfo MethodInfo { get; private set; }
        private SymbolsTable table;

        private bool typeLoaded = false;
        public override FunctionTypeInfo Type
        {
            get
            {
                if (!typeLoaded) LoadType();
                return base.Type;
            }
        }

        public LibraryMethod(SymbolsTable table, MethodInfo method)
            : base(method.Name, GetModifiers(method))
        {
            this.table = table;
            MethodInfo = method;
        }

        private void LoadType()
        {
            TypeInfos.TypeInfo retType;
            if (MethodInfo.ReturnType == typeof(void))
            {
                retType = VoidTypeInfo.Get();
            }
            else
            {
                table.GetLibraryClass(MethodInfo.ReturnType, out LibraryClassNode retNode);
                retType = ValueTypeInfo.Get(retNode);
            }

            var parameters = MethodInfo.GetParameters();
            ValueTypeInfo[] paramTypes = new ValueTypeInfo[parameters.Length];
            for(int i = 0; i < parameters.Length; i++)
            {
                table.GetLibraryClass(parameters[i].ParameterType, out LibraryClassNode retNode);
                paramTypes[i] = ValueTypeInfo.Get(retNode);
            }
            base.Type = new FunctionTypeInfo(retType, paramTypes);

            typeLoaded = true;
        }

        private static Modifiers GetModifiers(MethodInfo method)
        {
            AccessModifier accessModifier;
            if (method.IsPublic) accessModifier = AccessModifier.PublicModifier;
            else if (method.IsPrivate) accessModifier = AccessModifier.PrivateModifier;
            else accessModifier = AccessModifier.ProtectedModifier;
            return new Modifiers(accessModifier, method.IsStatic);
        }
    }
}