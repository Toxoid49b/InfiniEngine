using System;

namespace InfiniEngine.InfiniScript {

    public enum VarType {

        String = 0,
        Integer = 1,
        Boolean = 2

    }

    public struct EngineVar {

        public VarType type;
        public string value;
        public string name;

    }

}
