﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TypeChecker.TypeInfos
{
    class VoidTypeInfo : TypeInfo
    {
        private static VoidTypeInfo instance = new VoidTypeInfo();
        public static VoidTypeInfo Get() => instance;
    }
}