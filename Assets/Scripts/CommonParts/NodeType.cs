namespace BT
{
    using System;
    [Flags]
    public enum NodeType
    {
        COMPOSITE = 1,
        SELECTOR = 2,
        SEQUENCE = 4,
        PARALLEL = 8,
        TASK = 100
    }
}